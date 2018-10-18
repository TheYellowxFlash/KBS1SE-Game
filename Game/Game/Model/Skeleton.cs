using System.Windows;
using Game.View;

namespace Game.Model
{
    /// <summary>
    /// Contains properties for skeletons and settings for different difficulty levels.
    /// </summary>
    internal class Skeleton : Enemy
    {
        public Skeleton(Point position) : base(position)
        {
            Position = position;
            Size = new Point(40, 40);
            Image = "Skeleton/Still/Front.png";
            Name = "Skeleton";

            if (Diff == 1)
            {
                movementSpeed = .35;
                AttackRange = 250;
            }
            else if (Diff == 2)
            {
                movementSpeed = .35;
                AttackRange = 300;
            }
            else if (Diff == 3)
            {
                movementSpeed = .4;
                AttackRange = 300;
            }
        }
    }
}