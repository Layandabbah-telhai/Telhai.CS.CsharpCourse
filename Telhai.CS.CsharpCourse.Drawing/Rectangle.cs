using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse.Drawing
{
    public class Rectangle : Drawing
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(int id) : base(id)
        {
            Height = 5.3;
            Width = 3.4;
        }

        public override double Area()
        {
            return Height * Width;
        }

        public override string Draw()
        {
            return "Rectangle";
        }

        public override string ToString()
        {
            return $"ID={ID}, Rectangle, Height={Height}, Width={Width}, Area={Area()}";
        }
    }
}
