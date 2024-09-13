
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Registration Confirmation page.
    /// </summary>
    public class RegistrationConfirmationPage
    {
        private IWebDriver _driver;

        public RegistrationConfirmationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(RegistrationConfirmationLocators.Header, "Is Registration Confirmation page displayed.");
        }

        /// <summary>
        /// Click the Confirm Link 
        /// </summary>
        /// <returns></returns>
        public RegistrationConfirmationPage ClickConfirmLink()
        {
            _driver.LogClick(RegistrationConfirmationLocators.ConfirmLink, "Click the Confirm link");

            ConfirmPasswordPage confirmPasswordPage = new(_driver);
            _driver.WaitUntil(confirmPasswordPage.IsDisplayed);

            return this;
        }
    }
}