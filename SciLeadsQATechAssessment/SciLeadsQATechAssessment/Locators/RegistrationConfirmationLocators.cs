using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Registration Confirmation page.
    /// </summary>
    public class RegistrationConfirmationLocators
    {
        public static By Header => By.XPath("//h1[text()='Register confirmation']");
        public static By ConfirmLink => By.LinkText("Click here to confirm your account");
    }
}
