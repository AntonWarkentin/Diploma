using Bogus;
using BusinessObjects.DataModels;
using BusinessObjects.ModalObjects;
using Core.BaseObjects;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class ProjectsPage : BasePage
    {
        private CreateNewProjectModal CreateNewProjectModal => new CreateNewProjectModal();
        private DeleteProjectModal DeleteProjectModal => new DeleteProjectModal();

        string url = "https://app.qase.io/projects";
        private string DropdownButtonXpath = "//div[@class='dropdown-item']//a[contains(@href,'{0}')]//ancestor::div[@class='dropdown']//a[@data-bs-toggle='dropdown']";
        private string DeleteButtonXpath = "{0}/following-sibling::div//button[@class='Wtd_FE']";

        private By CreateButton = By.XPath("//button[@id='createButton']");
        private By ProjectNames = By.XPath("//a[@class='defect-title']");
        private By SearchInput = By.XPath("//input[contains(@class,'search-input')]");
        private By DropdownButton;
        private By DeleteButton;

        public ProjectsPage() : base() { }

        public override ProjectsPage OpenPage() => (ProjectsPage)base.OpenPage();

        public ProjectPage CreateNewProject(NewProjectDataModel dataModel)
        {
            driver.FindElement(CreateButton).Click();
            CreateNewProjectModal.FillNewProjectData(dataModel);
            return new ProjectPage(dataModel.Code);
        }

        public ProjectsPage DeleteProject(string projectCode)
        {
            DropdownButtonXpath = string.Format(DropdownButtonXpath, projectCode);
            DeleteButtonXpath = string.Format(DeleteButtonXpath, DropdownButtonXpath);

            DropdownButton = By.XPath(DropdownButtonXpath);
            DeleteButton = By.XPath(DeleteButtonXpath);

            driver.FindElement(DropdownButton).Click();
            driver.FindElement(DeleteButton).Click();

            DeleteProjectModal.ConfirmDelete();

            return this;
        }
    }
}