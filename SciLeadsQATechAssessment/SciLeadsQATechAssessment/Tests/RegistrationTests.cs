using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using SciLeadsQATechAssessment.Tests.UI.Support;
using System.Net;
using System.Security.Principal;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
{
    public class RegistrationTests : TestBase
    {
        public void RegistrationPage_EnterValidEmailAndPasswordThenConfirm_CanLoginWithNewCredentials()
        {
            string email = TestDataUtils.GetTestEmail();
            string password = "P@33word";

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPassword(password)
                .ClickRegister();

            RegistrationConfirmationPage registrationConfirmationPage = new(WebApp.Driver);
            registrationConfirmationPage.ClickConfirmLink();

            ConfirmPasswordPage confirmPasswordPage = new(WebApp.Driver);

            Assert.That(confirmPasswordPage.IsDisplayed(), "Confirm password page was not displayed after registration confirmed.");

            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .ClickLogin();

            HomePage homePage = new(WebApp.Driver);

            Assert.That(homePage.IsLoggedIn(email), "The user was not successfully logged in.");
        }

        [Test]
        public void RegistrationPage_EnterValidEmailAndPasswordDoNotConfirm_CannotLoginWithNewCredentials()
        {
            string email = TestDataUtils.GetTestEmail();
            string password = "P@33word";

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPassword(password)
                .ClickRegister();

            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .ClickLogin();

            Assert.That(loginPage.AlertText, Is.EqualTo("Error: Invalid login attempt."), "Expected error message was not dislayed when attempting to login non confirmed user.");
        }

        [Test]
        public void RegistrationPage_EnterInvalidEmail_RegistrationsFails()
        {
            string invalidEmail = "!emial";
            string password = "P@33word";

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(invalidEmail)
                .EnterPassword(password)
                .EnterConfirmPassword(password)
                .ClickRegister(waitForRegistrationConfirmationPage: false);

            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.SummaryErrorText(), Is.EqualTo("The Email field is not a valid e-mail address."));
                Assert.That(registrationPage.EmailErrorText, Is.EqualTo("The Email field is not a valid e-mail address."));
            });
        }

        [TestCase("p@33word", "Error: Passwords must have at least one uppercase ('A'-'Z').", TestName = "Regsiter with password that is all in a single case.")]
        [TestCase("1234567!", "Error: Passwords must have at least one lowercase ('a'-'z')., Passwords must have at least one uppercase ('A'-'Z').", TestName = "Register with pasword that has no alphabetic characters.")]
        [TestCase("P@ssword", "Error: Passwords must have at least one digit ('0'-'9').", TestName = "Register with password with no numbers.")]
        [TestCase("Pas33word", "Error: Passwords must have at least one non alphanumeric character.", TestName = "Register with password with no symbols.")]
        public void RegistrationPage_EnterInvalidPasswordWithIncorrectCharacters_RegistrationsFailsWithSingleError(string password, string error)
        {
            string email = TestDataUtils.GetTestEmail();

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPassword(password)
                .ClickRegister(waitForRegistrationConfirmationPage: false);

            Assert.That(registrationPage.AlertText(), Is.EqualTo(error));
        }

        [TestCase("P@33wor", "The Password must be at least 8 and at max 100 characters long.", TestName = "Regsiter with password that is too short.")]
        [TestCase("yR4yUS.YbG-#%U)kLf}$QaZRJ(2qhF7Z}JUD_gy[]mH4uPR$FTeHfN4TG(NyU)3rp]$86*TnD_Cd)kefX-3;-(xZyT}Mn]e0R@u&A", "The Password must be at least 8 and at max 100 characters long.", TestName = "Regsiter with password that is too long.")]
        public void RegistrationPage_EnterInvalidPasswordWithWrongLength_RegistrationsFailsWithMultipleErrors(string password, string error)
        {
            string email = TestDataUtils.GetTestEmail();

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPassword(password)
                .ClickRegister(waitForRegistrationConfirmationPage: false);

            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.PasswordErrorText, Is.EqualTo(error));
                Assert.That(registrationPage.SummaryErrorText(), Does.EndWith(error));
            });
        }

        [Test]
        public void RegistrationPage_EnterMismatchedPasswords_RegistrationsFails()
        {
            string email = TestDataUtils.GetTestEmail();
            string password = "P@33word";
            string confirmPassword = "P@33word!";
            string error = "The password and confirmation password do not match.";

            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPassword(confirmPassword)
                .ClickRegister(waitForRegistrationConfirmationPage: false);

            Assert.Multiple(() =>
            {
                Assert.That(registrationPage.PasswordConfirmErrorText, Is.EqualTo(error));
                Assert.That(registrationPage.SummaryErrorText(), Does.EndWith(error));
            });
        }

        [Test]
        public void RegistrationPage_EnterEmailThatHasAlreadyBeenRegistered_RegistrationFails()
        {
            RegistrationPage registrationPage = new(WebApp.Driver);
            registrationPage.Open()
                .EnterEmail(KnownUser.Email)
                .EnterPassword(KnownUser.Password)
                .EnterConfirmPassword(KnownUser.Password)
                .ClickRegister(waitForRegistrationConfirmationPage: false);

            Assert.That(registrationPage.AlertText(), Is.EqualTo($"Error: Username '{KnownUser.Email}' is already taken."));
        }

    }
}