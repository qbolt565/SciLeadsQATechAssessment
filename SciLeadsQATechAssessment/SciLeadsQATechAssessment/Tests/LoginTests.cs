using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using SciLeadsQATechAssessment.Tests.UI.Models;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
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

        [Test]
        public void ForgotPassword_EmailMatchesExistingUser_ConfirmationDisplayed()
        {
            LoginPage login = new(WebApp.Driver);
            login.Open()
                .ClickForgotYourPassword();

            ForgotPasswordPage forgotPasswordPage = new(WebApp.Driver);
            forgotPasswordPage.EnterEmail(KnownUser.Email)
                .ClickResetPassworsButton();

            ForgotPasswordConfirmationPage forgotPasswordConfirmationPage = new(WebApp.Driver);
            Assert.That(forgotPasswordConfirmationPage.IsDisplayed(), "Forgot password confirmation page was not displayed.");
        }

        [Test]
        public void ForgotPassword_EmailDoesNotMatchExistingUser_ConfirmationDisplayed()
        {
            string unregisteredEmail = TestDataUtils.GetTestEmail();

            LoginPage login = new(WebApp.Driver);
            login.Open()
                .ClickForgotYourPassword();

            ForgotPasswordPage forgotPasswordPage = new(WebApp.Driver);
            forgotPasswordPage.EnterEmail(unregisteredEmail)
                .ClickResetPassworsButton();

            ForgotPasswordConfirmationPage forgotPasswordConfirmationPage = new(WebApp.Driver);
            Assert.That(forgotPasswordConfirmationPage.IsDisplayed(), "Forgot password confirmation page was not displayed.");
        }

        [Test]
        public void ResendEmailConfirmation_EmailMatchesExistingUser_RegisterConfirmationDisplayed()
        {
            LoginPage login = new(WebApp.Driver);
            login.Open()
                .ClickResendEmailConfirmationLink();

            ResendEmailConfirmationPage resendEmailConfirmationPage = new(WebApp.Driver);
            resendEmailConfirmationPage.EnterEmail(KnownUser.Email)
                .ClickResendButton();

            RegistrationConfirmationPage registrationConfirmationPage = new(WebApp.Driver);
            Assert.That(!registrationConfirmationPage.IsAlertDisplayed(), "Registration confirmation page is unexpectedly showing an error.");
        }



        [Test]
        public void ResendEmailConfirmation_EmailDoesNotMatchExistingUser_RegisterConfirmationDisplayed()
        {
            string unregisteredEmail = TestDataUtils.GetTestEmail();

            LoginPage login = new(WebApp.Driver);
            login.Open()
                .ClickResendEmailConfirmationLink();

            ResendEmailConfirmationPage resendEmailConfirmationPage = new(WebApp.Driver);
            resendEmailConfirmationPage.EnterEmail(unregisteredEmail)
                .ClickResendButton();

            RegistrationConfirmationPage registrationConfirmationPage = new(WebApp.Driver);
            Assert.That(registrationConfirmationPage.IsAlertDisplayed(), "Alert was not displayed on Register confirmation page.");
            Assert.That(registrationConfirmationPage.AlertText(), Is.EqualTo("Error finding user for unspecified email"));
        }

    }
}
