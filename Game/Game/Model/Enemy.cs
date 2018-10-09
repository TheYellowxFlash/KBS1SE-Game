using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Enemy : Walker
    {
        public double MoveSpeed{ get; set; }
        public double AttackRange { get; set; }

        public Enemy(Point position, Point size, String image) : base(position, size, image)
        {
            Position = position;
            Size = size;
            Image = image;
        }

        public Enemy(Point position, String image) : base(position, image)
        {
            Position = position;
            Image = image;
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
