using Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Skeleton : Enemy
    {
        int Diff = ChooseDifficulty.Difficulty;

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
                AttackRange = 275;
            }
            else if (Diff == 3)
            {
                movementSpeed = .4;
                AttackRange = 300;
            }
        }
      


    }
}
