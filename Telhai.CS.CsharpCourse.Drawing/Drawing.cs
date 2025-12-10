using System;

namespace Telhai.CS.CsharpCourse.Drawing
{
    public class Drawing
    {
        public int ID { get; set; }

        public Drawing(int id)
        {
            ID = id;
        }

        public virtual double Area()
        {
            return 0;
        }

        public virtual string Draw()
        {
            return "Drawing shape";
        }

        public override string ToString()
        {
            // מוסיפים את ה־ID לפי המשימה
            return $"ID={ID}, {Draw()}, Area={Area()}";
        }
    }
}
