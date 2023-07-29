using BusinessObjects.DataModels.Models;
using BusinessObjects.UI.RadioButtonObjects;
using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class CreateProjectModal : BaseObject
    {
        private ProjectAccessTypeRadioButtons projectAccess = new();
        private MemberAccessTypeRadioButtons memberAccess = new();

        private TextField ProjectNameInput = new("//input[@id='project-name']");
        private TextField ProjectCodeInput = new("//input[@id='project-code']");
        private TextField ProjectDescriptionArea = new("//textarea[@id='description-area']");
        private Button SubmitButton = new("//button[@type='submit']");

        public CreateProjectModal() : base() { }

        public void FillNewProjectData(ProjectDataModel dataModel)
        {
            ProjectNameInput.SendKeys(dataModel.Name);
            ProjectCodeInput.SendKeys(dataModel.Code);
            ProjectDescriptionArea.SendKeys(dataModel.Description);

            memberAccess.CheckOneOption(MemberAccessOptions.AddMembersFromGroupRadioButton);

            SubmitButton.Click();
        }
    }
}