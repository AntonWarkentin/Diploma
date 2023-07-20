using Core.BaseObjects;
using OpenQA.Selenium;

namespace BusinessObjects.ModalObjects
{
    internal class DeleteProjectModal : BaseElement
    {
        private By DeleteConfirmButton = By.XPath("//span[text()='Delete project']/ancestor::button");
        private By DeleteCancelButton = By.XPath("//span[text()='Cancel']/ancestor::button");

        public void ConfirmDelete() => driver.FindElement(DeleteConfirmButton).Click();

        public DeleteProjectModal() : base() { }
    }
}
