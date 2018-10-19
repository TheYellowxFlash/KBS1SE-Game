using System.Windows;
using Game.View;

namespace Game.Model
{
    /// <summary>
    /// Contains properties for Zombie and settings for different difficulty levels.
    /// </summary>
    internal class Zombie : Enemy
    {
        /// <summary>
        /// Creates a new zombie instance
        /// </summary>
        /// <param name="position">Zombie starting position</param>
        public Zombie(Point position) : base(position)
        {
            Position = position;
            Size = new Point(54, 54);
            Image = "Zombie/Still/Front.png";
            Name = "Zombie";

            if (Diff == 1)
            {
                movementSpeed = .5;
                AttackRange = 1000;
            }
            else if (Diff == 2)
            {
                movementSpeed = .3;
                AttackRange = 400;
            }
            else if (Diff == 3)
            {
                movementSpeed = .35;
                AttackRange = 400;
            }
        }
    }
}