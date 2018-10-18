using System.Windows;

namespace Game.Model
{
    public class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }
        public string Image { get; set; }

        public Prop(Point position)
        {
            Position = position;
        }

        public Prop()
        {
        }

        // Calculates and returns the center position(Point) of a prop element
        public Point GetCenterPoint()
        {
            var centerX = Position.X + Size.X / 2;
            var centerY = Position.Y + Size.Y / 2;

            return new Point(centerX, centerY);
        }

        // Checks if first number(double) is in a specified range with the second number
        public static bool CheckInRange(double getal1, double getal2, double range)
        {
            return getal1 + range >= getal2 && getal2 >= getal1 - range;
        }
    }
}