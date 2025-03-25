using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Demo.Source.Utility
{
    public class ReadAppSettings
    {
        private static string fileName=null;
        public static String? GetElementPath(String elementName)
        {
            var filename = fileName;
            var element = elementName;
            string? elementValue = null ;
            try
            {
                string jsonFilePath = FrameworkConstant.GetJsonfilepath() + filename + ".json";
                JObject AppSett = JObject.Parse(File.ReadAllText(jsonFilePath));
                if (AppSett[element] == null)
                {
                    throw new NullReferenceException($"Element '{element}' not found in '{filename}.json'");
                }
                elementValue = AppSett[element]?.ToString();
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"JSON file '{filename}.json' not found.", ex);
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Error parsing JSON in file '{filename}.json'.", ex);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException($"Element '{element}' not found in '{filename}.json'.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while reading the JSON file.", ex);
            }
            return elementValue;
        }

        /**
        * this method is used to return Browser name
        */
        public static string AppSettingElement(string elementName)
        {
            JObject appS = JObject.Parse(File.ReadAllText(FrameworkConstant.GetAppSettingPath()));
            return (string) appS.GetValue(elementName)!;
        }

        public static void setPage(string page)
        {
            fileName = page;
        }
    }
}