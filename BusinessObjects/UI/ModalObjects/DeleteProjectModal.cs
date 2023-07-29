using Core.BaseObjects.UI;

namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteProjectModal : BaseModal
    {
        public DeleteProjectModal() : base()
        {
            ConfirmButton = new("//span[text()='Delete project']/ancestor::button");
        }
    }
}