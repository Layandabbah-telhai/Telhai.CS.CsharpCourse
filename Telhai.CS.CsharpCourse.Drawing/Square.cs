using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telhai.CS.CsharpCourse.Drawing
{
    public class Square : Drawing
    {
        public double Length { get; set; }

        public Square(int id) : base(id)
        {
            Length = 6;
        }

        public override double Area()
        {
            return Math.Pow(Length, 2);
        }

        public override string Draw()
        {
            return "Square";
        }

        public override string ToString()
        {
            // כולל ID + סוג הצורה + הגודל + השטח
            return $"ID={ID}, Square, Length={Length}, Area={Area()}";
        }
    }
}
