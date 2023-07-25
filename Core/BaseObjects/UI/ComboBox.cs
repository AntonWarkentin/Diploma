namespace Core.BaseObjects.UI
{
    public class ComboBox : Button
    {
        private string optionXpath = "//div[@id='modals']//div[text()='{0}']";

        private TextField InputTextField;
        private Button OptionButton;


        public ComboBox(string xpath) : base(xpath)
        {
            InputTextField = new (xpath + "//input");
        }

        public ComboBox(string xpath, string valueToInsert) : base(xpath, valueToInsert)
        {
            InputTextField = new (xpath + "//input");
        }

        public void ClickOption(string optionName)
        {
            OptionButton = new(optionXpath, optionName);

            base.Click();
            InputTextField.SendKeys(optionName);
            OptionButton.Click();
        }
    }
}
