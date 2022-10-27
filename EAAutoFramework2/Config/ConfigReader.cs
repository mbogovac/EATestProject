using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.XPath;

namespace EAAutoFramework2.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem testtype;
            XPathItem buildname;
            XPathItem islog;
            XPathItem isreport;
            XPathItem logPath;

            string strFileName = Environment.CurrentDirectory.ToString() + "\\EAAutoFramework2\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //get XML details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/TestType");
            islog = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/IsReport");
            logPath = navigator.SelectSingleNode("EAAutoFramework2/RunSettings/LogPath");   

            //set XML Details in the property to be used accross framework
            Settings.AUT = aut.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReport = isreport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
        }
    }
}
