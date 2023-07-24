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

        string url = "https://app.qase.io/project/{0}";
        string projectCode;
        string SuiteNameButtonXpath = "//a[@title='{0}']";

        private CreateSuiteModal CreateSuiteModal => new();

        private Button SettingsButton = new("//a[@title='Settings']");
        private Button CreateSuiteButton = new("//a[@id='create-suite-button']");
        private Button CreateCaseButton = new("//a[@id='create-case-button']");
        private BaseElement Alert = new("//div[@role='alert']/span/span");
        private Button SuiteNameButton;


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

        public void AssertSuiteExistence(string suiteName, bool isExisting)
        {
            SuiteNameButtonXpath = string.Format(SuiteNameButtonXpath, suiteName);
            SuiteNameButton = new(SuiteNameButtonXpath);

            var foundElements = SuiteNameButton.GetElements();
            Assert.That(foundElements.Count > 0, Is.EqualTo(isExisting));
        }
    }
}