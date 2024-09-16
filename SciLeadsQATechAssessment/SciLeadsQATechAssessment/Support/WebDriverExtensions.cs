using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SciLeadsQATechAssessment.Tests.UI.Support
{
    /// <summary>
    /// Provides extensions for Selnium WebDriver.
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Performans a click on the given element and logs the given message.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element to be clicked.</param>
        /// <param name="logMessage">Message to be logged.</param>
        public static void LogClick(this IWebDriver driver, By locator, string logMessage)
        {
            Logger.Instance.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            new Actions(driver).MoveToElement(element);
            element.Click();
        }

        /// <summary>
        /// Clears content of the given controls and type in the given text.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator for the element that text will be sent to.</param>
        /// <param name="inputText">Text to send to the element.</param>
        /// <param name="logMessage">Message to be logged.</param>
        public static void LogSendText(this IWebDriver driver, By locator, string inputText, string logMessage)
        {
            Logger.Instance.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            element.Clear();
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
            Logger.Instance.LogInfo(logMessage);
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
            Logger.Instance.LogInfo(logMessage);
            int retryCount = 3;

            while (retryCount > 0)
            {
                try
                {
                    if (driver.TryFindElement(locator, out IWebElement element))
                    {
                        return element.Displayed;
                    }
                }
                catch (StaleElementReferenceException) 
                {
                    Logger.Instance.LogWarning($"Encountered StaleElementReferenceException attempting retry.  Attempts remaining:{retryCount}");
                    retryCount--;
                }
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

        /// <summary>
        /// Checks to see if the document readystate is true.
        /// </summary>
        /// <param name="driver"></param>
        public static bool IsPageLoaded(this IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }

        /// <summary>
        /// Wait until the document readystate is true.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="timeout">Maximum number of seconds to wait before wait ends.</param>

        public static void WaitForPageToLoad(this IWebDriver driver, int timeout = 10)
        {
            Logger.Instance.LogInfo("Wait for page to load");
            driver.WaitUntil(driver.IsPageLoaded);
        }

        /// <summary>
        /// Reads all td tag text from a table and stored it.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Location of the table.</param>
        /// <returns>Nested lsit representing the rows of the table and their data.</returns>
        public static List<List<string>> LoadTable(this IWebDriver driver, By locator)
        { 
            Logger.Instance.LogInfo($"Load table");

            List<List<string>> table = [];

            driver.WaitUntil(() => driver.IsDisplayed(locator, "Check table is displayed."));
            driver.WaitUntil(() => driver.TableRowCount(locator) > 0);

            IWebElement tableElement = driver.FindElement(locator);
            var rowElements = tableElement.FindElements(By.XPath("./tbody/tr"));
            
            foreach (var rowElement in rowElements)
            {
                List<string> row = [];
                var dataElements = rowElement.FindElements(By.XPath("./td"));
             
                foreach (var dataElement in dataElements)
                {
                    row.Add(dataElement.Text);
                }

                table.Add(row);            
            }

            return table;
        }

        /// <summary>
        /// Returns the count of rows in a table.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator">Locator specifying how to find table.</param>
        /// <returns>Number of rows in table.</returns>
        public static int TableRowCount(this IWebDriver driver, By locator)
        {
            Logger.Instance.LogInfo("Get table row count");
            IWebElement table = driver.FindElement(locator);
            return table.FindElements(By.XPath("./tbody/tr")).Count;
        }

        /// <summary>
        /// Returns a list of the titles for all currently open tabs.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>List of the titles for all currently open tabs</returns>
        public static IList<string> BrowserTabTitles(this IWebDriver driver)
        {
            Logger.Instance.LogInfo($"Check the titles of all currently open browser tabs.");

            List<string> tabTitles = [];

            IList<string> windowHandles = new List<string>(driver.WindowHandles);

            foreach (var windowHandle in windowHandles)
            { 
                driver.SwitchTo().Window(windowHandle);
                tabTitles.Add(driver.Title);
            }

            return tabTitles;
        }

    }
}
