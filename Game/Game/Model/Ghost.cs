using Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Ghost : Enemy
    {
        int Diff = ChooseDifficulty.Difficulty;

        public Ghost(Point position) : base(position)
        {
            Position = position;
            Size = new Point(36,36);
            Image = "Ghost/Still/Front.png";
            Name = "Ghost";
            canMoveThroughWalls = true;

            if (Diff == 1)
            {
                movementSpeed = .35;
                AttackRange = 200;
            }
            else if (Diff == 2)
            {
                movementSpeed = .4;
                AttackRange = 225;
            }
            else if (Diff == 3)
            {
                movementSpeed = .4;
                AttackRange = 250;
            }
        }
        
        
    }
}
