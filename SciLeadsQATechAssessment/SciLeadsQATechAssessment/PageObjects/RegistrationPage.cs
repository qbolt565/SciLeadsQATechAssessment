﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Registration page.
    /// </summary>
    public class RegistrationPage
    {
        private IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
        }
        
        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(RegistrationLocators.Header, "Check Registration page is displayed.");
        }

        /// <summary>
        /// Click the register button.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public RegistrationPage ClickRegister()
        {
            _driver.LogClick(RegistrationLocators.RegisterButton, "Click Register button");
            return this;
        }

        /// <summary>
        /// Enter the supplied text into the Confirm Password field.
        /// </summary>
        /// <param name="password">Text to be entered into Confirm Password field.</param>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public RegistrationPage EnterConfirmPassword(string password)
        {
            _driver.LogSendText(RegistrationLocators.ConfirmPasswordInput, password, $"Enter {password} into Confirm Password field.");
            return this;
        }

        /// <summary>
        /// Enter the supplied text into the Email field.
        /// </summary>
        /// <param name="email">Text to be entered into Email field.</param>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public RegistrationPage EnterEmail(string email)
        {
            _driver.LogSendText(RegistrationLocators.EmailInput, email, $"Enter {email} into Email field.");
            return this;
        }

        /// <summary>
        /// Enter the supplied text into the Password field.
        /// </summary>
        /// <param name="password">Text to be entered into Password field.</param>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public RegistrationPage EnterPassword(string password)
        {
            _driver.LogSendText(RegistrationLocators.PasswordInput, password, $"Enter {password} into Password field.");
            return this;
        }

        /// <summary>
        /// Returns the summary error text at the top of the page.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public string SummaryErrorText()
        {
            return _driver.LogReadText(RegistrationLocators.ErrorList, "Get the text displayed in the summary error section at the top of the page.");
        }

        /// <summary>
        /// Returns the error next to the email field.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public string EmailErrorText()
        {
            return _driver.LogReadText(RegistrationLocators.EmailInputError, "Get the text displayed next to the email error.");
        }

        /// <summary>
        /// Returns the error next to the password field.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public string PasswordErrorText()
        {
            return _driver.LogReadText(RegistrationLocators.PasswordInputError, "Get the text displayed next to the password error.");
        }



        /// <summary>
        /// Returns the error next to the confirm password field.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        public string PasswordConfirmErrorText()
        {
            return _driver.LogReadText(RegistrationLocators.ConfirmPasswordInput, "Get the text displayed next to the cofirm password error.");
        }

        /// <summary>
        /// Opens the registration page from the Navigation pane.
        /// </summary>
        /// <returns>Returns the same instance of the Registration page.</returns>
        internal RegistrationPage Open()
        {
            NavigationPane navigationPane = new NavigationPane(_driver);
            navigationPane.Open().Register();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_ => IsDisplayed());
            
            return this;
        }
    }
}