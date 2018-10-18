using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Game.View;

namespace Game.Model
{
    internal class Player : Walker
    {
        private readonly string CC = CustomizeCharacter.character;
        private readonly int Diff = ChooseDifficulty.Difficulty;
        private readonly string Down = "/Down/Down.png";
        private readonly string Left = "/Left/Left.png";

        private readonly int player = 1;
        private readonly string Right = "/Right/Right.png";
        private readonly string Up = "/Up/Up.png";

        // Player constructor with character customization options and movement speeds
        public Player(Point position) : base(position)
        {
            Size = new Point(30, 46);
            if (CC == "Adventure")
            {
                Image = "Player1/Still/Front.png";
                player = 1;
            }
            else if (CC == "Elf")
            {
                Image = "Player2/Still/Front.png";
                player = 2;
            }
            else if (CC == "Pirate")
            {
                Image = "Player3/Still/Front.png";
                player = 3;
            }
            else
            {
                Image = "Player1/Still/Front.png";
                player = 1;
            }

            if (Diff == 1)
                movementSpeed = 1.25;
            else if (Diff == 2)
                movementSpeed = 1;
            else if (Diff == 3) movementSpeed = 1;
        }

        // Player move method including different images for moving directions
        public void Move(List<Obstacle> obstacles)
        {
            var hor = HorizontalDirection.none;
            var ver = VerticalDirection.none;
            if (Keyboard.IsKeyDown(Key.Down))
            {
                ver = VerticalDirection.down;
                if (player == 1)
                    Image = "Player1" + Down;
                else if (player == 2)
                    Image = "Player2" + Down;
                else if (player == 3) Image = "Player3" + Down;
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                ver = VerticalDirection.up;
                if (player == 1)
                    Image = "Player1" + Up;
                else if (player == 2)
                    Image = "Player2" + Up;
                else if (player == 3) Image = "Player3" + Up;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                hor = HorizontalDirection.left;
                if (player == 1)
                    Image = "Player1" + Left;
                else if (player == 2)
                    Image = "Player2" + Left;
                else if (player == 3) Image = "Player3" + Left;
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                hor = HorizontalDirection.right;
                if (player == 1)
                    Image = "Player1" + Right;
                else if (player == 2)
                    Image = "Player2" + Right;
                else if (player == 3) Image = "Player3" + Right;
            }

            Move(hor, ver, obstacles);
        }
    }
}