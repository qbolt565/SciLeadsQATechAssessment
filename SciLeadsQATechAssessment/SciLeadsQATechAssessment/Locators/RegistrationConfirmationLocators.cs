using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Registration Confirmation page.
    /// </summary>
    public class RegistrationConfirmationLocators
    {
        public static By Header => By.XPath("//h1[text()='Register confirmation']");
        public static By ConfirmLink => By.LinkText("Click here to confirm your account");
        public static By Alert => By.XPath("//div[@class='alert alert-danger']");
    }
}
