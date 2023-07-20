using BusinessObjects.DataModels;
using Core.BaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class ProjectPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}";
        string code;

        private By ProjectName = By.XPath("//img[contains(@src, 'project')]//following::div[1]");
        private By ProjectCode = By.XPath("//div[@id='application-content']//h1");
        private By Settings = By.XPath("//a[@title='Settings']");

        public override ProjectPage OpenPage() => (ProjectPage)base.OpenPage();

        public ProjectPage(string projectCode) : base()
        {
            code = projectCode;
            url = string.Format(url, projectCode);
        }

        public ProjectGeneralSettingsPage OpenSettings()
        {
            driver.FindElement(Settings).Click();
            return new ProjectGeneralSettingsPage(code);
        }
    }
}