using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Forgot Password page.
    /// </summary>
    public class ForgotPasswordPage
    {
        private IWebDriver _driver;

        public ForgotPasswordPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ForgotPasswordLocators.Header, "Check Forgot password page is displayed.");
        }

        /// <summary>
        /// Enter the supplied text into the Email field.
        /// </summary>
        /// <param name="email">Text to be entered into Email field.</param>
        /// <returns>Returns the same instance of the ForgotPassword Page.</returns>
        public ForgotPasswordPage EnterEmail(string email)
        {
            _driver.LogSendText(ForgotPasswordLocators.EmailInput, email, $"Enter {email} into Email field.");
            return this;
        }

        /// <summary>
        /// Clicks the Reset Password button.
        /// </summary>
        public void ClickResetPassworsButton()
        {
            _driver.LogClick(ForgotPasswordLocators.ResetPasswordButton, "Click reset password button.");
        }
    }
}
