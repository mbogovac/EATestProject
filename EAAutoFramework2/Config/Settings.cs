using EAAutoFramework2.Base;
using System;

namespace EAAutoFramework2.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string BuildName { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
        public static string IsReport { get; set; }
    }
}
