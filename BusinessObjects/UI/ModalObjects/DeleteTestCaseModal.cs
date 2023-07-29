using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteTestCaseModal : BaseModal
    {
        string confirmText = "CONFIRM";

        protected TextField ConfirmTextField = new("//input[@name='confirm']");

        public DeleteTestCaseModal() : base() { }

        public override void Confirm()
        {
            ConfirmTextField.SendKeys(confirmText);
            base.Confirm();
        }
    }
}
