using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Navigator pane
    /// </summary>
    public class ProfileLocators
    {
        public static By Header => By.XPath("//h1[text()='Manage your account']");
        public static By ProfileTab => NavItemLocator("Profile");
        public static By ProfileHeader => By.XPath("//h3[text()='Profile']");
        public static By EmailTab => NavItemLocator("Email");
        public static By PasswordTab => NavItemLocator("Password");
        public static By UsernameInput => By.XPath("//label[@for='username']/../input");
        public static By PhoneNumberInput => By.Name("Input.PhoneNumber");
        public static By SaveButton => ButtonLocator("Save");
        public static By SummaryErrorText => By.XPath("//ul[@class='text-danger']");
        public static By SuccessAlert => By.XPath("//div[@class='alert alert-success']");
        public static By ManageEmailHeader => By.XPath("//h3[text()='Manage email']");
        public static By PhoneNumberError => InputErrorLocator("Input.PhoneNumber");
        public static By EmailInput => By.XPath("//label[@for='email']/../input");
        public static By NewEmailInput => By.Name("Input.NewEmail");
        public static By ChangeEmailButton => ButtonLocator("Change email");
        public static By NewEmailError => InputErrorLocator("Input.NewEmail");
        public static By ChangePasswordHeader => By.XPath("//h3[text()='Change password']");
        public static By OldPasswordInput => By.Name("Input.OldPassword");
        public static By NewPasswordInput => By.Name("Input.NewPassword");
        public static By ConfirmPasswordInput => By.Name("Input.ConfirmPassword");
        public static By UpdatePasswordButton => ButtonLocator("Update password");
        public static By OldPasswordError => InputErrorLocator("Input.OldPassword");
        public static By NewPasswordError => InputErrorLocator("Input.NewPassword");
        public static By ConfirmPasswordError => InputErrorLocator("Input.ConfirmPassword");

        private static By NavItemLocator(string itemName)
        {
            return By.XPath($"//ul[@class='nav nav-pills flex-column']//a[contains(text(),'{itemName}')]");
        }

        private static By InputErrorLocator(string inputName)
        {
            return By.XPath($"//input[@name='{inputName}']/../div[@class='text-danger']");
        }

        private static By ButtonLocator(string buttonName) 
        {
            return By.XPath($"//button[text()='{buttonName}']");
        }
    }
}
