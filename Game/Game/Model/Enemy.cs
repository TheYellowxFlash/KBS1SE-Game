using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Enemy : Prop
    {
        public double MoveSpeed{ get; set; }
        public double AttackRange { get; set; }

        public Enemy(Point position, Point size) : base(position, size)
        {
            Position = position;
            Size = size;
        }

        public Enemy(Point position) : base(position)
        {
            Position = position;
        }
    }
}
