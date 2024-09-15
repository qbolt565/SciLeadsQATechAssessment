using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Confirm Password page.
    /// </summary>
    public class ConfirmPasswordPage
    {
        private IWebDriver _driver;

        public ConfirmPasswordPage(IWebDriver driver)
        {  
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ConfirmPasswordLocators.Header, "Is Confirm Password page displayed.");
        }
    }
}
