using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciLeadsQATechAssessment.Support
{
    public static class WebDriverExtensions
    {
        private static Logger log = new Logger();

        public static void LogClick(this IWebDriver driver, By locator, string logMessage)
        {
            log.LogInfo(logMessage);
            IWebElement element = driver.FindElement(locator);
            element.Click();
        }
    }
}
