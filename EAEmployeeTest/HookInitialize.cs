using EAAutoFramework2.Base;
using TechTalk.SpecFlow;

namespace EAEmployeeTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        public HookInitialize() : base(BrowserType.Firefox)
        {
            InitializeSettings();
            NavigateSite();
        }

        [BeforeTestRun]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}
