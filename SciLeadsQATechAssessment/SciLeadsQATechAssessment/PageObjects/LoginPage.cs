using OpenQA.Selenium;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with the Login page.
    /// </summary>
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns>Returns the same instance of the Login page.</returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(LoginLocators.Header, "Check Login page is displayed.");
        }

        /// <summary>
        /// Click the Login button.
        /// </summary>
        /// <param name="waitForHomepageToOpen">If true the test will pause the execution until the Home page is displayed.</param>
        public void ClickLogin(bool waitForHomepageToOpen = true)
        {
            _driver.LogClick(LoginLocators.LoginButton, "Click the login button.");

            if (waitForHomepageToOpen)
            {
                HomePage homePage = new(_driver);
                _driver.WaitUntil(homePage.IsDisplayed);
            }
        }

        /// <summary>
        /// Enter the given text into the password input.
        /// </summary>
        /// <param name="password">Text to enter into the password input.</param>
        /// <returns>Returns the same instance of the Login page.</returns>
        public LoginPage EnterPassword(string password)
        {
            _driver.LogSendText(LoginLocators.PasswordInput, password, $"Enter {password} into the password field."); 
            return this;
        }

        /// <summary>
        /// Enter the given text into the email input.
        /// </summary>
        /// <param name="password">Text to enter into the email input.</param>
        /// <returns>Returns the same instance of the Login page.</returns>
        public LoginPage EnterEmail(string email)
        {
            _driver.LogSendText(LoginLocators.EmailInput, email, $"Enter {email} into the email field.");
            return this;
        }

        /// <summary>
        /// Returns the summary error text at the top of the page.
        /// </summary>
        /// <returns>Error text.</returns>
        public string SummaryErrorText()
        {
            return _driver.LogReadText(LoginLocators.ErrorList, "Get the text displayed in the summary error section at the top of the page.");
        }

        /// <summary>
        /// Returns the error next to the email input.
        /// </summary>
        /// <returns>Error text.</returns>
        public string EmailErrorText()
        {
            return _driver.LogReadText(LoginLocators.EmailInputError, "Get the error text displayed next to the email input.");
        }

        /// <summary>
        /// Returns the error next to the password input.
        /// </summary>
        /// <returns>Error text.</returns>
        public string PasswordErrorText()
        {
            return _driver.LogReadText(LoginLocators.PasswordInputError, "Get the error text displayed next to the password input.");
        }

        /// <summary>
        /// Returns the text displayed in the displayed alert.
        /// </summary>
        /// <returns>Error text.</returns>
        public string AlertText()
        {
            _driver.WaitUntil(() => _driver.IsDisplayed(RegistrationLocators.Alert, "Check alert is displayed."));
            return _driver.LogReadText(LoginLocators.Alert, "Get the text displayed in the error box.");
        }

        /// <summary>
        /// Clicks the Forgot your password link
        /// </summary>
        /// <returns></returns>
        public void ClickForgotYourPassword()
        {
            _driver.LogClick(LoginLocators.ForgotPasswordLink, "Click Forgot your password link");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clicks the Register as a new user link
        /// </summary>
        public void ClickRegisterAsANewUser()
        {
            _driver.LogClick(LoginLocators.RegisterNewUserLink, "Click Register as a new user link");

            RegistrationPage registrationPage = new(_driver);
            _driver.WaitUntil(registrationPage.IsDisplayed);
        }

        /// <summary>
        /// Clicks the Resend email confirmation link
        /// </summary>
        public void ClickResendEmailConfirmationLink()
        {
            _driver.LogClick(LoginLocators.RegisterNewUserLink, "Click Resend email confirmation link");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens the login page from the Navigation pane.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public LoginPage Open()
        {
            NavigationPane navigationPane = new NavigationPane(_driver);
            navigationPane.Open().Login();

            _driver.WaitUntil(IsDisplayed);

            return this;
        }
    }
}