using Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class ProjectPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}";
        private string projectName;
        private string projectCode;

        private By ProjectName = By.XPath("//img[contains(@src, 'project')]//following::div[1]");
        private By ProjectCode = By.XPath("//div[@id='application-content']//h1");

        public override ProjectPage OpenPage() => (ProjectPage)BaseOpenPage();

        public ProjectPage(string projectName, string projectCode)
        {
            this.projectName = projectName;
            this.projectCode = projectCode;
            url = string.Format(url, projectCode);
        }

        public void CheckOutProjectNameAndCode()
        {
            Thread.Sleep(1000);

            string nameOnForm = driver.FindElement(ProjectName).Text;
            string codeOnForm = driver.FindElement(ProjectCode).Text.Split(" ")[0];

            Assert.That(nameOnForm, Is.EqualTo(projectName));
            Assert.That(codeOnForm, Is.EqualTo(projectCode));
        }
    }
}