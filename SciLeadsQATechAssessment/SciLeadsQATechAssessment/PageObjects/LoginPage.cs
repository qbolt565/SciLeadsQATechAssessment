using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        internal LoginPage ClickLogin()
        {
            throw new NotImplementedException();
        }

        internal LoginPage EnterPassword(string password)
        {
            throw new NotImplementedException();
        }

        internal LoginPage EnterUserName(string email)
        {
            throw new NotImplementedException();
        }

        internal string ErrorText()
        {
            throw new NotImplementedException();
        }

        internal LoginPage Open()
        {
            throw new NotImplementedException();
        }
    }
}