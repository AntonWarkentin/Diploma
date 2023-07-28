using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteModal : BaseObject
    {
        protected Button DeleteConfirmButton = new("//button[@type='submit']");
        protected Button DeleteCancelButton = new("//span[text()='Cancel']/ancestor::button");
        protected BaseElement Modal = new("//div[contains(@class,'ReactModal__Overlay')]");

        public DeleteModal() : base() { }

        public virtual void ConfirmDelete()
        {
            DeleteConfirmButton.Click();
            wait.Until(_ => Modal.NotDisplayed);
        }
    }
}