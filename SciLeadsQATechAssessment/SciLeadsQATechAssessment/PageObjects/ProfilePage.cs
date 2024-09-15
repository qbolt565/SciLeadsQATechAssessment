using Bogus.DataSets;
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
        /// <returns>Returns the same instance of the Login page.</returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(ProfileLocators.Header, "Check Profile page is displayed.");
        }


        /// <summary>
        /// Opens the profile page from the Navigation pane.
        /// </summary>
        /// <param name="usermEmail">The user email that is displayed n the navigation pane</param>
        /// <returns></returns>
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
            _driver.LogClick(ProfileLocators.SaveButton, "Click the Save button");
        }

        /// <summary>
        /// Returns the text displayed in the success alert.
        /// </summary>
        /// <returns>Success message text.</returns>
        public string SuccessMessageText()
        {
            return _driver.LogReadText(ProfileLocators.SuccessAlert, "Read text shown in success alert.");
        }

        /// <summary>
        /// Returns the summary error text.
        /// </summary>
        /// <returns>Summary error text.</returns>
        public string SummaryErrorText()
        {
            return _driver.LogReadText(ProfileLocators.SummaryErrorText, "Read error text shown in error summary.");
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
            _driver.LogClick(ProfileLocators.ChangeEmailButton, "Click the Change email button");
        }

        /// <summary>
        /// Returns the new email error text.
        /// </summary>
        /// <returns>New Email error text.</returns>
        public string NewEmailErrorText()
        {
            return _driver.LogReadText(ProfileLocators.NewEmailError, "Read error text shown next to the New email input.");
        }
    }
}
