using BusinessObjects.DataModels.Models;
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
        const string deleteOneTestCaseMessage = "1 test case was successfully deleted";

        string deleteSeveralTestCasesMessage = "{0} test cases were successfully deleted";

        string url = "https://app.qase.io/project/{0}";
        string projectCode;
        string SuiteNameButtonXpath = "//a[@title='{0}']";
        string DeleteSuiteButtonXpath = "//span[text()='{0}']/following::button//i[contains(@class,'trash')]";
        string TestCaseCheckBoxButtonXpath = "//div[text()='{0}']/preceding::input[@type='checkbox'][1]";

        private CreateSuiteModal CreateSuiteModal => new();
        private DeleteModal DeleteModal => new();
        private DeleteTestCaseModal DeleteTestCaseModal => new();

        private Button SettingsButton = new("//a[@title='Settings']");
        private Button CreateSuiteButton = new("//a[@id='create-suite-button']");
        private Button CreateCaseButton = new("//a[@id='create-case-button']");
        private Button SuiteNameButton;
        private Button DeleteSuiteButton;
        private Button TestCasesCaretButtons = new("//i[contains(@class,'caret-down')][not(@class='fa fa-caret-down')]/following::a[1]");
        private Button TestCaseCheckBoxButton;
        private Button DeleteCheckedTestCasesButton = new("//i[contains(@class, 'trash')]/ancestor::button[contains(@class,'secondary')]");

        private BaseElement Alert = new("//div[@role='alert']/span/span");


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

        public void CreateSuite(SuiteDataModel suitData)
        {
            SuiteNameButton = new(SuiteNameButtonXpath, suitData.Title);
            CreateSuiteButton.Click();
            CreateSuiteModal.FillNewSuiteValues(suitData);
            Assert.That(Alert.Text, Is.EqualTo(createSuiteMessage));
            SuiteNameButton.AssertElementExistence(true);
        }
        
        public ProjectPage CreateTestCase(TestCaseModel data)
        {
            CreateCaseButton.Click();
            new CreateTestCasePage(projectCode).FillTestCaseData(data);
            Assert.That(Alert.Text, Is.EqualTo(createTestCaseMessage));
            return this;
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

        public void ShowAllTestSuites()
        {
            TestCasesCaretButtons.GetElements().ToList().ForEach(x => x.Click());
        }

        public void DeleteTestCase(string title)
        {
            TestCaseCheckBoxButton = new(TestCaseCheckBoxButtonXpath, title);

            ShowAllTestSuites();

            TestCaseCheckBoxButton.Click();
            DeleteCheckedTestCasesButton.Click();
            DeleteTestCaseModal.ConfirmDelete();

            Assert.That(Alert.Text, Is.EqualTo(deleteOneTestCaseMessage));
            TestCaseCheckBoxButton.AssertElementExistence(false);
        }

        public void DeleteTestCasesBulk(List<string> titles)
        {
            deleteSeveralTestCasesMessage = string.Format(deleteSeveralTestCasesMessage, titles.Count);

            ShowAllTestSuites();

            titles.ForEach(x => new Button(TestCaseCheckBoxButtonXpath, x).Click());

            DeleteCheckedTestCasesButton.Click();
            DeleteTestCaseModal.ConfirmDelete();

            Assert.That(Alert.Text, Is.EqualTo(deleteSeveralTestCasesMessage));
            titles.ForEach(x => new Button(TestCaseCheckBoxButtonXpath, x).AssertElementExistence(false));
        }
    }
}