using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telhai.CS.CsharpCourse.Service.Logging;



namespace Telhai.CS.CsharpCourse._03_OOP
{
    public class PlayList
    {
        private List<string> songs;
        private string name;
        //  private int count; now we have a proprty that called count so we do not need this any more
        // we do not set type as public because of validation 
        //Empty C`tor
        public PlayList() : this("NO NAME")
        {

            Logger.Log("In Empty C`tor", LogLevel.Debug);
            //this.name = "NO Name"; instead we can do what we did in the prev line 
            //songs = new List<string>(); we called the othe C`tor so there is no need 
        }
        public PlayList(string name)
        {
            //this.name=name; no proprty with setter , go to field
            Name = name;//in this vay there is validation also in the C`tor //used set
            songs = new List<string>();


        }

        public string Name // this called proprty
        {
            get { return name.ToUpper(); }// we can also write get =>name.ToUpper();// we can also write get; so it will auto get the same name of Name 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    name = "<NO PLAYLIST NAME>";

                }
                name = value;
            }

        }
        // auto proprty
        /// <summary>
        /// this make an auto id with setter and getter sence id is ont defined 
        /// </summary>
        /// // note: Id is an auto property, no need to define a field for it
        // if we want Id to be read-only (no set), we can write: public int Id { get; }
        // if we want it to be set only inside the class, we can write: public int Id { get; private set; }

        public int Id { get; set; }
        public int MyProperty { get; set; }
        /// <summary>
        /// Get the count of the songs 
        /// </summary>
        /// 
        public int Count
        {
            get => songs.Count;
        }
        // it also can be written as :
        // public int Count=> songs.Count;
    }
}

