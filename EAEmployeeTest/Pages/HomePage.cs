using EAAutoFramework2.Base;
using EAAutoFramework2.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;


namespace EAEmployeeTest.Pages
{
    internal class HomePage : BasePage
    {
        IWebElement lnkLogin => DriverContext.Driver.FindElement(By.LinkText("Login"));
        IWebElement lnkEmployeeList => DriverContext.Driver.FindElement(By.LinkText("Employee List"));
        IWebElement lnkLoggedInUser => DriverContext.Driver.FindElement(By.XPath("//a[@title=\"Manage\"]"));
        IWebElement lnkLogOff => DriverContext.Driver.FindElement(By.LinkText("Log off"));

        internal LoginPage ClickLogin()
       {
            lnkLogin.Click();
            return GetInstance<LoginPage>();
       }

       internal string GetLoggedInUser()
       {
            return lnkLoggedInUser.GetLinkText();
       }
        public EmployeeListPage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }

        internal void CheckIfLoginExists()
        {
            lnkLogin.AssertElementPresent();
        }
    }
}
