using System.Windows;
using System.Windows.Controls;
using TreeHelper = System.Windows.Media.VisualTreeHelper;

namespace Game.Model
{
    internal class Obstacle : Prop
    {
        public Obstacle(Image obstacle)
        {
            var test = TreeHelper.GetOffset(obstacle);
            Position = new Point(test.X, test.Y);
            Size = new Point(obstacle.ActualWidth, obstacle.ActualHeight);
        }
    }
}