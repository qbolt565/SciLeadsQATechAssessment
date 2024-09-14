using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Locators
{
    /// <summary>
    /// Provides locators for all elements contained within the Navigator pane
    /// </summary>
    public class NavigationPaneLocators
    {
        public static By Home => NavItemLocator("Home");
        public static By Counter => NavItemLocator("Counter");
        public static By Weather => NavItemLocator("Weather");
        public static By Register => NavItemLocator("Register");
        public static By Login => NavItemLocator("Login");
        public static By Logout => By.XPath("//nav//button[contains(text(),'Logout')]");

        /// <summary>
        /// Provides the locator for the tab for accessing the users profile
        /// </summary>
        /// <param name="userEmail">Users email address</param>
        /// <returns>Locator for user profile nav item</returns>
        public static By UserProfile(string userEmail)
        { 
            return NavItemLocator(userEmail);
        }

        private static By NavItemLocator(string itemName)
        {
            return By.XPath($"//nav//a[contains(text(),'{itemName}')]");
        }
    }
}
