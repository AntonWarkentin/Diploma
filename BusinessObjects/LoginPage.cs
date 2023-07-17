using Core;
using OpenQA.Selenium;

namespace BusinessObjects
{
    public class LoginPage : BasePage
    {
        string url = "https://app.qase.io/login";

        private By EmailInput = By.XPath("//input[@name='email']");
        private By PasswordInput = By.XPath("//input[@name='password']");
        private By SignInButton = By.XPath("//button[@type='submit']");

        public override LoginPage OpenPage() => (LoginPage)BaseOpenPage();

        public ProjectsPage Login()
        {
            driver.FindElement(EmailInput).SendKeys(AppConfiguration.User.Login);
            driver.FindElement(PasswordInput).SendKeys(AppConfiguration.User.Password);
            driver.FindElement(SignInButton).Click();
            return new ProjectsPage();
        }
    }
}