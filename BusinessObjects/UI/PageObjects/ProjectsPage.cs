using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.ModalObjects;
using Core.BaseObjects.UI;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectsPage : BasePage
    {
        string url = "https://app.qase.io/projects";

        private CreateNewProjectModal CreateNewProjectModal => new ();
        private DeleteProjectModal DeleteProjectModal => new ();

        private string DropdownButtonXpath = "//a[@href='/project/{0}/settings/general']/ancestor::div[@class='dropdown']//a[@data-bs-toggle='dropdown']";
        private string DeleteButtonXpath = "{0}/following-sibling::div//button[@class='Wtd_FE']";
        private string OpenSettingsButtonXpath = "//a[@href='/project/{0}/settings/general']";

        private string ProjectTitleXpath = "//a[@class='defect-title'][@href='/project/{0}']";

        private Button CreateButton = new("//button[@id='createButton']");
        private TextField SearchInput = new("//input[contains(@class,'search-input')]");
        private DropDown ProjectDropdown;

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
            ProjectDropdown = new(DropdownButtonXpath);
            ProjectDropdown.SelectOption(OpenSettingsButtonXpath);
            return new ProjectGeneralSettingsPage(projectCode);
        }

        public ProjectsPage DeleteProject(string projectCode)
        {
            DropdownButtonXpath = string.Format(DropdownButtonXpath, projectCode);
            DeleteButtonXpath = string.Format(DeleteButtonXpath, DropdownButtonXpath);

            ProjectDropdown = new(DropdownButtonXpath);
            ProjectDropdown.SelectOption(DeleteButtonXpath);

            DeleteProjectModal.ConfirmDelete();

            return this;
        }
    }
}