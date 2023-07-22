using Core.BaseObjects.UI;
using OpenQA.Selenium;

namespace BusinessObjects.UI.ModalObjects
{
    internal class DeleteProjectModal : BaseElement
    {
        private By DeleteConfirmButton = By.XPath("//span[text()='Delete project']/ancestor::button");
        private By DeleteCancelButton = By.XPath("//span[text()='Cancel']/ancestor::button");

        public DeleteProjectModal() : base() { }

        public void ConfirmDelete() => driver.FindElement(DeleteConfirmButton).Click();
    }
}
