
using NUnit.Framework;

namespace Demo.Source.Utility
{
    public class Asserts
    {
        private Asserts() { }

        /**
        * this method is used to compare expected and actual text
        */
        public static void AssertEqual(String actual, String expected)
        {
            try
            {
                Assert.IsTrue(expected.Equals(actual.Trim()));
            }
            catch
            {
                throw new Exception($"Expected:{expected} \nActual:{actual}");
            }
        }

        /**
        * this method is used to compare expected value and actual contains text  
        */
        public static void AssertsContainsTexts(string actual, String containsText)
        {
            try
            {
                Assert.IsTrue(actual.Contains(containsText));
            }catch
            {
                throw new Exception($"Actual:{actual} \nExpected Contains Text:{containsText}");
            }
        }
    }
}