﻿using Core.Configuration.Logic;

namespace Core.BaseObjects.UI
{
    public abstract class BasePage : BaseObject
    {
        protected string url = AppConfiguration.Browser.StartUrl;

        public BasePage() : base() { }

        public virtual BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}
