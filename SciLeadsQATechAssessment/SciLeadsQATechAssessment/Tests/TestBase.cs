using SciLeadsQATechAssessment.Tests.UI.Models;
using SciLeadsQATechAssessment.Tests.UI.PageObjects;
using SciLeadsQATechAssessment.Tests.UI.Support;

namespace SciLeadsQATechAssessment.Tests.UI.Tests
{
    public class TestBase
    {
        protected WebApp WebApp { get; set; }
        protected User KnownUser { get; set; }

        protected Workflows Workflows { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            KnownUser = TestDataUtils.GetTestUser();

            WebApp = new WebApp();
            WebApp.Open();

            Workflows = new Workflows(WebApp.Driver);
            Workflows.CreateNewUser(KnownUser);

            WebApp.Close();
        }

        [SetUp]
        public void Setup()
        {
            WebApp = new WebApp();
            WebApp.Open();
            Workflows.UpdateDriver(WebApp.Driver);
        }

        [TearDown]
        public void Teardown()
        {
            WebApp.Close();
        }
    }
}
