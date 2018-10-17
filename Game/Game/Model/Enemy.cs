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
        public double AttackRange { get; set; }
        public string Name { get; set; }

        private string Left  = "/Left/Left.png";
        private string Right = "/Right/Right.png";
        private string Up  = "/Up/Up.png";
        private string Down  = "/Down/Down.png";

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

        public void Move(Player player, List<Obstacle> obstacles)
        {
            if (InRange(player))
            {
                double y = Position.Y;
                double x = Position.X;
                Walker.VerticalDirection vert = Walker.VerticalDirection.none;
                Walker.HorizontalDirection hor = Walker.HorizontalDirection.none;

                if (player.Position.Y > y)
                {
                    vert = Walker.VerticalDirection.down;
                    Image = Name + Down;
                }
                else
                {
                    vert = Walker.VerticalDirection.up;
                    Image = Name + Up;
                }

                if (player.Position.X < x)
                {
                    hor = Walker.HorizontalDirection.left;
                    Image = Name + Left;
                }
                else
                {
                    hor = Walker.HorizontalDirection.right;
                    Image = Name + Right;
                }
                Move(hor, vert, obstacles);
            }
        }
    }

        
    
}
