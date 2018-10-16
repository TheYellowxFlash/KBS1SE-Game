using Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace Game.Model
{
    class Player : Walker
    {
        string CC = CustomizeCharacter.character;
        int Diff = ChooseDifficulty.Difficulty;
        string Left  = "/Left/Left.png";
        string Right = "/Right/Right.png";
        string Up  = "/Up/Up.png";
        string Down  = "/Down/Down.png";
        private Level1 level;
        private bool playerIsDead = false;

        int player = 1;

        public Player(Point position,Level1 level) : base(position)
        {

            this.level = level;
            Size = new Point(30, 46);
            if(CC == "Adventure")
            {
                Image = "Player1/Still/Front.png";
                player = 1;
            }
            else if(CC == "Elf")
            {
                Image = "Player2/Still/Front.png";
                player = 2;
            }
            else if(CC == "Pirate")
            {
                Image = "Player3/Still/Front.png";
                player = 3;
            }
            else
            { 
                Image = "Player1/Still/Front.png";
                player = 1;
            }

            movementSpeed = 5;

            //if(Diff == 1)
            //{
            //    movementSpeed = 1.25;
            //} else if(Diff == 2)
            //{
            //    movementSpeed = 1;
            //} else if(Diff == 3)
            //{
            //    movementSpeed = 0.75;
            //}
        }

        public void Move(List<Obstacle> obstacles)
        {
            if (playerIsDead)
                return;
            Walker.HorizontalDirection hor = Walker.HorizontalDirection.none;
            Walker.VerticalDirection ver = Walker.VerticalDirection.none;
            if (Keyboard.IsKeyDown(Key.Down))
            {
                ver = Walker.VerticalDirection.down;
                if (player == 1)
                {
                    Image = "Player1" + Down;
                } else if (player == 2)
                {
                    Image = "Player2" + Down;

                } else if (player == 3)
                {
                    Image = "Player3" + Down;
                }

                
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                ver = Walker.VerticalDirection.up;
                if (player == 1)
                {
                    Image = "Player1" + Up;
                }
                else if (player == 2)
                {
                    Image = "Player2" + Up;

                }
                else if (player == 3)
                {
                    Image = "Player3" + Up;
                }
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                hor = Walker.HorizontalDirection.left;
                if (player == 1)
                {
                    Image = "Player1" + Left;
                }
                else if (player == 2)
                {
                    Image = "Player2" + Left;

                }
                else if (player == 3)
                {
                    Image = "Player3" + Left;
                }

            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                hor = Walker.HorizontalDirection.right;
                if (player == 1)
                {
                    Image = "Player1" + Right;
                }
                else if (player == 2)
                {
                    Image = "Player2" + Right;

                }
                else if (player == 3)
                {
                    Image = "Player3" + Right;
                }
            }
            Move(hor, ver, obstacles);
            if (Position.X + Size.X > 1270)
            {
                level.gameWon.Visibility = level.plaatje.Visibility = level.titleWin.Visibility = level.txbPlayerName.Visibility = level.btnSubmitScore.Visibility = Visibility.Visible;
                playerIsDead = true;
            }
        }
    }
}
