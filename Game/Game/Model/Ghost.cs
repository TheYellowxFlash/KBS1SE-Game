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
            Size = new Point(32,32);
            MoveSpeed = .5;
            AttackRange = 100;
            
        }

        public void Move(Player player)
        {
            while (InRange(player))
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
