using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Weather page.
    /// </summary>
    public class WeatherLocators
    {
        public static By Header  => By.XPath("//h1[text()='Weather']");
        public static By WeatherTable => By.TagName("table");
    }
}
