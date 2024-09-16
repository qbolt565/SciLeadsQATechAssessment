using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using System.Data;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
{
    public class WeatherTests : TestBase
    {
        [Test]
        public void WeatherPage_UserLoggedIn_WeatherTableDisplayedAndValuesCalculatedCorrectly()
        {
            List<DateTime> expectedWeatherDataDates =
            [
                DateTime.Today.AddDays(5),
                DateTime.Today.AddDays(4),
                DateTime.Today.AddDays(3),
                DateTime.Today.AddDays(2),
                DateTime.Today.AddDays(1)
            ];

            Workflows.LoginAs(KnownUser);

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
