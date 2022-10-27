using EAAutoFramework2.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using EAAutoFramework2.Extensions;  

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        IWebElement txtUsername => DriverContext.Driver.FindElement(By.Id("UserName"));
        IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("Password"));
        IWebElement btnLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"));

        public void Login(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Click();
            return GetInstance<HomePage>();
        }

        public void CheckIfLoginExists()
        {
            txtUsername.AssertElementPresent();
        }
    }
}
