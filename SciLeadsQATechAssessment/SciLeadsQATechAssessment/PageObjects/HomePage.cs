﻿using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
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
        /// <returns></returns>
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

        /// <summary>
        /// Opens the Home page from the Navigation pane.
        /// </summary>
        /// <returns>The same instance of <see cref="HomePage"/>.</returns>
        public HomePage Open()
        {
            NavigationPane navigationPane = new(_driver);
            navigationPane.Open().Home();

            _driver.WaitUntil(IsDisplayed);

            return this;
        }

        /// <summary>
        /// Clicks the about link
        /// </summary>
        public void ClickAboutLink()
        { 
            _driver.LogClick(HomepageLocators.AboutLink, "Click the About link");
        }
    }
}