using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciLeadsQATechAssessment.PageObjects;
using SciLeadsQATechAssessment.Models;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.Tests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginPage_ClickLogInWithNoCredentails_LoginFails()
        {
            LoginPage loginPage = new(WebApp.Driver);

            loginPage.Open()
                .ClickLogin();
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.SummaryErrorText, Is.EqualTo("The Email field is required.\r\nThe Password field is required."));
                Assert.That(loginPage.EmailErrorText, Is.EqualTo("The Email field is required."));
                Assert.That(loginPage.PasswordErrorText, Is.EqualTo("The Password field is required."));
            });
        }

        [Test]
        public void LoginPage_ClickLoginWithUnknownEmail_LoginFails()
        {
            string email = TestDataUtils.GetTestEmail();
            string password = "P@33word";

            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .ClickLogin();

            Assert.That(loginPage.AlertText, Is.EqualTo("Error: Invalid login attempt."));
        }

        [Test]
        public void LoginPage_ClickLoginWithKnownEmailButWrongPassword_LoginFails()
        {
            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .EnterEmail(KnownUser.Email)
                .EnterPassword($"!{KnownUser.Password}")
                .ClickLogin();

            Assert.That(loginPage.AlertText, Is.EqualTo("Error: Invalid login attempt."));
        }

        [Test]
        public void LoginPage_ClickRegisterNewUser_RegistrationPageDisplayed()
        {
            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .ClickRegisterAsANewUser();

            RegistrationPage registrationPage = new(WebApp.Driver);
            Assert.That(registrationPage.IsDisplayed(), "Registration page was not displayed.");
        }

    }
}
