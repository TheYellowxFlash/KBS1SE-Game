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
            Size = new Point(40, 40);
            MoveSpeed = .5;
            AttackRange = 300;
            Image = "skeleton.png";
        }

        public void Move(Player player, List<Obstacle> obstacles)
        {
            if (InRange(player))
            {
                y = Position.Y;
                x = Position.X;
                Walker.VerticalDirection vert = Walker.VerticalDirection.none;
                Walker.HorizontalDirection hor = Walker.HorizontalDirection.none;

                if (player.Position.Y > y)
                {
                    vert = Walker.VerticalDirection.down;
                }
                else
                {
                    vert = Walker.VerticalDirection.up;
                }

                if (player.Position.X < x)
                {
                    hor = Walker.HorizontalDirection.left;
                }
                else
                {
                    hor = Walker.HorizontalDirection.right;
                }
                Move(hor, vert, obstacles,MoveSpeed);
            }
        }


    }
}
