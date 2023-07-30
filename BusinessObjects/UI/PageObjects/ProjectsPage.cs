using BusinessObjects.DataModels.Models;
using BusinessObjects.UI.DropDownObjects;
using BusinessObjects.UI.ModalObjects;
using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectsPage : BasePage
    {
        string url = "https://app.qase.io/projects";
        private string ProjectTitleXpath = "//a[@class='defect-title'][@href='/project/{0}']";

        private CreateProjectModal CreateNewProjectModal => new ();
        private DeleteProjectModal DeleteProjectModal => new ();

        private Button CreateButton = new("//button[@id='createButton']");
        private TextField SearchInput = new("//input[contains(@class,'search-input')]");
        private ProjectsDropDown ProjectsDropDown;
        private Button ProjectTitle;


        public ProjectsPage() : base() { }

        public override ProjectsPage OpenPage() => (ProjectsPage)base.OpenPage();

        public Button SearchForProject(string projectCode)
        {
            SearchInput.SendKeys(projectCode);
            return new(ProjectTitleXpath, projectCode);
        }

        public ProjectPage CreateNewProject(ProjectDataModel dataModel)
        {
            logger.Info("Creating new project with code" + dataModel.Code);
            CreateButton.Click();
            CreateNewProjectModal.FillNewProjectData(dataModel);
            return new ProjectPage(dataModel.Code);
        }

        public void AssertProjectExistence(string projectCode, bool isExisting)
        {
            ProjectTitle = this.SearchForProject(projectCode);

            var foundElements = ProjectTitle.GetElements();
            Assert.That(foundElements.Count > 0, Is.EqualTo(isExisting));
        }

        public ProjectGeneralSettingsPage OpenProjectSettings(string projectCode)
        {
            this.SearchForProject(projectCode);

            ProjectsDropDown = new(projectCode);
            ProjectsDropDown.SelectOption(ProjectsDropDown.SettingsButton);

            return new ProjectGeneralSettingsPage(projectCode);
        }
        
        public ProjectPage OpenProject(string projectCode)
        {
            logger.Info("Searching for project with code" + projectCode);

            ProjectTitle = this.SearchForProject(projectCode);

            ProjectTitle.Click();
            return new ProjectPage(projectCode);
        }

        public ProjectsPage DeleteProject(string projectCode)
        {
            this.SearchForProject(projectCode);

            logger.Info("Deleting project with code" + projectCode);

            ProjectsDropDown = new(projectCode);
            ProjectsDropDown.SelectOption(ProjectsDropDown.DeleteButton);
            DeleteProjectModal.Confirm();

            ProjectTitle = this.SearchForProject(projectCode);
            ProjectTitle.AssertElementExistence(false);

            return this;
        }
    }
}