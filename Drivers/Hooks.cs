using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Demo.Source.Utility;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Demo.Source.Drivers
{
    [Binding]
    public class Hooks
    {
        // No more static or shared instances for WebDriver or ExtentTest
        [ThreadStatic] private static IWebDriver? _driver;
        [ThreadStatic] private static ExtentTest? _featureName;
        [ThreadStatic] private static ExtentTest? _scenario;

        private static ExtentReports? _extent;
        private readonly IObjectContainer? _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void GlobalSetup()
        {

            // Initialize ExtentReports (shared across tests, safe to be static)
            _extent = new ExtentReports();
            var reporter = new ExtentHtmlReporter(FrameworkConstant.GetReportPath() + "index.html");
            reporter.Config.DocumentTitle = "Automation Report";
            reporter.Config.ReportName = "Test Report";
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void CreateTest(FeatureContext featureContext)
        {
            // Create a new test for each feature, thread-safe
            _featureName = _extent?.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            // Create a node for each scenario
            _scenario = _featureName?.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);

            // Initialize WebDriver, ensure each thread gets its own driver instance
            _driver = Drivers.SetupDriver();

            // Register WebDriver with SpecFlow's object container for dependency injection
            _objectContainer?.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();

            if (scenarioContext.TestError == null && resultOfImplementation == "OK")
            {
                CreateNode(stepType, stepInfo);
            }
            else if (scenarioContext.TestError != null)
            {                
                // Capture screenshot 
                string testError = scenarioContext.TestError.Message;
                string screenshot = Common.CaptureScreenShot(_driver!, scenarioContext.ScenarioInfo.Title);
                CreateNode(stepType, stepInfo, testError, screenshot);
            }
        }

        private void CreateNode(string stepType, string stepInfo, string? testError = null, string? screenshot = null)
        {
            ExtentTest? node = stepType switch
            {
                "Given" => _scenario?.CreateNode<Given>(stepInfo),
                "When" => _scenario?.CreateNode<When>(stepInfo),
                "Then" => _scenario?.CreateNode<Then>(stepInfo),
                "And" => _scenario?.CreateNode<And>(stepInfo),
                "But" => _scenario?.CreateNode<But>(stepInfo),
                _ => throw new ArgumentOutOfRangeException()
            };

            if (testError != null)
            {
                var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshot).Build();
                node?.Fail(testError, mediaModel);
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            // Properly quit and dispose of the WebDriver instance after each scenario
            _driver?.Quit();
        }

        [AfterFeature]
        public static void afterFeature()
        {
            // Flush the ExtentReports after all tests are completed
            _extent?.Flush();
        }

        [AfterTestRun]
        public static void GlobalTearDown()
        {
            // Rename the report with a timestamp
            Common.RenameExtentReport(Common.CurrentDateTime());
        }
    }
}
