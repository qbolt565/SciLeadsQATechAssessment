using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Locators
{
    public class RegistrationLocators
    {
        public static By Header => By.XPath("//h1[text()='Register']");
        public static By EmailInput => By.Name("Input.Email");
        public static By PasswordInput => By.Name("Input.Password");
        public static By ConfirmPasswordInput => By.Name("Input.ConfirmPassword");
        public static By RegisterButton => By.XPath("//button[text()=\"Register\"]");
        public static By ErrorList => By.XPath("//form/ul[@class='text-danger']");
        public static By EmailInputError => By.XPath("//input[@name='Input.Email']/../div[@class='text-danger']");
        public static By PasswordInputError => By.XPath("//input[@name='Input.Password']/../div[@class='text-danger']");

    }
}
