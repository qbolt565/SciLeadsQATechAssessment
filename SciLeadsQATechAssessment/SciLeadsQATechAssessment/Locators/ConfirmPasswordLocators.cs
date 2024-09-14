using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests.UI.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Confirm Password page.
    /// </summary>
    public class ConfirmPasswordLocators
    {
        public static By Header => By.XPath("//h1[text()='Confirm email']");
    }
}
