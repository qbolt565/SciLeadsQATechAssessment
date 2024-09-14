using OpenQA.Selenium;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;
namespace SciLeadsQATechAssessment.PageObjects
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
