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
        

        public Skeleton(Point position) : base(position)
        {
            Position = position;
            Size = new Point(40, 40);
            movementSpeed = .5;
            AttackRange = 300;
            Image = "skeleton.png";
        }
      


    }
}
