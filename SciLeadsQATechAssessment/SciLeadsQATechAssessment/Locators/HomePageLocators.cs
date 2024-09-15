using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Registration page.
    /// </summary>
    public class HomepageLocators
    {
        public static By Header => By.XPath("//h1['Hello, world !!']");
        public static By Article => By.TagName("article");
        public static By AboutLink => By.LinkText("About");
    }
}
