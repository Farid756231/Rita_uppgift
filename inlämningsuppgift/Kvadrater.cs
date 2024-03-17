using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämningsuppgift
{
    public class Kvadrater : Shape
    {
        public Kvadrater(Point position, Color color) : base(position, color)
        {
        }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), position.X - 25, position.Y - 25, 50, 50);
        }
    }
}
