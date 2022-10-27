using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EAAutoFramework2.Base
{
    public class Base
    {
        public BasePage CurrentPage
        {
            get => (BasePage)ScenarioContext.Current["currentPage"];
            set => ScenarioContext.Current["currentPage"] = value;
        }
        private IWebDriver _driver { get; set; }


        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }

}
