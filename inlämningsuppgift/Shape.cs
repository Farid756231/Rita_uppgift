using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämningsuppgift
{
    public abstract class Shape
    {
        protected Point position;
        protected Color color;

        public Shape(Point position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        public abstract void Draw(Graphics g);
    }
}
