using BusinessObjects.DataModels.API;
using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.ModalObjects;
using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectPage : BasePage
    {
        const string createSuiteMessage = "Suite was successfully created.";
        const string deleteSuiteMessage = "Suite was successfully deleted.";
        const string createTestCaseMessage = "Test case was created successfully!";

        string url = "https://app.qase.io/project/{0}";
        string projectCode;
        string SuiteNameButtonXpath = "//a[@title='{0}']";
        string DeleteSuiteButtonXpath = "//span[text()='{0}']/following::button//i[contains(@class,'trash')]";

        private CreateSuiteModal CreateSuiteModal => new();
        private DeleteModal DeleteModal => new();

        private Button SettingsButton = new("//a[@title='Settings']");
        private Button CreateSuiteButton = new("//a[@id='create-suite-button']");
        private Button CreateCaseButton = new("//a[@id='create-case-button']");
        private BaseElement Alert = new("//div[@role='alert']/span/span");
        private Button SuiteNameButton;
        private Button DeleteSuiteButton;


        public ProjectPage(string projectCode) : base()
        {
            this.projectCode = projectCode;
            url = string.Format(url, projectCode);
        }

        public override ProjectPage OpenPage() => (ProjectPage)base.OpenPage();

        public ProjectGeneralSettingsPage OpenSettings()
        {
            SettingsButton.Click();
            return new ProjectGeneralSettingsPage(projectCode);
        }

        public ProjectPage CreateSuite(SuiteDataModel suitData)
        {
            CreateSuiteButton.Click();
            CreateSuiteModal.FillNewSuiteValues(suitData);
            Assert.That(Alert.Text, Is.EqualTo(createSuiteMessage));
            return this;
        }
        
        public ProjectPage CreateTestCase(TestCaseModel data)
        {
            CreateCaseButton.Click();
            new CreateTestCasePage(projectCode).FillTestCaseData(data);
            Assert.That(Alert.Text, Is.EqualTo(createTestCaseMessage));
            return this;
        }

        public void AssertSuiteExistence(string suiteName, bool isExisting)
        {
            SuiteNameButton = new(SuiteNameButtonXpath, suiteName);

            var foundElements = SuiteNameButton.GetElements();
            Assert.That(foundElements.Count > 0, Is.EqualTo(isExisting));
        }

        public void DeleteSuite(string suiteName)
        {
            SuiteNameButton = new(SuiteNameButtonXpath, suiteName);
            DeleteSuiteButton = new(DeleteSuiteButtonXpath, suiteName);

            SuiteNameButton.Click();
            DeleteSuiteButton.Click();
            DeleteModal.ConfirmDelete();

            Assert.That(Alert.Text, Is.EqualTo(deleteSuiteMessage));
            SuiteNameButton.AssertElementExistence(false);
        }
    }
}