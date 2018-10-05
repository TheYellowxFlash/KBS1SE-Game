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
        private double x, y;

        public Skeleton(Point position) : base(position)
        {
            Position = position;
            Size = new Point(20, 40);
            MoveSpeed = .4;
            AttackRange = 250;
        }

        public void Move(Player player)
        {
            if (InRange(player))
            {
                y = Position.Y;
                x = Position.X;

                if (player.Position.Y > y)
                {
                    y += MoveSpeed;
                }
                else
                {
                    y -= MoveSpeed;
                }

                if (player.Position.X < x)
                {
                    x -= MoveSpeed;
                }
                else
                {
                    x += MoveSpeed;
                }

                Position = new Point(x, y);
            }
        }


    }
}
