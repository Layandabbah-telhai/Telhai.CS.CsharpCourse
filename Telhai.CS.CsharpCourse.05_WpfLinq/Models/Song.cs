using System;

namespace Telhai.CS.CsharpCourse._05_WpfLinq.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public double Duration { get; set; }   

        public override string ToString()
        {
            return $"{Title} | {Artist} | {Duration} min (Id: {Id})";
        }
    }
}
