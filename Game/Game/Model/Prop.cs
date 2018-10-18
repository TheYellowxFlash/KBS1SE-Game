using System.Windows;

namespace Game.Model
{
    public class Prop
    {
        public Prop(Point position, Point size, string image)
        {
            Position = position;
            Size = size;
            Image = image;
        }


        public Prop(Point position, string image)
        {
            Position = position;
            Image = image;
        }

        public Prop(Point position)
        {
            Position = position;
        }

        public Prop()
        {
        }

        public Point Position { get; set; }
        public Point Size { get; set; }
        public string Image { get; set; }


        public Point GetCenterPoint()
        {
            var centerX = Position.X + Size.X / 2;
            var centerY = Position.Y + Size.Y / 2;

            return new Point(centerX, centerY);
        }

        public static bool CheckInRange(double getal1, double getal2, double range)
        {
            return getal1 + range >= getal2 && getal2 >= getal1 - range;
        }
    }
}