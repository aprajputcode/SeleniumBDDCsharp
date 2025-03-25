using Demo.Source.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(1)]

namespace KYC360.StepDefinitions
{
    [Binding]

    public class LoginStep
    {
        private IWebDriver driver;

        public LoginStep(IWebDriver _driver)
        {
            driver = _driver;

        }

        [Given(@"user on the '([^']*)' page")]
        public void GivenIAmOnThePage(string pageName)
        {
            ReadAppSettings.setPage(pageName);
            driver.Navigate().GoToUrl(ReadAppSettings.AppSettingElement("BaseUrl")+ string.Format(ReadAppSettings.GetElementPath("EndPoint")));
        }

        [When(@"user enter the '([^']*)':'([^']*)'")]
        public void WhenUserEnterThe(string element, string value)
        {
            Common.ClearInputFieldSendkeys(driver,element, value);
        }

        [When(@"user enter the random '([^']*)':'([^']*)'")]
        public void WhenUserEnterTheRandom(string element, string p1)
        {
            Common.ClearInputFieldSendkeys(driver, element, p1.Replace("demo", "demo"+Common.RandomeNumbers(5)));
        }

        [When(@"user click the '([^']*)' button")]
        public void WhenIClickTheButton(string button)
        {
            Common.ClickOn(driver, button);
        }

        [Then(@"user should see an '([^']*)':'([^']*)'")]
        public void ThenIShouldSeeAn(string element, string text)
        {
            Asserts.AssertsContainsTexts(Common.GetText(driver, element), text);
        }

        [Then(@"user should see the page title:'([^']*)'")]
        public void ThenUserShouldSeeThePageTitle(string title)
        {
            Asserts.AssertEqual(driver.Title,title);
        }
    }
}
