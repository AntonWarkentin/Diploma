﻿using Core.SeleniumObjects.UI;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.BaseObjects.UI
{
    public abstract class BaseObject
    {
        protected IWebDriver driver => Browser.Instance.Driver;

        protected WebDriverWait wait => new WebDriverWait(driver, new TimeSpan(0, 0, 20));

        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BaseObject() { }
    }
}
