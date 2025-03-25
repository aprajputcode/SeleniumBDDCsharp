using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Demo.Source.Utility
{
    public class Waits
    {
        private Waits() { }

        /**
	    * this method is used to explicit Wait Visibility Of Element
	    */
        public static IWebElement ExplicitWaitVisibilityOfElement(IWebDriver driver, string element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(FrameworkConstant.GetExplicitWait()));
            IWebElement? webElement = null;
            try
            {
                if (element.StartsWith("/") || element.StartsWith("("))
                {
                    webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(element)));
                }
                else
                {
                    webElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(element)));
                }

            }
            catch
            {
                throw new Exception("element not visible after 30 seconds of waiting please check element path");
            }
            return webElement;
        }
    }
}