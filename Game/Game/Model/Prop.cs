using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }

        public Prop(Point position, Point size)
        {
            Position = position;
            Size = size;
        }


        public Prop(Point position)
        {
            Position = position;
        }

        public Prop() { }


        public Point getCenterPoint()
        {
            double centerX = Position.X + (Size.X / 2);
            double centerY = Position.Y + (Size.Y / 2);

            return new Point(centerX, centerY);
        }

        public static bool checkInRange(double getal1, double getal2, double range)
        {
            if (getal1 + range > getal2 && getal2 > getal1 - range )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
