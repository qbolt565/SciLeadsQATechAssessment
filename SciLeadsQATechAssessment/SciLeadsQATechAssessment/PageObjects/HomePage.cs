using OpenQA.Selenium;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with the Home page.
    /// </summary>
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns>Returns the same instance of the Login page.</returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(HomepageLocators.Header, "Check Home page is displayed.");
        }

        /// <summary>
        /// Checks if "You are logged in as <useremail>" message is displayed.
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns>True if message displayed.</returns>
        public bool IsLoggedIn(string email)
        {
            IWebElement article =  _driver.FindElement(HomepageLocators.Article);
            return article.Text.Contains($"You are logged in as {email}.");
        }

        /// <summary>
        /// Checks if "Login or Register to continue." message is displayed.
        /// </summary>
        /// <returns>True if message displayed.</returns>
        public bool IsNotLoggedIn()
        {
            IWebElement article = _driver.FindElement(HomepageLocators.Article);
            return article.Text.Contains($"Login or Register to continue.");
        }
    }
}