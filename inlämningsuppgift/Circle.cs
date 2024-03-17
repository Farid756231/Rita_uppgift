using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämningsuppgift
{
    public class Circle : Shape
    {
        public Circle(Point position, Color color) : base(position, color)
        {
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), position.X - 25, position.Y - 25, 50, 50);
        }

    }
}
