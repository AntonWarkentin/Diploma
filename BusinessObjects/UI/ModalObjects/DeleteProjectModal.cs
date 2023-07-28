namespace BusinessObjects.UI.ModalObjects
{
    public class DeleteProjectModal : DeleteModal
    {
        public DeleteProjectModal() : base()
        {
            DeleteConfirmButton = new("//span[text()='Delete project']/ancestor::button");
        }
    }
}