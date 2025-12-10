using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Telhai.CS.CsharpCourse.Drawing
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

            Drawing d = new Rectangle(1);
            Drawing d1 = new Square(2);
            Drawing d2 = new Square(3);

            Console.WriteLine(d.Area());
            Console.WriteLine(d1.Area());

            List<Drawing> drawings = new List<Drawing>();
            drawings.Add(d1);
            drawings.Add(d);
            drawings.Add(d2);

            // מעבר על הרשימה והדפסת AREA פולימורפי
            foreach (Drawing item in drawings)
            {
                Console.WriteLine(item.Area());
            }

            Dictionary<string, Drawing> dict = new Dictionary<string, Drawing>();
            dict.Add("Draw 1", d);
            dict.Add("Draw 2", d1);
            dict.Add("Draw 3", d2);

            // AREA פולימורפי על כל אחד
            foreach (KeyValuePair<string, Drawing> pair in dict)
            {
                Console.WriteLine($"Key: {pair.Key}, Area: {pair.Value.Area()}");
            }

            // כאן ToString() מופעל — כולל ID + Draw + Area
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
