using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.PageObjects
{
    public class WebApp
    {
        private IWebDriver _driver;
        private const string APPURL = "https://blazorapp120240830075204.azurewebsites.net/";

        public IWebDriver Driver => _driver;

        public WebApp() 
        { 
            _driver = new ChromeDriver();
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(APPURL);
        }

        public void Close()
        {
            _driver.Close(); 
            _driver.Quit();
        }
    }
}
