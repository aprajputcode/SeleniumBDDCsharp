using OpenQA.Selenium;

namespace Demo.Source.Utility
{
    public class GetElement 
    {
        private GetElement() { }

        /**
        * this method is used to get web element 
	    */
        public static IWebElement GetWebElement(IWebDriver driver,String ElementName)
        {
            return Waits.ExplicitWaitVisibilityOfElement(driver,ReadAppSettings.GetElementPath(ElementName));
        }
    }
}