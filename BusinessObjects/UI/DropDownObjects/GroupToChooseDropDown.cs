using Core.BaseObjects.UI;

namespace BusinessObjects.UI.DropDownObjects
{
    internal class GroupToChooseDropDown : BaseDropDown
    {
        public override Button DropDownButton { get; }
        public Button GroupToChooseOptionButton { get; }

        public GroupToChooseDropDown() : base()
        {
            DropDownButton = new("//input[@aria-autocomplete='list']");
            GroupToChooseOptionButton = new("//div[@data-popper-placement='bottom-start']");
        }
    }
}
