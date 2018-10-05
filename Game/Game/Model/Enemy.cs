using System;
using System.Collections.Generic;
using System.Dynamic;
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

        public bool InRange(Player player)
        {
            Point enemyCenter = getCenterPoint();
            Point playerCenter = player.getCenterPoint();

           
            return (checkInRange(enemyCenter.X, playerCenter.X, AttackRange) &&
                    checkInRange(enemyCenter.Y, playerCenter.Y, AttackRange));

        }

        
    }
}
