using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Point = System.Windows.Point;
using Vector = System.Windows.Vector;
using TreeHelper = System.Windows.Media.VisualTreeHelper;

namespace Game.Model
{
    class Obstacle : Prop
    {

        public Obstacle(Image obstacle)
        {
            Vector test = TreeHelper.GetOffset(obstacle);
            this.Position = new Point(test.X, test.Y);
            this.Size = new Point(obstacle.ActualHeight, obstacle.ActualWidth);
        }
    }
}
