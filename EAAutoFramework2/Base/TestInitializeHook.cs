using EAAutoFramework2.Config;
using EAAutoFramework2.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace EAAutoFramework2.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;
        public TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            //set all the settings for frameworks
            ConfigReader.SetFrameworkSettings();

            //set log
            LogHelpers.CreateLogFile();

            //open browser
            OpenBrowser(Browser);
            LogHelpers.Write("initialized framework");
        }

        private void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("opened the browser!!!");
        }

    }
}
