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

        public void ClickOption(string optionName)
        {
            optionXpath = string.Format(optionXpath, optionName);
            OptionButton = new(optionXpath);

            base.Click();
            InputTextField.SendKeys(optionName);
            OptionButton.Click();
        }
    }
}
