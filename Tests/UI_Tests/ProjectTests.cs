using BusinessObjects.DataModels.Builders;

namespace Tests.UI_Tests
{
    public class ProjectTests : BaseTest
    {
        [Test]
        public void CreateNewProject()
        {
            var testData = ProjectDataModelBuilder.NewProjectModel();

            TestSteps.Login().
                CreateNewProject(testData).
                OpenSettings().
                CheckOutProjectSettings(testData);
        }

        [Test]
        public void DeleteProject()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();

            TestSteps.Login().
                DeleteProject(projectCode);
        }

        [Test]
        public void EditProject()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = ProjectDataModelBuilder.UpdateProjectModel();

            TestSteps.Login().
                OpenProjectSettings(projectCode).
                UpdateSettings(testData);
        }
    }
}
