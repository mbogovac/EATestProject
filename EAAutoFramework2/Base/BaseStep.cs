using EAAutoFramework2.Config;
using EAAutoFramework2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework2.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("opened the browser!!!");
        }
    }
}
