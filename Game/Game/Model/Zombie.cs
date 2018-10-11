using Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Zombie : Enemy
    {
        int Diff = ChooseDifficulty.Difficulty;

        public Zombie(Point position) : base(position)
        {
            Position = position;
            Size = new Point(54, 54);
            Image = "zombie.png";

            if (Diff == 1)
            {
                movementSpeed = .2;
                AttackRange = 400;
            }
            else if (Diff == 2)
            {
                movementSpeed = .3;
                AttackRange = 450;
            }
            else if (Diff == 3)
            {
                movementSpeed = 0.35;
                AttackRange = 475;
            }
        }
        
    }
}
