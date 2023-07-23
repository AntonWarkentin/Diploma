using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    internal class DeleteProjectModal : BaseObject
    {
        private Button DeleteConfirmButton = new("//span[text()='Delete project']/ancestor::button");
        private Button DeleteCancelButton = new("//span[text()='Cancel']/ancestor::button");

        public DeleteProjectModal() : base() { }

        public void ConfirmDelete() => DeleteConfirmButton.Click();
    }
}
