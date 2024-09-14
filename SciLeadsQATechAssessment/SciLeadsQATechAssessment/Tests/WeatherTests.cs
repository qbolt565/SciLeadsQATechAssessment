using SciLeadsQATechAssessment.Models;
using SciLeadsQATechAssessment.PageObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests
{
    public class WeatherTests : TestBase
    {
        [Test]
        public void WeatherPage_UserLoggedIn_WeatherTableDisplayedAndValuesCalculatedCorrectly()
        {
            List<DateTime> expectedWeatherDataDates =
            [
                new DateTime(2024,9,15),
                new DateTime(2024,9,16),
                new DateTime(2024,9,17),
                new DateTime(2024,9,18),
                new DateTime(2024,9,19)
            ];

            LoginPage loginPage = new(WebApp.Driver);
            loginPage.Open()
                .EnterEmail(KnownUser.Email)
                .EnterPassword(KnownUser.Password)
                .ClickLogin();

            WeatherPage weatherPage = new(WebApp.Driver);
            weatherPage.Open();
            var weatherDataDates = weatherPage.GetTable().Select(w => w.Date);
            
            CollectionAssert.AreEquivalent(expectedWeatherDataDates, weatherDataDates, "Displayed weather table dates does not match expected.");
        }

        [Test]
        public void WeatherPage_UserNotLoggedIn_RedirectedToLoginPage()
        {
            WeatherPage weatherPage = new(WebApp.Driver);
            weatherPage.Open(isLoggedIn: false);
            
            LoginPage loginPage = new(WebApp.Driver);
            Assert.That(loginPage.IsDisplayed(), "Login page was not displayed when attempting to view Counter page while not logged in.");
        }


    }
}
