using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal string ErrorText()
        {
            throw new NotImplementedException();
        }

        internal bool UserLoggedInMessageIsDisplayed(string email)
        {
            throw new NotImplementedException();
        }
    }
}