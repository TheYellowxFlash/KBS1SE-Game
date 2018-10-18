using System.Windows;

namespace Game.Model
{
    /// <summary>
    /// The base class for all Obstacles and Walkers(Player and Enemies)
    /// </summary>
    public class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Constructor that sets the position of the Prop
        /// </summary>
        /// <param name="position">The intended position of the prop</param>
        public Prop(Point position)
        {
            Position = position;
        }

        public Prop()
        {
        }

        /// <summary>
        /// Calculates and returns the center position(Point) of a prop element
        /// </summary>
        /// <returns>The center Point</returns>
        public Point GetCenterPoint()
        {
            var centerX = Position.X + Size.X / 2;
            var centerY = Position.Y + Size.Y / 2;

            return new Point(centerX, centerY);
        }

        /// <summary>
        /// Checks if first number(double) is in a specified range with the second number
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="range">The maximum allowed range between the numbers</param>
        /// <returns>Return true when in range false otherwise</returns>
        public static bool CheckInRange(double number1, double number2, double range)
        {
            return number1 + range >= number2 && number2 >= number1 - range;
        }
    }
}