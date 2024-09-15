using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Forgot Password Confirmation page.
    /// </summary>
    public class ForgotPasswordConfirmationPage
    {
        private IWebDriver _driver;

        public ForgotPasswordConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ForgotPasswordConfirmationLocators.Header, "Check Forgot password confirmation page is displayed.");
        }
    }
}
