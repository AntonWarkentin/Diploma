﻿using Core.SeleniumObjects;
using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public abstract class BaseElement
    {
        protected IWebDriver driver;

        public BaseElement()
        {
            Thread.Sleep(1000);
            driver = Browser.Instance.Driver;
        }
    }
}