using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteModal : BaseObject
    {
        protected Button DeleteConfirmButton = new("//button[@type='submit']");
        protected Button DeleteCancelButton = new("//span[text()='Cancel']/ancestor::button");

        public DeleteModal() : base() { }

        public virtual void ConfirmDelete() => DeleteConfirmButton.Click();
    }
}
