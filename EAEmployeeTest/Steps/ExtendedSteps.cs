using EAAutoFramework2.Base;
using EAEmployeeTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace EAEmployeeTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
            CurrentPage = GetInstance<HomePage>();
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            CurrentPage.As<HomePage>().CheckIfLoginExists();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickLoginButton(string buttonName)
        {
            if (buttonName == "login")
            {
                CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            }
            else if (buttonName == "createNew")
            {
                CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            }
            else if (buttonName == "create")
            {
                CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
            }

        }


        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
            {
                CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            }
            else if (linkName == "employeeList")
            {
                CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
            }
        }
    }
}
