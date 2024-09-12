using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SciLeadsQATechAssessment.PageObjects;
using System.Net;
using System.Security.Principal;

namespace SciLeadsQATechAssessment
{
    public class RegistrationTests
    {
        private WebApp _webApp;

        [SetUp]
        public void Setup()
        {
            WebApp _webApp = new WebApp();
            _webApp.Open();
        }

        [TearDown]
        public void Teardown()
        {
            _webApp.Close();
        }

        [Test]
        public void RegistrationPage_EnterValidEmailAndPasswordThenConfirm_CanLoginWithNewCredentials()
        {
            string email = "user1@test.com";
            string password = "P@33word";

            RegistrationPage registrationPage = new RegistrationPage(_webApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPasswors(password)
                .ClickRegister();

            RegistrationConfirmationPage registrationConfirmationPage = new RegistrationConfirmationPage(_webApp.Driver);
            registrationConfirmationPage.ClickConfirmLink();

            LoginPage loginPage = new LoginPage(_webApp.Driver);
            loginPage.Open()
                .EnterUserName(email)
                .EnterPassword(password)
                .ClickLogin();

            HomePage homePage = new HomePage(_webApp.Driver);

            Assert.That(homePage.UserLoggedInMessageIsDisplayed(email));
        }

        [Test]
        public void RegistrationPage_EnterValidEmailAndPasswordDoNotConfirm_CannotLoginWithNewCredentials()
        {
            string email = "user1@test.com";
            string password = "P@33word";

            RegistrationPage registrationPage = new RegistrationPage(_webApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPasswors(password)
                .ClickRegister();

            LoginPage loginPage = new LoginPage(_webApp.Driver);
            loginPage.Open()
                .EnterUserName(email)
                .EnterPassword(password)
                .ClickLogin();

            HomePage homePage = new HomePage(_webApp.Driver);

            Assert.That(homePage.ErrorText(), Is.EqualTo(""));
        }

        [Test]
        public void RegistrationPage_EnterInvalidEmail_RegistrationsFails()
        {
            string invalidEmail = "!emial";
            string password = "P@33word";

            RegistrationPage registrationPage = new RegistrationPage(_webApp.Driver);
            registrationPage.Open()
                .EnterEmail(invalidEmail)
                .EnterPassword(password)
                .EnterConfirmPasswors(password)
                .ClickRegister();

            Assert.That(registrationPage.ErrorText(), Is.EqualTo(""));
        }

        [TestCase("P@33wor", TestName = "Regsiter with password that is too short.")]
        [TestCase("yR4yUS.YbG-#%U)kLf}$QaZRJ(2qhF7Z}JUD_gy[]mH4uPR$FTeHfN4TG(NyU)3rp]$86*TnD_Cd)kefX-3;-(xZyT}Mn]e0R@u&A", TestName = "Regsiter with password that is too long.")]
        [TestCase("p@33word", TestName = "Regsiter with password that is all in a single case.")]
        [TestCase("1234567!", TestName = "Register with pasword that has no alphabetic characters.")]
        [TestCase("P@ssword", TestName = "Register with password with no numbers.")]
        [TestCase("Pas33word", TestName = "Register with password with no symbols.")]
        public void RegistrationPage_EnterInvalidPassword_RegistrationsFails(string password)
        {
            string email = "user1@test.com";

            RegistrationPage registrationPage = new RegistrationPage(_webApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPasswors(password)
                .ClickRegister();

            Assert.That(registrationPage.ErrorText(), Is.EqualTo(""));
        }

        [Test]
        public void RegistrationPage_EnterMismatcedPasswords_RegistrationsFails()
        {
            string email = "user1@test.com";
            string password = "P@33word";
            string confirmPassword = "P@33word!";

            RegistrationPage registrationPage = new RegistrationPage(_webApp.Driver);
            registrationPage.Open()
                .EnterEmail(email)
                .EnterPassword(password)
                .EnterConfirmPasswors(confirmPassword)
                .ClickRegister();

            Assert.That(registrationPage.ErrorText(), Is.EqualTo(""));
        }

    }
}