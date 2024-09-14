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

namespace SciLeadsQATechAssessment
{
    public class LoginTests
    {
        private WebApp _webApp;
        private User _knownUser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        { 
            _knownUser = TestDataUtils.GetTestUser();

            _webApp = new WebApp();
            _webApp.Open();

            Workflows workflows = new Workflows();
            workflows.CreateNewUser(_webApp.Driver, _knownUser);

            _webApp.Close();
        }

        [SetUp]
        public void Setup()
        {
            _webApp = new WebApp();
            _webApp.Open();
        }

        [TearDown]
        public void Teardown()
        {
            _webApp.Close();
        }

        [Test]
        public void LoginPage_ClickLogInWithNoCredentails_LoginFails()
        {
            LoginPage loginPage = new(_webApp.Driver);

            loginPage.Open()
                .ClickLogin();
            Assert.Multiple(() => {
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

            LoginPage loginPage = new(_webApp.Driver);
            loginPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .ClickLogin();

            Assert.That(loginPage.AlertText, Is.EqualTo("Error: Invalid login attempt."));
        }

        [Test]
        public void LoginPage_ClickLoginWithKnownEmailButWrongPassword_LoginFails()
        {
            LoginPage loginPage = new(_webApp.Driver);
            loginPage.Open()
                .EnterEmail(_knownUser.Email)
                .EnterPassword($"!{_knownUser.Password}")
                .ClickLogin();

            Assert.That(loginPage.AlertText, Is.EqualTo("Error: Invalid login attempt."));
        }

        [Test]
        public void LoginPage_ClickRegisterNewUser_RegistrationPageDisplayed()
        {
            LoginPage loginPage = new(_webApp.Driver);
            loginPage.Open()
                .ClickRegisterAsANewUser();

            RegistrationPage registrationPage = new(_webApp.Driver);
            Assert.That(registrationPage.IsDisplayed(), "Registration page was not displayed.");
        }

    }
}
