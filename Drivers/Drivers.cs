using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using Demo.Source.Utility;

namespace Demo.Source.Drivers
{
    public class Drivers
    {
        private static IWebDriver? driver;

        public static IWebDriver? SetupDriver()
        {
            switch (ReadAppSettings.AppSettingElement("Browser").ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--window-size=1920,1080");
                    switch (ReadAppSettings.AppSettingElement("Runmode").ToLower()) {
                        case "local":
                            driver=new ChromeDriver(chromeOptions);
                            break;
                        case "local-headless":
                            chromeOptions.AddArguments("headless=new");
                            driver = new ChromeDriver(chromeOptions);
                            break;
                            }
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments("--window-size=1920,1080");
                    switch (ReadAppSettings.AppSettingElement("Runmode").ToLower())
                    {
                        case "local":
                            driver = new EdgeDriver(edgeOptions);
                            break;
                        case "local-headless":
                            edgeOptions.AddArguments("headless=new");
                            driver = new EdgeDriver(edgeOptions);
                            break;
                    }
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--window-size=1920,1080");
                    switch (ReadAppSettings.AppSettingElement("Runmode").ToLower())
                    {
                        case "local":
                            driver = new FirefoxDriver(firefoxOptions);
                            break;
                        case "local-headless":
                            firefoxOptions.AddArguments("headless=new");
                            driver = new FirefoxDriver(firefoxOptions);
                            break;
                    }
                    break;
            }
            return driver;
        }
        
    }
}