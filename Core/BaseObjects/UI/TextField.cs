namespace Core.BaseObjects.UI
{
    public class TextField : BaseElement
    {
        public TextField(string xpath) : base(xpath) { }

        public void SendKeys(string text)
        {
            this.GetElement().Clear();
            this.GetElement().SendKeys(text);
        }
    }
}
