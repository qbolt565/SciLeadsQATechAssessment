using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Models;
using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests.UI.Support
{
    /// <summary>
    /// Class for automating common user actions.
    /// </summary>
    public class Workflows
    {
        private IWebDriver _driver;

        public Workflows(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Updates the instance of web driver to the latest.
        /// </summary>
        /// <param name="driver">The new WebDriver Instance</param>
        public void UpdateDriver(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="user">Credentials for new user.</param>
        public void CreateNewUser(User user)
        {
            RegistrationPage registrationPage = new(_driver);
            registrationPage.Open()
                .EnterEmail(user.Email)
                .EnterPassword(user.Password)
                .EnterConfirmPassword(user.Password)
                .ClickRegister();

            RegistrationConfirmationPage registrationConfirmationPage = new(_driver);
            registrationConfirmationPage.ClickConfirmLink();
        }

        /// <summary>
        /// Opens the login page and logs in as the provider user
        /// </summary>
        /// <param name="user">User to login as</param>
        public void LoginAs(User user)
        {
            LoginPage loginPage = new(_driver);
            loginPage.Open()
                .EnterEmail(user.Email)
                .EnterPassword(user.Password)
                .ClickLogin();             
        }
    }
}
