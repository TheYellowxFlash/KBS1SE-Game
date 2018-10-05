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
        public Ghost(Point position, double moveSpeed, double atackRange) : base(position)
        {
            Position = position;
            Size = new Point(32,32);
        }
    }
}
