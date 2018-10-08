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
            MoveSpeed = .4;
            AttackRange = 240;
            Image = "ghost.png";
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
