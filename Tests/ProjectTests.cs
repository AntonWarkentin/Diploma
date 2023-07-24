using BusinessObjects.API;
using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.PageObjects;
using Core.Helpers;
using Core.SeleniumObjects;

namespace Tests
{
    public class ProjectTests
    {
        [Test]
        public void CreateNewProject()
        {
            var testData = ProjectDataModelBuilder.NewProjectModel();

            new LoginPage().
                OpenPage().
                Login().
                CreateNewProject(testData).
                OpenSettings().
                CheckOutProjectSettings(testData);
        }
        
        [Test]
        public void DeleteProject()
        {
            var response = new ProjectApiService().GetAllProjects();
            var codeToDelete = response.GetLastEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                DeleteProject(codeToDelete).
                AssertProjectExistence(codeToDelete, false);
        }

        [Test]
        public void EditProjectTest()
        {
            var testData = ProjectDataModelBuilder.UpdateProjectModel();
            var response = new ProjectApiService().GetAllProjects();
            var codeToEdit = response.GetLastEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                OpenProjectSettings(codeToEdit).
                UpdateSettings(testData);
        }


        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
