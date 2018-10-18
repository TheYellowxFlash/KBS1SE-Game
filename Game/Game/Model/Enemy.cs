using System.Collections.Generic;
using System.Windows;
using Game.View;

namespace Game.Model
{
    /// <summary>
    /// Enemy that follows the player and kills it if they collide
    /// </summary>
    internal class Enemy : Walker
    {
        // Different images for moving directions
        private readonly string Down = "/Down/Down.png";
        private readonly string Left = "/Left/Left.png";
        private readonly string Right = "/Right/Right.png";
        private readonly string Up = "/Up/Up.png";

        public double AttackRange { get; set; }
        public string Name { get; set; }

        protected readonly int Diff = ChooseDifficulty.Difficulty;

        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="position">The intended start position of the Enemy</param>
        public Enemy(Point position) : base(position)
        {
            Position = position;
        }

        /// <summary>
        /// checks if the Enemy is in range of the given player
        /// </summary>
        /// <param name="player">The Player to check it is in range with</param>
        /// <returns></returns>
        public bool InRange(Player player)
        {
            var enemyCenter = GetCenterPoint();
            var playerCenter = player.GetCenterPoint();

            return CheckInRange(enemyCenter.X, playerCenter.X, AttackRange) &&
                   CheckInRange(enemyCenter.Y, playerCenter.Y, AttackRange);
        }

        /// <summary>
        /// Move the Enemy to the given Player if in range
        /// </summary>
        /// <param name="player">The Player to move towards</param>
        /// <param name="obstacles">A list of obstacles for collision detection</param>
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

                //call Walker.Move to handle collision detection
                Move(hor, vert, obstacles);
            }
        }
    }
}