using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Login page.
    /// </summary>
    public class LoginLocators
    {
        public static By Header => By.XPath("//h1[text()='Log in']");
        public static By EmailInput => By.Name("Input.Email");
        public static By PasswordInput => By.Name("Input.Password");
        public static By LoginButton => By.XPath("//button[text()=\"Log in\"]");
        public static By ForgotPasswordLink => By.LinkText("Forgot your password?");
        public static By RegisterNewUserLink => By.LinkText("Register as a new user");
        public static By ResendEmailConfirmationLink => By.LinkText("Resend email confirmation");
        public static By Alert => By.XPath("//div[@class='alert alert-danger']");
        public static By ErrorList => By.XPath("//form/ul[@class='text-danger']");
        public static By EmailInputError => By.XPath("//input[@name='Input.Email']/../div[@class='text-danger']");
        public static By PasswordInputError => By.XPath("//input[@name='Input.Password']/../div[@class='text-danger']");
    }
}
