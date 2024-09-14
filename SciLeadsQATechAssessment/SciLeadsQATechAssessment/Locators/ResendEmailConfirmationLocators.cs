using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Resend Email Confirmation page.
    /// </summary>
    public class ResendEmailConfirmationLocators
    {
        public static By Header => By.XPath("//h1[text()='Resend email confirmation']");
        public static By EmailInput => By.Name("Input.Email");
        public static By ResendButton => By.XPath("//button[text()='Resend']");

    }
}
