using OpenQA.Selenium;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Resend email confirmation page.
    /// </summary>
    public class ResendEmailConfirmationPage
    {
        private IWebDriver _driver;

        public ResendEmailConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ResendEmailConfirmationLocators.Header, "Check Resend email confirmation page is displayed.");
        }

        /// <summary>
        /// Enter the supplied text into the Email field.
        /// </summary>
        /// <param name="email">Text to be entered into Email field.</param>
        /// <returns>Returns the same instance of the ResendEmailConfirmationPage.</returns>
        public ResendEmailConfirmationPage EnterEmail(string email)
        {
            _driver.LogSendText(ResendEmailConfirmationLocators.EmailInput, email, $"Enter {email} into Email field.");
            return this;
        }

        /// <summary>
        /// Clicks the Resend button.
        /// </summary>
        public void ClickResendButton()
        {
            _driver.LogClick(ResendEmailConfirmationLocators.ResendButton, "Click resend button.");

            RegistrationConfirmationPage registrationConfirmationPage = new(_driver);
            _driver.WaitUntil(registrationConfirmationPage.IsDisplayed);
        }
    }
}
