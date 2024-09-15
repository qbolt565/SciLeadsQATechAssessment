using SciLeadsQATechAssessment.Tests.UI.Models;
using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
{
    public class ProfileTests : TestBase
    {
        [Test]
        public void ManageAccountProfile_EnterValidPhoneNumberAndSave_SaveSuccessful()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectProfileTab()
                .EnterPhoneNumber("07837405668")
                .ClickSave();

            Assert.That(profilePage.SuccessAlertMessageText, Is.EqualTo("Your profile has been updated"));
        }

        [Test]
        public void ManageAccountProfile_EnterInvalidPhoneNumberAndSave_ErrorDisplayed()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectProfileTab()
                .EnterPhoneNumber("abc")
                .ClickSave();

            Assert.Multiple(() => {
                Assert.That(profilePage.SummaryErrorText, Does.EndWith("The Phone number field is not a valid phone number."));
                Assert.That(profilePage.PhoneNumberErrorText, Is.EqualTo("The Phone number field is not a valid phone number."));
            });
        }

        [Test]
        public void ManageAccountEmail_EnterValidEmailButDoNotConfirm_EmailINotUpdated()
        {
            User uniqueUser = TestDataUtils.GetTestUser();
            Workflows.CreateNewUser(uniqueUser);
            Workflows.LoginAs(uniqueUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(uniqueUser.Email)
                .SelectEmailTab()
                .EnterNewEmail(TestDataUtils.GetTestEmail())
                .ClickChangeEmail();

            Assert.That(profilePage.SuccessAlertMessageText(), Is.EqualTo("Confirmation link to change email sent. Please check your email."));

            NavigationPane navigationPane = new(WebApp.Driver);
            navigationPane.Logout();
            Workflows.LoginAs(uniqueUser);

            HomePage homePage = new(WebApp.Driver);
            Assert.That(homePage.IsDisplayed(), "Login with original credentials failed.");
        }

        [Test]
        public void ManageAccountEmail_EnterInvalidEmail_ErrorDisplayed()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectEmailTab()
                .EnterNewEmail("NotAnEmail")
                .ClickChangeEmail();

            Assert.Multiple(() => {
                Assert.That(profilePage.SummaryErrorText, Does.EndWith("The New email field is not a valid e-mail address."));
                Assert.That(profilePage.NewEmailErrorText, Is.EqualTo("The New email field is not a valid e-mail address."));
            });
        }

        [Test]
        public void ManageAccountEmail_NewEmailSameAsCurrent_AlertDisplayed()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectEmailTab()
                .EnterNewEmail(KnownUser.Email)
                .ClickChangeEmail();

            Assert.That(profilePage.SuccessAlertMessageText(), Is.EqualTo("Your email is unchanged."));
        }

        [Test]
        public void ManageAccountPassword_OldPasswordValidAndNewPasswordMatchAndDifferentFromLastPassword_PasswordUpdated()
        {
            string newPassword = "NewP@33word";
            User uniqueUser = TestDataUtils.GetTestUser();
            Workflows.CreateNewUser(uniqueUser);
            Workflows.LoginAs(uniqueUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(uniqueUser.Email)
                .SelectPasswordTab()
                .EnterOldPassword(uniqueUser.Password)
                .EnterNewPassword(newPassword)
                .EnterConfirmPassword(newPassword)
                .ClickUpdatePassword();

            Assert.That(profilePage.SuccessAlertMessageText, Is.EqualTo("Your password has been changed"));

            NavigationPane navigationPane = new(WebApp.Driver);
            navigationPane.Logout();

            LoginPage loginPage = new(WebApp.Driver);   
            loginPage.Open()
                .EnterEmail(uniqueUser.Email)
                .EnterPassword(newPassword)
                .ClickLogin();

            HomePage homePage = new(WebApp.Driver);
            Assert.That(homePage.IsDisplayed(), "Login with original credentials failed.");
        }

        [TestCase("P@33wor", "The New password must be at least 8 and at max 100 characters long.", TestName = "New password that is too short.")]
        [TestCase("yR4yUS.YbG-#%U)kLf}$QaZRJ(2qhF7Z}JUD_gy[]mH4uPR$FTeHfN4TG(NyU)3rp]$86*TnD_Cd)kefX-3;-(xZyT}Mn]e0R@u&A", "The New password must be at least 8 and at max 100 characters long.", TestName = "New password that is too long.")]
        public void ManageAccountPassword_OldPasswordValidAndNewPasswordsMatchButDoNotConformToLengthRequirements_ErrorDisplayed(string newPassword, string error)
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectPasswordTab()
                .EnterOldPassword(KnownUser.Password)
                .EnterNewPassword(newPassword)
                .EnterConfirmPassword(newPassword)
                .ClickUpdatePassword();

            Assert.Multiple(() =>
            {
                Assert.That(profilePage.NewPasswordErrorText, Is.EqualTo(error));
                Assert.That(profilePage.SummaryErrorText(), Does.EndWith(error));
            });
        }

        [TestCase("p@33word", "Error: Passwords must have at least one uppercase ('A'-'Z').", TestName = "New password that is all in a single case.")]
        [TestCase("1234567!", "Error: Passwords must have at least one lowercase ('a'-'z').,Passwords must have at least one uppercase ('A'-'Z').", TestName = "New pasword that has no alphabetic characters.")]
        [TestCase("P@ssword", "Error: Passwords must have at least one digit ('0'-'9').", TestName = "New password with no numbers.")]
        [TestCase("Pas33word", "Error: Passwords must have at least one non alphanumeric character.", TestName = "New password with no symbols.")]
        public void ManageAccountPassword_OldPasswordValidAndNewPasswordsMatchButDoNotHaveCorrectCharacters_ErrorDisplayed(string newPassword, string error)
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectPasswordTab()
                .EnterOldPassword(KnownUser.Password)
                .EnterNewPassword(newPassword)
                .EnterConfirmPassword(newPassword)
                .ClickUpdatePassword();

            Assert.That(profilePage.ErrorAlertMessageText, Is.EqualTo(error));
        }

        [Test]
        public void ManageAccountPassword_OldPasswordValidAndNewPasswordsDoNotMatch_ErrorDisplayed()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectPasswordTab()
                .EnterOldPassword(KnownUser.Password)
                .EnterNewPassword("NewP@33word")
                .EnterConfirmPassword("NotNewP@33word")
                .ClickUpdatePassword();

            Assert.Multiple(() =>
            {
                Assert.That(profilePage.ConfirmPasswordErrorText(), Is.EqualTo("The new password and confirmation password do not match."));
                Assert.That(profilePage.SummaryErrorText(), Does.EndWith("The new password and confirmation password do not match."));
            });
        }

        [Test]
        public void ManageAccountPassword_OldPasswordWrongAndNewPasswordMatch_ErrorDisplayed()
        {
            Workflows.LoginAs(KnownUser);

            ProfilePage profilePage = new(WebApp.Driver);
            profilePage.Open(KnownUser.Email)
                .SelectPasswordTab()
                .EnterOldPassword("NotP@33word")
                .EnterNewPassword("NewP@33word")
                .EnterConfirmPassword("NewP@33word")
                .ClickUpdatePassword();

            Assert.That(profilePage.ErrorAlertMessageText, Is.EqualTo("Error: Incorrect password."));
        }

    }
}
