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

        private string DropdownButtonXpath = "//div[@class='dropdown-item']//a[contains(@href,'{0}')]//ancestor::div[@class='dropdown']//a[@data-bs-toggle='dropdown']";
        private string DeleteButtonXpath = "{0}/following-sibling::div//button[@class='Wtd_FE']";
        private string ProjectNames = "//a[@class='defect-title']";

        private Button CreateButton = new("//button[@id='createButton']");
        private TextField SearchInput = new("//input[contains(@class,'search-input')]");
        private DropDown ProjectDropdown;

        public ProjectsPage() : base() { }

        public override ProjectsPage OpenPage() => (ProjectsPage)base.OpenPage();

        public ProjectPage CreateNewProject(NewProjectDataModel dataModel)
        {
            CreateButton.Click();
            CreateNewProjectModal.FillNewProjectData(dataModel);
            return new ProjectPage(dataModel.Code);
        }

        public void AssertProjectExistence(string code, bool isExisting)
        {
            this.SearchForProject(code);
            var elements = driver.FindElements(By.XPath(ProjectNames));
            Assert.That(elements.Count > 0, Is.EqualTo(isExisting));
        }

        public void SearchForProject(string code)
        {
            SearchInput.SendKeys(code);
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