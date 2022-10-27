using EAAutoFramework2.Base;
using EAAutoFramework2.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using EAAutoFramework2.Config;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
        //    ExcelHelpers.PopulateInColletion(fileName);

        //    //page navigation with generics
        //    //login page
        //    CurrentPage = GetInstance<LoginPage>();
        //    CurrentPage.As<LoginPage>().ClickLoginLink();
        //    CurrentPage.As<LoginPage>().CheckIfLoginExists();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1,"UserName"), ExcelHelpers.ReadData(1,"Password"));

        //    //employee page
        //    CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
        //    CurrentPage.As<EmployeeListPage>().ClickCreateNew();
        //    DriverContext.Driver.Quit();
        //}

        //[TestMethod]
        //public void TableOperation()
        //{
        //    string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Login.xlsx";
        //    ExcelHelpers.PopulateInColletion(fileName);

        //    CurrentPage = GetInstance<LoginPage>();
        //    CurrentPage.As<LoginPage>().ClickLoginLink();
        //    CurrentPage.As<LoginPage>().Login(ExcelHelpers.ReadData(1, "UserName"), ExcelHelpers.ReadData(1, "Password"));

        //    //employee page
        //    CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

        //    var table = CurrentPage.As<EmployeeListPage>().GetEmployeeList();

        //    HtmlTableHelper.ReadTable(table);
        //    HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Edit");
        //    DriverContext.Driver.Quit();
        //}

    }
}
