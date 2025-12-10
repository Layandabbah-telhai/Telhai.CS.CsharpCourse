using System.Runtime.InteropServices;

namespace Telhai.CS.CsharpCourse._03_OOP
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

            PlayList l1 =new PlayList();
            Type type = l1.GetType();
            type.ToString();
            //מה יש ב  baseclass של c#
            // we need validation here 
            // l1.name ="//" 
            l1.Name = "CHIL_OUT";//set
            var name_playlist = l1.Name;// get
            l1.Name += " Playlist";// get and set 
           // l1.Count = 0; there is no setter so this is for read only
           int count=l1.Count;



            PlayList l2 = new PlayList();
            l2.Name = "TECHNO";
            l2.Id = 1000;

            PlayList l3 = new PlayList("AMBIENT");
            //--Ininializer
            PlayList l4 = new PlayList {Id=1001,Name="LOAZI" };
            // object Ininialize only with {} not ()


        }
    }
}
