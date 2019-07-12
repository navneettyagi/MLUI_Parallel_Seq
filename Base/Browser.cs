﻿using OpenQA.Selenium;

namespace MLAutoFramework.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        // public BrowserType Type { get; set; }

        // public void GoToUrl(string url)
        //{
        //  DriverContext.Driver.Url = url;
        //}
    }


    public enum BrowserType
    {
        IE,
        Firefox,
        Chrome,
        Safari,
        Edge,
        Opera
    }
}
