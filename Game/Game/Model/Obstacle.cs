using System.Windows;
using System.Windows.Controls;
using TreeHelper = System.Windows.Media.VisualTreeHelper;

namespace Game.Model
{
    /// <summary>
    /// Obstacle class for Walkers to collide with
    /// </summary>
    public class Obstacle : Prop
    {
        /// <summary>
        /// create the obstacle and set its image
        /// </summary>
        /// <param name="obstacle"></param>
        public Obstacle(double width,double height,double xpos, double ypos)
        {
            Position = new Point(xpos, ypos);
            Size = new Point(width, height);
        }
    }
}