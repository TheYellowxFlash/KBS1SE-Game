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
        private double x, y;

        public Ghost(Point position) : base(position)
        {
            Position = position;
            Size = new Point(36,36);
            movementSpeed = .4;
            AttackRange = 240;
            Image = "ghost.png";
            canMoveThroughWalls = true;
        }
        
        
    }
}
