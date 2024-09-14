using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Navigation pane.
    /// </summary>
    public class NavigationPane
    {
        private IWebDriver _driver;

        public NavigationPane(IWebDriver driver)
        {
            _driver = driver;
        }

        public NavigationPane Open()
        {
            return this;
        }

        /// <summary>
        /// Select Home from Navigation pane.
        /// </summary>
        public void Home()
        {
            _driver.LogClick(NavigationPaneLocators.Home, "Select Home from Navigation pane.");
        }

        /// <summary>
        /// Select Counter from Navigation pane.
        /// </summary>
        public void Counter()
        {
            _driver.LogClick(NavigationPaneLocators.Counter, "Select Counter from Navigation pane.");
        }

        /// <summary>
        /// Select Weather from Navigation pane.
        /// </summary>
        public void Weather()
        {
            _driver.LogClick(NavigationPaneLocators.Weather, "Select Regsiter from Weather pane.");
        }

        /// <summary>
        /// Select Register from Navigation pane.
        /// </summary>
        public void Register()
        {
            _driver.LogClick(NavigationPaneLocators.Register, "Select Regsiter from Navigation pane.");
        }

        /// <summary>
        /// Select Login from Navigation pane.
        /// </summary>
        public void Login()
        {
            _driver.LogClick(NavigationPaneLocators.Login, "Select Login from Navigation pane.");
        }

        /// <summary>
        /// Select Logout from Navigation pane.
        /// </summary>
        public void Logout()
        {
            _driver.LogClick(NavigationPaneLocators.Logout, "Select Logout from Navigation pane.");
        }

        /// <summary>
        /// Select User Profile from Navigation pane
        /// </summary>
        /// <param name="userEmail">The email of the user, which is text shown in the navigation pane for the user profile.</param>
        public void UserPorfile(string userEmail)
        {
            _driver.LogClick(NavigationPaneLocators.UserProfile(userEmail), $"Select user profile (${userEmail}) from Navigation pane.");
        }
    }
}
