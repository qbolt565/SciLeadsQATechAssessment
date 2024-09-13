using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Support
{
    /// <summary>
    /// Provides extensions for Selnium WebDriver.
    /// </summary>
    public static class WebDriverExtensions
    {
        private static Logger log = new Logger();

        /// <summary>
        /// Performans a click on the given element and logs the given message.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element to be clicked.</param>
        /// <param name="logMessage">Message to be logged.</param>
        public static void LogClick(this IWebDriver driver, By locator, string logMessage)
        {
            log.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            element.Click();
        }

        /// <summary>
        /// Performs a click on the given element and logs the given message.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element that text will be sent to.</param>
        /// <param name="inputText">Text to send to the element.</param>
        /// <param name="logMessage">Message to be logged.</param>
        public static void LogSendText(this IWebDriver driver, By locator, string inputText, string logMessage)
        {
            log.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            element.SendKeys(inputText);
        }

        /// <summary>
        /// Reads the inner text of the element.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element that text will be read from.</param>
        /// <param name="logMessage">Message to be logged.</param>
        /// <returns>Inner text of the element.</returns>
        public static string LogReadText(this IWebDriver driver, By locator, string logMessage)
        {
            log.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            return element.Text;    
        }

        /// <summary>
        /// Checks if the element specified by the locator is displayed.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element to be checked.</param>
        /// <param name="logMessage">Message to be logged.</param>
        /// <returns>True if element is displayed.</returns>
        public static bool IsDisplayed(this IWebDriver driver, By locator, string logMessage)
        {
            log.LogInfo(logMessage);

            if (driver.TryFindElement(locator, out IWebElement element))
            {
                return element.Displayed;
            }

            return false;
        }

        /// <summary>
        /// Attempts to find the element using the provided locator.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element to searc for.</param>
        /// <param name="element">If a matching element is returned this is returned.  If there are more than one match return the first match.</param>
        /// <returns>True if a match is found.</returns>
        public static bool TryFindElement(this IWebDriver driver, By locator, out IWebElement? element)
        {
            var foundElements = driver.FindElements(locator);

            if (foundElements.Any()) 
            { 
                element = foundElements.First();
                return true;
            }

            element = null;
            return false;
        }

        /// <summary>
        /// Waits until the given condition is met or the timeout is reached.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="condition">Condition to wait until valid.</param>
        /// <param name="timeout">Maximum number of seconds to wait before wait ends.</param>
        public static void WaitUntil(this IWebDriver driver, Func<bool> condition, int timeout = 5)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(_ => condition());
        }
    }
}
