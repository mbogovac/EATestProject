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
    internal class CreateEmployeePage : BasePage
    {
        IWebElement txtName => DriverContext.Driver.FindElement(By.Id("Name"));
        IWebElement txtSalary => DriverContext.Driver.FindElement(By.Id("Salary"));
        IWebElement txtDurationWorked => DriverContext.Driver.FindElement(By.Id("DurationWorked"));
        IWebElement txtGrade => DriverContext.Driver.FindElement(By.Id("Grade"));
        IWebElement txtEmail => DriverContext.Driver.FindElement(By.Id("Email"));
        IWebElement btnCreateEmployee => DriverContext.Driver.FindElement(By.XPath("//input[@value='Create']"));


        internal void ClickCreateButton()
        {
            btnCreateEmployee.Click();
        }

        internal void CreateEmployee(string name, string salary, string durationworked, string grade, string email)
        {
            txtName.SendKeys(name);
            txtSalary.SendKeys(salary);
            txtDurationWorked.SendKeys(durationworked);
            txtGrade.SendKeys(grade);
            txtEmail.SendKeys(email);
        }

    }
}
