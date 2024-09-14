using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Counter page.
    /// </summary>
    public class CounterLocators
    {
        public static By Header => By.XPath("//h1[text()='Counter']");
        public static By CurrentCount => By.XPath("//p[@role='status']");
        public static By IncrementButton => By.XPath("//button[text()='Increment']");
    }
}
