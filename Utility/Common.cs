using OpenQA.Selenium;

namespace Demo.Source.Utility
{
    public class Common
    {
        public static string? downloadedFileName = null;
        private Common()
        { }

        /**
        * this method is used to click on web element
	    */
        public static void ClickOn(IWebDriver driver, String element)
        {
            GetElement.GetWebElement(driver, element).Click();
        }

        /**
        * this method is used to clear and send keys
	    */
        public static void ClearInputFieldSendkeys(IWebDriver driver, String element, String value)
        {
            try
            {
                GetElement.GetWebElement(driver, element).Clear();
                GetElement.GetWebElement(driver, element).SendKeys(value);
            }
            catch (ElementNotVisibleException)
            {
                throw new Exception("element not visible after 30 seconds of waiting please check element path");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /**
        * this method is used to get element text
        */
        public static String GetText(IWebDriver driver, String ElementName)
        {
            return GetElement.GetWebElement(driver, ElementName).Text;
        }

        /**
        * this method is used to generate random numbers based on input
        */
        public static string RandomeNumbers(int n)
        {
            Random random = new Random();
            int minValue = (int)Math.Pow(10, n - 1);
            int maxValue = (int)Math.Pow(10, n) - 1;
            return random.Next(minValue, maxValue + 1).ToString();
        }

        /**
        * this method is used to take screenshot
        */
        public static string CaptureScreenShot(IWebDriver _driver, string name)
        {
            name = name.Replace(" ", "_");
            name = name.Replace("'", "");
            name = name.Replace("/", "");
            name = name.Replace(".", "_");
            name = name.Replace(":", "_");
            name = name.Replace(",", "_");
            name = name.Replace("(", "_");
            name = name.Replace(")", "_");
            name = name.Replace("@", "");
            name = name.Replace("#", "");
            name = name.Replace("\"", "");
            name = name.Replace("-", "_");
            if (name.Length > 150)
                name = name.Substring(0, 150);

            ITakesScreenshot ts = (ITakesScreenshot)_driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenShotName = name;
            string localpath = FrameworkConstant.GetScreenshotFolderPath() + screenShotName + ".png";
            screenshot.SaveAsFile(localpath);
            return "Screenshots/" + screenShotName + ".png";
        }


        /**
        * this method is used to rename extent report name
        */
        public static void RenameExtentReport(string name)
        {
            System.IO.File.Move(FrameworkConstant.GetReportPath() + "index.html", FrameworkConstant.GetReportPath() + "HtmlReport_" + name + ".html");
        }

        /**
        * this method is used to get current date time
        */
        public static string CurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
        }
    }
}