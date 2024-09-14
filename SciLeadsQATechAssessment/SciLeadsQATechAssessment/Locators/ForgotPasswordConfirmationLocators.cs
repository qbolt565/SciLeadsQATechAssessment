using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Forgot Password Confirmation page.
    /// </summary>
    public class ForgotPasswordConfirmationLocators
    {
        public static By Header => By.XPath("//h1[text()='Forgot password confirmation']");
    }
}
