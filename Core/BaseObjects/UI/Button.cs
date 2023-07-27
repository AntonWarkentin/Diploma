using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public class Button : BaseElement
    {
        public Button(string xpath) : base(xpath) { }

        public Button(string xpath, string valueToInsert) : base(xpath, valueToInsert) { }

        public Button(By by) : base(by) { }

        public void Click()
        {
            this.GetElement().Click();
        }
    }
}
