using Core.BaseObjects.UI;
using Core.Configuration.Logic;

namespace BusinessObjects.UI.PageObjects
{
    public class LoginPage : BasePage
    {
        string url = "https://app.qase.io/login";

        private TextField EmailField = new("//input[@name='email']");
        private TextField PasswordField = new("//input[@name='password']");
        private Button SignInButton = new("//button[@type='submit']");

        public LoginPage() : base() { }

        public override LoginPage OpenPage() => (LoginPage)base.OpenPage();

        public ProjectsPage Login()
        {
            EmailField.SendKeys(AppConfiguration.User.Login);
            PasswordField.SendKeys(AppConfiguration.User.Password);
            SignInButton.Click();
            return new ProjectsPage();
        }
    }
}