using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.PageObjects
{
    /// <summary>
    /// Resposoble for opening and close te Web App
    /// </summary>
    public class WebApp
    {
        private IWebDriver _driver;
        private const string APPURL = "https://blazorapp120240830075204.azurewebsites.net/";

        public IWebDriver Driver => _driver;

        public WebApp() 
        { 
            _driver = new ChromeDriver();
        }

        /// <summary>
        /// Open Web App at homepage.
        /// </summary>
        public void Open()
        {
            _driver.Navigate().GoToUrl(APPURL);
        }

        /// <summary>
        /// Close the browser and quit the driver.
        /// </summary>
        public void Close()
        {
            _driver.Close(); 
            _driver.Quit();
        }
    }
}
