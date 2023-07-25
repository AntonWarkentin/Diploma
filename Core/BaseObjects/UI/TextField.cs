namespace Core.BaseObjects.UI
{
    public class TextField : BaseElement
    {
        public TextField(string xpath) : base(xpath) { }

        public TextField(string xpath, string valueToInsert) : base(xpath, valueToInsert) { }

        public void SendKeys(string text)
        {
            this.GetElement().Clear();
            this.GetElement().SendKeys(text);
        }
    }
}
