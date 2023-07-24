using Core.BaseObjects.UI;

namespace BusinessObjects.UI.DropDownObjects
{
    internal class ProjectsDropDown : BaseDropDown
    {
        private string BasePath = "//a[@href='/project/{0}/settings/general']";
        private string DropdownButtonXpath = "{0}/ancestor::div[@class='dropdown']/a";
        private string OpenSettingsButtonXpath = "{0}";
        private string DeleteButtonXpath = "{0}/following::button[1]";

        public override Button DropDownButton { get; }
        public Button SettingsButton { get; }
        public Button DeleteButton { get; }

        public ProjectsDropDown(string projectCode) : base()
        {
            BasePath = string.Format(BasePath, projectCode);
            DropdownButtonXpath = string.Format(DropdownButtonXpath, BasePath);
            OpenSettingsButtonXpath = string.Format(OpenSettingsButtonXpath, BasePath);
            DeleteButtonXpath = string.Format(DeleteButtonXpath, BasePath);

            DropDownButton = new Button(DropdownButtonXpath);
            SettingsButton = new Button(OpenSettingsButtonXpath);
            DeleteButton = new Button(DeleteButtonXpath);
        }
    }
}
