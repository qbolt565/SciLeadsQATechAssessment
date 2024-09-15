using OpenQA.Selenium;
using SciLeadsQATechAssessment.Tests.UI.Locators;
using SciLeadsQATechAssessment.Tests.UI.Models;
using SciLeadsQATechAssessment.Tests.UI.Support;
using System.Globalization;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Page object for managing interations with Weather page.
    /// </summary>
    public class WeatherPage
    {
        private IWebDriver _driver;

        public WeatherPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Returns true if the page is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayed()
        {
            return _driver.IsDisplayed(WeatherLocators.Header, "Is Weather page displayed?");
        }

        /// <summary>
        /// Returns the data shown in the table.
        /// </summary>
        /// <returns>Weather data.</returns>
        public IEnumerable<WeatherItem> GetTable()
        {
            List<WeatherItem> weatherItems = [];

            var tableData = _driver.LoadTable(WeatherLocators.WeatherTable);

            foreach (var item in tableData)
            {
                WeatherItem weatherItem = new() 
                { 
                    Date = DateTime.ParseExact(item[0], "M/dd/yyyy", CultureInfo.InvariantCulture),
                    TempCelcius = Convert.ToInt32(item[1]),
                    TempFahrenheit = Convert.ToInt32(item[2]),
                    Summary = item[3]
                };

                weatherItems.Add(weatherItem);
            }

            return weatherItems;
        }

        /// <summary>
        /// Opens the Weather page from the Navigation pane.
        /// </summary>
        /// <param name="isLoggedIn">After selecting conter from navigation bar, if isLoggedIn is true 
        /// will wait until Weather page is displayed, otherwise will wait until login page is displayed.</param>
        /// <returns>The same instance of <see cref="WeatherPage"/>.</returns>
        public WeatherPage Open(bool isLoggedIn = true)
        {
            NavigationPane navigationPane = new(_driver);
            navigationPane.Open().Weather();

            if (isLoggedIn)
            {
                _driver.WaitUntil(IsDisplayed);
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
