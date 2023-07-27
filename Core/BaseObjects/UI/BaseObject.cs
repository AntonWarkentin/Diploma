using Core.SeleniumObjects.UI;
using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public abstract class BaseObject
    {
        protected IWebDriver driver => Browser.Instance.Driver;

        public BaseObject() { }
    }
}
