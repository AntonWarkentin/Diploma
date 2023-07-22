namespace Core.BaseObjects.UI
{
    public class Button : BaseElement
    {
        public Button(string xpath) : base(xpath) { }

        public void Click()
        {
            this.GetElement().Click();
        }
    }
}
