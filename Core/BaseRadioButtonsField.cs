using NUnit.Framework;
using OpenQA.Selenium;

namespace Core
{
    public abstract class BaseRadioButtonsField
    {
        protected IWebDriver driver => Browser.Instance.Driver;

        public abstract void CheckOneOption<T>(T optionToCheck) where T: Enum;
    }
}
