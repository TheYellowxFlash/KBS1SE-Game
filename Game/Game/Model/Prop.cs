using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game.Model
{
    public class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }
        public string Image { get; set; }

        public Prop(Point position, Point size, String image)
        {
            Position = position;
            Size = size;
            Image = image;
        }


        public Prop(Point position, String image)
        {
            Position = position;
            Image = image;
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
            return (getal1 + range >= getal2 && getal2 >= getal1 - range);

        }
    }
}
