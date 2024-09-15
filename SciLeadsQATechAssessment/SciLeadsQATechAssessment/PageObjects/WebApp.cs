using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SciLeadsQATechAssessment.Tests.UI.PageObjects
{
    /// <summary>
    /// Responsible for opening and closing the Web App
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
