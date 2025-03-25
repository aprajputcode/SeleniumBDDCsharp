namespace Demo.Source.Utility
{
    public class FrameworkConstant
    {
        private FrameworkConstant() { }
        private static string PROJECTPATH = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        private static string APPSETTINGPATH = PROJECTPATH + "/appsetting.json";
        private static string JSONCONFIGFILEPATH = PROJECTPATH + "/Resources/";
        private static int EXPLICITWAIT = 30;
        private static string REPORTPATH = PROJECTPATH + "/Report/";
        private static string SCREENSHOT_FOLDER_PATH = PROJECTPATH+"/Report/Screenshots/";
        private static int WaitTime = 5;

        /**
        * this method is used to get json file path
	    */
        public static String GetJsonfilepath()
        {
            return JSONCONFIGFILEPATH;
        }
        
        /**
        * this method is used to get json file path
	    */
        public static int GetWaitTime()
        {
            return WaitTime;
        }

        /**
        * this method is used to get appsetting.json file path
	    */
        public static String GetAppSettingPath()
        {
            return APPSETTINGPATH;
        }

        /**
        * this method is used to get explicit wait
	    */
        public static int GetExplicitWait()
        {
            return EXPLICITWAIT;
        }


        /**
        * this method is used to get report folder path
	    */
        public static string GetReportPath()
        {
            return REPORTPATH;
        }

        /**
        * this method is used to get screenshot folder path
	    */
        public static string GetScreenshotFolderPath()
        {
            return SCREENSHOT_FOLDER_PATH;
        }
    }
}