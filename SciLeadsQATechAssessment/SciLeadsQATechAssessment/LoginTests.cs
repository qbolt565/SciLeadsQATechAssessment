using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciLeadsQATechAssessment.PageObjects;

namespace SciLeadsQATechAssessment
{
    public class LoginTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
        }

        [Test]
        public void LoginPage_ClickLogInWithNoCredentails_LoginFails()
        {
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.Open()
                .ClickLogin();
            Assert.Multiple(() => {
                Assert.That(loginPage.SummaryErrorText, Is.EqualTo(""));
                Assert.That(loginPage.EmailErrorText, Is.EqualTo(""));
                Assert.That(loginPage.PasswordErrorText, Is.EqualTo(""));
            });
        }

        [Test]
        public void LoginPage_ClickLoginWithUnknownEmail_LoginFails()
        {
            
        }


    }
}
