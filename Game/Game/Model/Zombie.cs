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
        private double x, y;
        public Zombie(Point position) : base(position)
        {
            Position = position;
            Size = new Point(48, 48);
            MoveSpeed = .3;
            AttackRange = 500;

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
