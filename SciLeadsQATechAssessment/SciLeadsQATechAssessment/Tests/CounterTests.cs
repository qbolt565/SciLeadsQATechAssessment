using SciLeadsQATechAssessment.Tests.UI.PageObjects;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
{
    public class CounterTests : TestBase
    {
        [Test]
        public void CounterPage_UserLoggedInClicksIncrementMultipleTimes_CounterValueReflectsNumberOfClicks()
        {
            Workflows.LoginAs(KnownUser);

            CounterPage counterPage = new(WebApp.Driver);
            counterPage.Open();

            for (int i = 0; i < 12; i++)
            {
                counterPage.ClickIncrement();
                Assert.That(counterPage.CurrentCount(), Is.EqualTo(i + 1), "Count did not update as expected when Increment button clicked.");
            } 
        }

        [Test]
        public void CounterPage_UserLoggedInClickIncrementThenChangePage_CounterValuePersists()
        {
            int targetCounterValue = 5;
            Workflows.LoginAs(KnownUser);

            CounterPage counterPage = new(WebApp.Driver);
            counterPage.Open()
                .ClickIncrementNTimes(targetCounterValue);

            Assert.That(counterPage.CurrentCount(), Is.EqualTo(targetCounterValue), "Counter value does not reflect the number of times the Increment button was clicked.");

            HomePage homePage = new(WebApp.Driver);
            homePage.Open();

            counterPage.Open();

            Assert.That(counterPage.CurrentCount(), Is.EqualTo(targetCounterValue), "Counter value did not retain value upon changing pages.");
        }

        [Test]
        public void CounterPage_UserLoggedInClickIncrementThenLogoutAndLogin_CounterValueResets()
        {
            int targetCounterValue = 5;
            Workflows.LoginAs(KnownUser);

            CounterPage counterPage = new(WebApp.Driver);
            counterPage.Open()
                .ClickIncrementNTimes(targetCounterValue);

            Assert.That(counterPage.CurrentCount(), Is.EqualTo(targetCounterValue), "Counter value does not reflect the number of times the Increment button was clicked.");

            NavigationPane navigationPane = new(WebApp.Driver);
            navigationPane.Open().Logout();

            Workflows.LoginAs(KnownUser);

            counterPage.Open();

            Assert.That(counterPage.CurrentCount(), Is.EqualTo(0), "Counter value did not reset to 0 upon log out.");
        }

        [Test]
        public void CounterPage_UserNotLoggedIn_RedirectedToLoginPage()
        {
            CounterPage counterPage = new(WebApp.Driver);
            counterPage.Open(isLoggedIn: false);

            LoginPage loginPage = new(WebApp.Driver);
            Assert.That(loginPage.IsDisplayed(), "Login page was not displayed when attempting to view Counter page while not logged in.");
        }

    }
}
