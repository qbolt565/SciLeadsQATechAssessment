using SciLeadsQATechAssessment.Models;
using SciLeadsQATechAssessment.PageObjects;
using SciLeadsQATechAssessment.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Tests
{
    public class TestBase
    {
        protected WebApp WebApp { get; set; }
        protected User KnownUser { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            KnownUser = TestDataUtils.GetTestUser();

            WebApp = new WebApp();
            WebApp.Open();

            Workflows workflows = new Workflows();
            workflows.CreateNewUser(WebApp.Driver, KnownUser);

            WebApp.Close();
        }

        [SetUp]
        public void Setup()
        {
            WebApp = new WebApp();
            WebApp.Open();
        }

        [TearDown]
        public void Teardown()
        {
            WebApp.Close();
        }
    }
}
