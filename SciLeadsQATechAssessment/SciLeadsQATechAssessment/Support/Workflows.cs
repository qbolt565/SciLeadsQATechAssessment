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
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="IWebDriver">Currently active web driver instance.</param>
        /// <param name="user">Credentials for new user.</param>
        public void CreateNewUser(IWebDriver driver, User user)
        {
            RegistrationPage registrationPage = new(driver);
            registrationPage.Open()
                .EnterEmail(user.Email)
                .EnterPassword(user.Password)
                .EnterConfirmPassword(user.Password)
                .ClickRegister();

            RegistrationConfirmationPage registrationConfirmationPage = new(driver);
            registrationConfirmationPage.ClickConfirmLink();
        }
    }
}
