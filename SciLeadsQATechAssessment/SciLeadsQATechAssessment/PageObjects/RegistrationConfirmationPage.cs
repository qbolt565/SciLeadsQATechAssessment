
using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
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
        /// Click the Confirm Link. 
        /// </summary>
        /// <returns></returns>
        public RegistrationConfirmationPage ClickConfirmLink()
        {
            _driver.LogClick(RegistrationConfirmationLocators.ConfirmLink, "Click the Confirm link.");

            ConfirmPasswordPage confirmPasswordPage = new(_driver);
            _driver.WaitUntil(confirmPasswordPage.IsDisplayed);

            return this;
        }

        /// <summary>
        /// Check if an alert has been displayed.
        /// </summary>
        /// <returns>Retruns true if an alert is displayed.</returns>
        public bool IsAlertDisplayed()
        {
            return _driver.TryFindElement(RegistrationConfirmationLocators.Alert, out _);
        }

        /// <summary>
        /// Returns the text displayed in the alert.
        /// </summary>
        /// <returns>Error text.</returns>
        public string AlertText()
        {
            return _driver.LogReadText(RegistrationConfirmationLocators.Alert, "Get the text displayed in the alert box.");
        }
    }
}