using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteTestCaseModal : DeleteModal
    {
        string confirmText = "CONFIRM";

        protected TextField ConfirmTextField = new("//input[@name='confirm']");

        public DeleteTestCaseModal() : base() { }

        public override void ConfirmDelete()
        {
            ConfirmTextField.SendKeys(confirmText);
            base.ConfirmDelete();
        }
    }
}
