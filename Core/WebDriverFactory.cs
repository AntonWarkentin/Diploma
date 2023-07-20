﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            if (AppConfiguration.Browser.Headless) options.AddArgument("--headless");

            options.AddArgument("--disable-gpu");
            options.AddArgument("incognito");
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }
    }
}