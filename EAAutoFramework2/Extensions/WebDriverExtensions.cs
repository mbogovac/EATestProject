using EAAutoFramework2.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Diagnostics;

namespace EAAutoFramework2.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute = 
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch(Exception)
                    {
                        return false;
                    }
                };
            var stopWatch = Stopwatch.StartNew();
            while(stopWatch.ElapsedMilliseconds < timeOut)
            {
                if(execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
