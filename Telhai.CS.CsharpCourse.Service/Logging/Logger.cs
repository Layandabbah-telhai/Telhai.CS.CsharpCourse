using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse.Service.Logging
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Exception = 3
    }
    public class Logger : ILogger
    {
        private static Logger instance;
        private string logFilePath = "";
        private Logger() { }
        private Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }
        public static Logger GetInstance(string path = "")
        {
            //first call to instance
            if (Logger.instance == null)
            {
                if (string.IsNullOrEmpty(path))
                    Logger.instance = new Logger();
                else
                    Logger.instance = new Logger(path);
            }
            return instance;
        }
        public static Logger Instance
        {
            get
            {
                //first call to instance
                if (Logger.instance == null)
                {
                    Logger.instance = new Logger();
                }
                return instance;
            }

        }
        public static void Log(string msg)
        {
            Console.WriteLine(msg + DateTime.Now.ToString("yyyy-MM-dd HH : mm : ss.fff"));

        }
        public static void Log(string msg, LogLevel level)
        {
            string formattedTime = DateTime.Now.ToString("yyyy-MM-dd HH : mm : ss.fff");
            string LogTxt = $"{msg} : {level} :{formattedTime}";
            Console.WriteLine(msg + ":" + level++ + " " + formattedTime);

        }
    }
}
