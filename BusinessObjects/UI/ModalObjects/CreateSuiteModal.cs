using BusinessObjects.DataModels.Models;
using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class CreateSuiteModal : BaseModal
    {
        private TextField SuiteNameTextField = new("//input[@id='title']");
        private TextField DescriptionTextField = new("//label[@for='description']/following::div//p");
        private TextField PreconditionsTextField = new("//label[@for='preconditions']/following::div//p");
        private Button SubmitButton = new("//button[@type='submit']");

        public void FillNewSuiteValues(SuiteDataModel data)
        {
            SuiteNameTextField.SendKeys(data.Title);
            DescriptionTextField.SendKeys(data.Description);
            PreconditionsTextField.SendKeys(data.Preconditions);

            SubmitButton.Click();
        }
    }
}
