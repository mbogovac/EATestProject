using EAAutoFramework2.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAEmployeeTest.Pages
{
    internal class EmployeeListPage : BasePage
    {
        IWebElement txtSearch => DriverContext.Driver.FindElement(By.Name("searchTerm"));
        IWebElement lnkCreateNew => DriverContext.Driver.FindElement(By.LinkText("Create New"));
        IWebElement tblEmployeeList => DriverContext.Driver.FindElement(By.ClassName("table"));

        public CreateEmployeePage ClickCreateNew()
        {
            lnkCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }
    }
}
