namespace Core.BaseObjects.UI
{
    public class Button : BaseElement
    {
        public Button(string xpath) : base(xpath) { }

        public Button(string xpath, string valueToInsert) : base(xpath, valueToInsert) { }

        public void Click()
        {
            this.GetElement().Click();
        }
    }
}
