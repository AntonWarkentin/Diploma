using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.RadioButtonObjects;
using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class CreateNewProjectModal : BaseObject
    {
        private ProjectAccessTypeRadioButtons projectAccess = new();
        private MemberAccessTypeRadioButtons memberAccess = new();

        private TextField ProjectNameInput = new("//input[@id='project-name']");
        private TextField ProjectCodeInput = new("//input[@id='project-code']");
        private TextField ProjectDescriptionArea = new("//textarea[@id='description-area']");
        private Button SubmitButton = new("//button[@type='submit']");

        public CreateNewProjectModal() : base() { }

        public void FillNewProjectData(NewProjectDataModel dataModel)
        {
            ProjectNameInput.SendKeys(dataModel.Name);
            ProjectCodeInput.SendKeys(dataModel.Code);
            ProjectDescriptionArea.SendKeys(dataModel.Description);

            memberAccess.CheckOneOption(MemberAccessOptions.AddMembersFromGroupRadioButton);

            SubmitButton.Click();
        }
    }
}