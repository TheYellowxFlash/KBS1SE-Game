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
                movementSpeed = .3;
                AttackRange = 210;
            }
            else if (Diff == 2)
            {
                movementSpeed = .4;
                AttackRange = 240;
            }
            else if (Diff == 3)
            {
                movementSpeed = 0.45;
                AttackRange = 270;
            }
        }
        
        
    }
}
