using System.Runtime.InteropServices;
using Telhai.CS.CsharpCourse._01_Practice.Logging;
namespace Telhai.CS.CsharpCourse._01_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Username: {Environment.UserName}");
            Console.WriteLine($"Machine Name: {Environment.MachineName}");
            Console.WriteLine($"OS Version: {Environment.OSVersion}");
            Console.WriteLine($"OS Description: {RuntimeInformation.OSDescription}");
            Console.WriteLine("--------------");

            Logger logger = new Logger();
            for (int i = 0; i < 1000; i++)
            {
                if (i % 5 == 0)
                {

                    logger.Log("Running Main ..." + i , LogLevel.Debug);
                    continue;
                }
                    
                logger.Log("Running Main ...");
            }
        }
    }
}
