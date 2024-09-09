using OpenQA.Selenium;

namespace SciLeadsQATechAssessment.PageObjects
{
    internal class RegistrationPage
    {
        private IWebDriver driver;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal RegistrationPage ClickRegister()
        {
            throw new NotImplementedException();
        }

        internal RegistrationPage EnterConfirmPasswors(string v)
        {
            throw new NotImplementedException();
        }

        internal RegistrationPage EnterEmail(string v)
        {
            throw new NotImplementedException();
        }

        internal RegistrationPage EnterPassword(string v)
        {
            throw new NotImplementedException();
        }

        internal string ErrorText()
        {
            throw new NotImplementedException();
        }

        internal RegistrationPage Open()
        {
            throw new NotImplementedException();
        }
    }
}