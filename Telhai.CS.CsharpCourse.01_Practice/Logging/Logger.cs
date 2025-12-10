using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse._01_Practice.Logging
{
    public enum LogLevel
    {
        Debug=0,
        Info=1,
        Warn=2,
        Exception=3
    }
    public class Logger
    {

        public void Log(string msg)
        {
            Console.WriteLine(msg + DateTime.Now.ToString("yyyy-MM-dd HH : mm : ss.fff"));

        }
        public void Log(string msg, LogLevel level)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH : mm : ss.fff");
            string LogTxt = $"{msg} : {level} :{formattedTime}";
            Console.WriteLine(msg +":"+level+++" "+ formattedTime);

        }
    }
}
