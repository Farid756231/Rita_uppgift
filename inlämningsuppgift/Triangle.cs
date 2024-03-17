using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämningsuppgift
{
    public class Triangle : Shape
    {
        public Triangle(Point position, Color color) : base(position, color)
        {
        }

        public override void Draw(Graphics g)
        {
            Point[] points =
            {
                new Point(position.X, position.Y - 25),
                new Point(position.X - 25, position.Y + 25),
                new Point(position.X + 25, position.Y + 25)
            };
            g.FillPolygon(new SolidBrush(color), points);
        }
    }
}
