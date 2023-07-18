using Core;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class ProjectsPage : BasePage
    {
        string url = "https://app.qase.io/projects";

        private By CreateButton = By.XPath("//button[@id='createButton']");
        private By ProjectNames = By.XPath("//a[@class='defect-title']");
        private By DropdownButton = By.XPath("//a[@data-bs-toggle='dropdown']");
        private By DeleteButton = By.XPath("//button[@class='Wtd_FE']");

        public override ProjectsPage OpenPage() => (ProjectsPage)BaseOpenPage();

        public CreateNewProjectModal OpenCreateNewProjectModal()
        {
            driver.FindElement(CreateButton).Click();
            return new CreateNewProjectModal();
        }
    }
}