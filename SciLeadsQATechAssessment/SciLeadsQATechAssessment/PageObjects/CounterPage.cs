using OpenQA.Selenium;
using SciLeadsQATechAssessment.Locators;
using SciLeadsQATechAssessment.Support;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Counter page.
    /// </summary>
    public class CounterPage
    {
        private IWebDriver _driver;

        public CounterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(CounterLocators.Header, "Is Counter page displayed?");
        }

        /// <summary>
        /// Clicks the Increment button on the counter page.
        /// </summary>
        /// <returns>The same instance of <see cref="CounterPage"/></returns>
        public CounterPage ClickIncrement() 
        {
            int initialCount = CurrentCount();
            _driver.LogClick(CounterLocators.IncrementButton, "Click the Increment button.");
            _driver.WaitForPageToLoad();
            _driver.WaitUntil(() => initialCount != CurrentCount());
            return this;
        }

        /// <summary>
        /// Clicks the Increment button the given number of times.
        /// </summary>
        /// <param name="n">Number of time to click increment button.</param>
        /// <returns>The same instance of <see cref="CounterPage"/>.</returns>
        public CounterPage ClickIncrementNTimes(int n)
        {
            for (int i = 0; i < n; i++)
            { 
                ClickIncrement();
            }
            return this;
        }

        /// <summary>
        /// Returns the Current count value.
        /// </summary>
        /// <returns>Current count.</returns>
        public int CurrentCount()
        {
            string counterText = _driver.LogReadText(CounterLocators.CurrentCount, "Get the current counter text.");

            return Convert.ToInt32(counterText.Replace("Current count: ", ""));
        }

        /// <summary>
        /// Opens the counter page from the Navigation pane.
        /// </summary>
        /// <param name="isLoggedIn">After selecting conter from navigation bar, if isLoggedIn is true will wait until counter page
        /// is displayed, otherwise will wait until login page is displayed.</param>
        /// <returns>The same instance of <see cref="CounterPage"/>.</returns>
        public CounterPage Open(bool isLoggedIn = true)
        {
            NavigationPane navigationPane = new(_driver);
            navigationPane.Open().Counter();

            if (isLoggedIn)
            {
                _driver.WaitUntil(IsDisplayed);
                Thread.Sleep(1000);
            }
            else
            { 
                LoginPage loginPage = new(_driver);
                _driver.WaitUntil(loginPage.IsDisplayed);
            }

            _driver.WaitForPageToLoad();

            return this;
        }
    }
}
