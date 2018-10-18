using System.Windows;
using System.Windows.Controls;
using TreeHelper = System.Windows.Media.VisualTreeHelper;

namespace Game.Model
{
    /// <summary>
    /// Obstacle class for Walkers to collide with
    /// </summary>
    internal class Obstacle : Prop
    {
        /// <summary>
        /// create the obstacle and set its image
        /// </summary>
        /// <param name="obstacle"></param>
        public Obstacle(Image obstacle)
        {
            var test = TreeHelper.GetOffset(obstacle);
            Position = new Point(test.X, test.Y);
            Size = new Point(obstacle.ActualWidth, obstacle.ActualHeight);
        }
    }
}