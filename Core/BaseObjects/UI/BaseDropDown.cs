using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public abstract class BaseDropDown : BaseObject
    {
        public BaseDropDown() : base() { }

        public abstract Button DropDownButton { get; }

        public void SelectOption(Button optionButton)
        {
            DropDownButton.Click();
            optionButton.Click();
        }
    }
}
