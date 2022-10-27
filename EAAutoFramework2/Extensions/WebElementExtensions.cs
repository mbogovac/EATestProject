using EAAutoFramework2.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EAAutoFramework2.Extensions
{
    public static class WebElementExtensions
    {
        //return first selected option from drop down
        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        //return all selected options
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if(!IsElementPresent(element))
            {
                throw new Exception(string.Format("Element not present exception"));
            }
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

    }
}
