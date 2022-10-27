using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework2.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; } 

        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }
    }

    public enum BrowserType
    {
        Firefox,
        Chrome
    }

}
