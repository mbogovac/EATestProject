using EAAutoFramework2.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAAutoFramework2.Helpers
{
    public class LogHelpers
    {
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //create a file which can store log information
        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            if(Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //create a method which can write the text in log file
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }
    }
}
