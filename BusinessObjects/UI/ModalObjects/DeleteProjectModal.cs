namespace BusinessObjects.UI.ModalObjects
{
    internal class DeleteProjectModal : DeleteModal
    {
        public DeleteProjectModal() : base()
        {
            DeleteConfirmButton = new("//span[text()='Delete project']/ancestor::button");
        }

        public void ConfirmDelete() => DeleteConfirmButton.Click();
    }
}