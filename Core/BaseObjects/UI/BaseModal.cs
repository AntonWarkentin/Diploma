namespace Core.BaseObjects.UI
{
    public class BaseModal : BaseObject
    {
        protected BaseElement Modal = new("//div[contains(@class,'ReactModal__Overlay')]");
        protected Button ConfirmButton = new("//button[@type='submit']");
        protected Button CancelButton = new("//span[text()='Cancel']/ancestor::button");

        public BaseModal() : base()
        {
            wait.Until(_ => Modal.Displayed);
        }

        public virtual void Confirm()
        {
            ConfirmButton.Click();
            wait.Until(_ => Modal.NotDisplayed);
        }
    }
}
