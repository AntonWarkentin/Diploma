using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.DropDownObjects;
using BusinessObjects.UI.ModalObjects;
using Core.BaseObjects.UI;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectsPage : BasePage
    {
        string url = "https://app.qase.io/projects";
        private string ProjectTitleXpath = "//a[@class='defect-title'][@href='/project/{0}']";

        private CreateNewProjectModal CreateNewProjectModal => new ();
        private DeleteProjectModal DeleteProjectModal => new ();

        private Button CreateButton = new("//button[@id='createButton']");
        private TextField SearchInput = new("//input[contains(@class,'search-input')]");
        private ProjectsDropDown ProjectsDropDown;


        public ProjectsPage() : base() { }

        public override ProjectsPage OpenPage() => (ProjectsPage)base.OpenPage();

        public void SearchForProject(string projectCode) => SearchInput.SendKeys(projectCode);

        public ProjectPage CreateNewProject(ProjectDataModel dataModel)
        {
            CreateButton.Click();
            CreateNewProjectModal.FillNewProjectData(dataModel);
            return new ProjectPage(dataModel.Code);
        }

        public void AssertProjectExistence(string projectCode, bool isExisting)
        {
            ProjectTitleXpath = string.Format(ProjectTitleXpath, projectCode);
            this.SearchForProject(projectCode);
            var elements = driver.FindElements(By.XPath(ProjectTitleXpath));
            Assert.That(elements.Count > 0, Is.EqualTo(isExisting));
        }

        public ProjectGeneralSettingsPage OpenProjectSettings(string projectCode)
        {
            this.SearchForProject(projectCode);

            ProjectsDropDown = new(projectCode);
            ProjectsDropDown.SelectOption(ProjectsDropDown.SettingsButton);

            return new ProjectGeneralSettingsPage(projectCode);
        }

        public ProjectsPage DeleteProject(string projectCode)
        {
            this.SearchForProject(projectCode);

            ProjectsDropDown = new(projectCode);
            ProjectsDropDown.SelectOption(ProjectsDropDown.DeleteButton);
            DeleteProjectModal.ConfirmDelete();

            return this;
        }
    }
}