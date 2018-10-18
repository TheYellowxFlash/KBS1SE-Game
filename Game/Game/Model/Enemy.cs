using System.Collections.Generic;
using System.Windows;

namespace Game.Model
{
    internal class Enemy : Walker
    {
        private readonly string Down = "/Down/Down.png";

        // Different images for moving directions
        private readonly string Left = "/Left/Left.png";
        private readonly string Right = "/Right/Right.png";
        private readonly string Up = "/Up/Up.png";

        public Enemy(Point position) : base(position)
        {
            Position = position;
        }

        public double AttackRange { get; set; }
        public string Name { get; set; }

        // Method for checking if player is in atack range
        public bool InRange(Player player)
        {
            var enemyCenter = GetCenterPoint();
            var playerCenter = player.GetCenterPoint();

            return CheckInRange(enemyCenter.X, playerCenter.X, AttackRange) &&
                   CheckInRange(enemyCenter.Y, playerCenter.Y, AttackRange);
        }

        // Enemy move to player method
        public void Move(Player player, List<Obstacle> obstacles)
        {
            if (InRange(player))
            {
                var y = Position.Y;
                var x = Position.X;
                var vert = VerticalDirection.none;
                var hor = HorizontalDirection.none;

                if (player.Position.Y > y)
                {
                    vert = VerticalDirection.down;
                    Image = Name + Down;
                }
                else
                {
                    vert = VerticalDirection.up;
                    Image = Name + Up;
                }

                if (player.Position.X < x)
                {
                    hor = HorizontalDirection.left;
                    Image = Name + Left;
                }
                else
                {
                    hor = HorizontalDirection.right;
                    Image = Name + Right;
                }

                Move(hor, vert, obstacles);
            }
        }
    }
}