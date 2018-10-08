using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game.Model
{
    class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }
        public String Image { get; set; }
        public static List<Prop> PropList = new List<Prop>();

        public Prop(Point position, Point size, String image)
        {
            Position = position;
            Size = size;
            Image = image;
            PropList.Add(this);
        }


        public Prop(Point position, String image)
        {
            Position = position;
            Image = image;
            PropList.Add(this);
        }

        public Prop(Point position)
        {
            Position = position;
            PropList.Add(this);
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
            return (getal1 + range > getal2 && getal2 > getal1 - range);

        }

        public void RecalculateCollision(object sender, EventArgs e)
        {
        //    Rect r1 = BoundsRelativeTo(Player, Level1);
        //    Rect r2 = BoundsRelativeTo(enemy, PlayingField);
        //    Rect r3 = BoundsRelativeTo(enemy2, PlayingField);

            //if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3))
            //{
            //    MessageBox.Show("Game over");
            
            //    // hier moet de reset functie
                
            //}
        }

        public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        {
            return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        }
    }
}
