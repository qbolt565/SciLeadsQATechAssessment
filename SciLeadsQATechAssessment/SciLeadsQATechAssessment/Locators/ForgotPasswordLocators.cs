using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Forgot Password page.
    /// </summary>
    public class ForgotPasswordLocators
    {
        public static By Header => By.XPath("//h1[text()='Forgot your password?']");
        public static By EmailInput => By.Name("Input.Email");
        public static By ResetPasswordButton => By.XPath("//button[text()='Reset password']");

    }
}
