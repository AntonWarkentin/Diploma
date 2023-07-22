using OpenQA.Selenium;
using BusinessObjects.ElementsObjects;
using Core.BaseObjects;
using BusinessObjects.DataModels;
using BusinessObjects.RadioButtonObjects;

namespace BusinessObjects.ModalObjects
{
    public class CreateNewProjectModal : BaseElement
    {
        private ProjectAccessTypeRadioButtons projectAccess = new();
        private MemberAccessTypeRadioButtons memberAccess = new();

        private By ProjectNameInput = By.XPath("//input[@id='project-name']");
        private By ProjectCodeInput = By.XPath("//input[@id='project-code']");
        private By ProjectDescriptionArea = By.XPath("//textarea[@id='description-area']");
        private By SubmitButton = By.XPath("//button[@type='submit']");

        public CreateNewProjectModal() : base() { }

        public void FillNewProjectData(NewProjectDataModel dataModel)
        {
            driver.FindElement(ProjectNameInput).SendKeys(dataModel.Name);

            driver.FindElement(ProjectCodeInput).Clear();
            driver.FindElement(ProjectCodeInput).SendKeys(dataModel.Code);

            driver.FindElement(ProjectDescriptionArea).SendKeys(dataModel.Description);

            memberAccess.CheckOneOption(MemberAccessOptions.AddMembersFromGroupRadioButton);

            driver.FindElement(SubmitButton).Click();
        }
    }
}