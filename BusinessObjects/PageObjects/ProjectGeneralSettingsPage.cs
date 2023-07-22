using BusinessObjects.DataModels;
using Core.BaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class ProjectGeneralSettingsPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}/settings/general";

        private By ProjectName = By.XPath("//input[@id='project-name']");
        private By ProjectCode = By.XPath("//input[@id='project-code']");
        private By Description = By.XPath("//textarea[@id='description-area']");

        public ProjectGeneralSettingsPage(string projectCode) : base()
        {
            url = string.Format(url, projectCode);
        }

        public override ProjectGeneralSettingsPage OpenPage() => (ProjectGeneralSettingsPage)base.OpenPage();

        public void CheckOutProjectSettings(NewProjectDataModel dataExpected)
        {
            var dataOnForm = new NewProjectDataModel()
            {
                Name = driver.FindElement(ProjectName).GetAttribute("value"),
                Code = driver.FindElement(ProjectCode).GetAttribute("value"),
                Description = driver.FindElement(Description).Text
            };

            Assert.That(dataOnForm, Is.EqualTo(dataExpected));
        }
    }
}