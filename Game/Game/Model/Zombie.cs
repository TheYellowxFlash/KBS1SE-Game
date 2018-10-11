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
       
        
        public Zombie(Point position) : base(position)
        {
            Position = position;
            Size = new Point(54, 54);
            movementSpeed = .3;
            AttackRange = 450;
            Image = "zombie.png";
        }
        
    }
}
