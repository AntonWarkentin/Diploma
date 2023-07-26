using BusinessObjects.DataModels.API;
using Core.BaseObjects.UI;

namespace BusinessObjects.UI.PageObjects
{
    public class CreateTestCasePage : BasePage
    {
        private string url = "https://app.qase.io/case/{0}/create";

        private TextField TitleTextField = new("//input[@id='title']");
        private TextField DescriptionTextField = new("//label[@for='0-description']/following::div[1]//p");
        private TextField PreconditionsTextField = new("//label[@for='0-preconditions']/following::div[1]//p");
        private TextField PostconditionsTextField = new("//label[@for='0-postconditions']/following::div[1]//p");

        private ComboBox StatusComboBox = new("//label[@for='0-status']/following::div[1]");
        private ComboBox SeverityComboBox = new("//label[@for='0-severity']/following::div[1]");
        private ComboBox PriorityComboBox = new("//label[@for='0-priority']/following::div[1]");
        private ComboBox TypeComboBox = new("//label[@for='0-type']/following::div[1]");
        private ComboBox LayerComboBox = new("//label[@for='0-layer']/following::div[1]");
        private ComboBox IsFlakyComboBox = new("//label[@for='0-is_flaky']/following::div[1]");
        private ComboBox BehaviorComboBox = new("//label[@for='0-behavior']/following::div[1]");
        private ComboBox AutomationComboBox = new("//label[@for='0-automation']/following::div[1]");

        private Button SaveButton = new("//button[@id='save-case']");


        public override CreateTestCasePage OpenPage() => (CreateTestCasePage)base.OpenPage();

        public CreateTestCasePage(string projectCode) : base()
        {
            url = string.Format(url, projectCode);
        }

        public void FillTestCaseData(TestCaseModel data)
        {
            TitleTextField.SendKeys(data.Title);
            StatusComboBox.ClickOption(data.Status);
            DescriptionTextField.SendKeys(data.Description);
            SeverityComboBox.ClickOption(data.SeverityStr);
            PriorityComboBox.ClickOption(data.PriorityStr);
            TypeComboBox.ClickOption(data.Type);
            LayerComboBox.ClickOption(data.Layer);
            IsFlakyComboBox.ClickOption(data.IsFlakyStr);
            BehaviorComboBox.ClickOption(data.Behavior);
            AutomationComboBox.ClickOption(data.AutomationStatus);
            PreconditionsTextField.SendKeys(data.Preconditions);
            PostconditionsTextField.SendKeys(data.Postconditions);

            SaveButton.Click();
        }
    }
}
