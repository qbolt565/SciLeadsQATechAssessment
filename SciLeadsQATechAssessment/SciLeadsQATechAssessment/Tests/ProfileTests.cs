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

            Assert.That(profilePage.SuccessMessageText, Is.EqualTo("Your profile has been updated"));
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

            Assert.That(profilePage.SuccessMessageText(), Is.EqualTo("Confirmation link to change email sent. Please check your email."));

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

            Assert.That(profilePage.SuccessMessageText(), Is.EqualTo("Your email is unchanged."));
        }


    }
}
