using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with the Profile page.
    /// </summary>
    public class ProfilePage
    {
        private IWebDriver _driver;

        public ProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ProfileLocators.Header, "Check Profile page is displayed.");
        }


        /// <summary>
        /// Opens the profile page from the Navigation pane.
        /// </summary>
        /// <param name="usermEmail">The user email that is displayed n the navigation pane</param>
        /// <returns>Returns the same instance of the <see cref="ProfilePage"/>.</returns>
        public ProfilePage Open(string usermEmail)
        {
            NavigationPane navigationPane = new NavigationPane(_driver);
            navigationPane.Open().UserPorfile(usermEmail);

            _driver.WaitUntil(IsDisplayed);

            return this;
        }

        /// <summary>
        /// Selects the Profile tab.
        /// </summary>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage SelectProfileTab()
        {
            _driver.LogClick(ProfileLocators.ProfileTab, "Select Profile tab.");
            _driver.WaitUntil(() => _driver.IsDisplayed(ProfileLocators.ProfileHeader, "Check Profile tab header is displayed."));
            return this;
        }

        /// <summary>
        /// Selects the Email tab.
        /// </summary>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage SelectEmailTab()
        {
            _driver.LogClick(ProfileLocators.EmailTab, "Select Email tab.");
            _driver.WaitUntil(() => _driver.IsDisplayed(ProfileLocators.ManageEmailHeader, "Check Manage Email tab header is displayed."));
            return this;
        }

        /// <summary>
        /// Selects the Password tab.
        /// </summary>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage SelectPasswordTab()
        {
            _driver.LogClick(ProfileLocators.PasswordTab, "Select Password tab.");
            _driver.WaitUntil(() => _driver.IsDisplayed(ProfileLocators.ChangePasswordHeader, "Check Change password tab header is displayed."));
            return this;
        }

        /// <summary>
        /// Enters the text into the Phone Number field.
        /// </summary>
        /// <param name="phoneNumber">Text to enter into field</param>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage EnterPhoneNumber(string phoneNumber)
        {
            _driver.LogSendText(ProfileLocators.PhoneNumberInput, phoneNumber, $"Enter {phoneNumber} into Phone number field.");
            return this;
        }

        /// <summary>
        /// Clicks the Save button.
        /// </summary>
        public void ClickSave()
        {
            _driver.LogClick(ProfileLocators.SaveButton, "Click the Save button.");
        }

        /// <summary>
        /// Returns the text displayed in the success alert.
        /// </summary>
        /// <returns>Success message text.</returns>
        public string SuccessAlertMessageText()
        {
            return _driver.LogReadText(ProfileLocators.SuccessAlert, "Read text shown in success alert.");
        }

        /// <summary>
        /// Returns the text displayed in the error alert.
        /// </summary>
        /// <returns>Error message text.</returns>
        public string ErrorAlertMessageText()
        {
            return _driver.LogReadText(ProfileLocators.ErrorAlert, "Read text shown in error alert.");
        }

        /// <summary>
        /// Returns the summary error text.
        /// </summary>
        /// <returns>Summary error text.</returns>
        public string SummaryErrorText()
        {
            return _driver.LogReadText(ProfileLocators.SummaryErrorText, "Read text shown in error summary.");
        }

        /// <summary>
        /// Returns the phone number error text.
        /// </summary>
        /// <returns>Phone number error text.</returns>
        public string PhoneNumberErrorText()
        {
            return _driver.LogReadText(ProfileLocators.PhoneNumberError, "Read error text shown next to the Phone number input.");
        }

        /// <summary>
        /// Enters the text into the Email field.
        /// </summary>
        /// <param name="email">Text to enter into field.</param>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage EnterNewEmail(string email)
        {
            _driver.LogSendText(ProfileLocators.NewEmailInput, email, $"Enter {email} into New Email field.");
            return this;
        }

        /// <summary>
        /// Clicks the Change email button.
        /// </summary>
        public void ClickChangeEmail()
        {
            _driver.LogClick(ProfileLocators.ChangeEmailButton, "Click the Change email button.");
        }

        /// <summary>
        /// Returns the new email error text.
        /// </summary>
        /// <returns>New Email error text.</returns>
        public string NewEmailErrorText()
        {
            return _driver.LogReadText(ProfileLocators.NewEmailError, "Read error text shown next to the New email input.");
        }

        /// <summary>
        /// Enters the text into the Old Password field.
        /// </summary>
        /// <param name="password">Text to enter into field.</param>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage EnterOldPassword(string password)
        {
            _driver.LogSendText(ProfileLocators.OldPasswordInput, password, $"Enter {password} into Old Password field.");
            return this;
        }

        /// <summary>
        /// Enters the text into the New Password field.
        /// </summary>
        /// <param name="password">Text to enter into field.</param>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage EnterNewPassword(string password)
        {
            _driver.LogSendText(ProfileLocators.NewPasswordInput, password, $"Enter {password} into New Password field.");
            return this;
        }

        /// <summary>
        /// Enters the text into the Confirm Password field.
        /// </summary>
        /// <param name="password">Text to enter into field.</param>
        /// <returns>The same instance of <see cref="ProfilePage"/>.</returns>
        public ProfilePage EnterConfirmPassword(string password)
        {
            _driver.LogSendText(ProfileLocators.ConfirmPasswordInput, password, $"Enter {password} into Confirm Password field.");
            return this;
        }

        /// <summary>
        /// Clicks the Update password button.
        /// </summary>
        public void ClickUpdatePassword()
        {
            _driver.LogClick(ProfileLocators.UpdatePasswordButton, "Click the Update password button.");
        }

        /// <summary>
        /// Returns the Old password error text.
        /// </summary>
        /// <returns>Old password error text.</returns>
        public string OldPasswordErrorText()
        {
            return _driver.LogReadText(ProfileLocators.OldPasswordError, "Read error text shown next to the Old password input.");
        }

        /// <summary>
        /// Returns the New password error text.
        /// </summary>
        /// <returns>New password error text.</returns>
        public string NewPasswordErrorText()
        {
            return _driver.LogReadText(ProfileLocators.NewPasswordError, "Read error text shown next to the New password input.");
        }

        /// <summary>
        /// Returns the Confirm password error text.
        /// </summary>
        /// <returns>Confirm password error text.</returns>
        public string ConfirmPasswordErrorText()
        {
            return _driver.LogReadText(ProfileLocators.ConfirmPasswordError, "Read error text shown next to the Confirm password input.");
        }
    }
}
