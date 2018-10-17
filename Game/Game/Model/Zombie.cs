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
            Image = "Zombie/Still/Front.png";
            Name = "Zombie";

            if (Diff == 1)
            {
                movementSpeed = .2;
                AttackRange = 350;
            }
            else if (Diff == 2)
            {
                movementSpeed = .25;
                AttackRange = 375;
            }
            else if (Diff == 3)
            {
                movementSpeed = .35;
                AttackRange = 400;
            }
        }
        
    }
}
