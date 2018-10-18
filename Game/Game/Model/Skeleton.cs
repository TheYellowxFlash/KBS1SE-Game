using System.Windows;
using Game.View;

namespace Game.Model
{
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