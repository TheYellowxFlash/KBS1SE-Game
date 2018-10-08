using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game.Model
{
    class Player : Prop
    {
        private double x, y;

        public Player(Point position) : base(position)
        {
            Size = new Point(40, 40);
            Image = "player-steve.png";
        }

        public void Move(List<Obstacle> obstacles)
        {
            y = Position.Y;
            x = Position.X;

            bool canMoveRight = true;
            bool canMoveLeft = true;
            bool canMoveDown = true;
            bool canMoveUp = true;
            foreach(var obstacle in obstacles)
            {

                if(x + this.Size.X == obstacle.Position.X && (
                    ( (y + this.Size.Y < obstacle.Position.Y + obstacle.Size.Y) && (y + this.Size.Y > obstacle.Position.Y)) ||
                    ( (y < obstacle.Position.Y + obstacle.Size.Y) && (y > obstacle.Position.Y)))
                    )
                {
                    canMoveRight = false;
                }
                if (y + this.Size.Y == obstacle.Position.Y && (
                    ((x + this.Size.X < obstacle.Position.X + obstacle.Size.X) && (x + this.Size.X > obstacle.Position.X)) ||
                    ((x < obstacle.Position.X + obstacle.Size.X) && (x > obstacle.Position.X)))
                    )
                {
                    canMoveDown = false;
                }

                if (x == obstacle.Position.X + obstacle.Size.X && (
                    ((y + this.Size.Y < obstacle.Position.Y + obstacle.Size.Y) && (y + this.Size.Y > obstacle.Position.Y)) ||
                    ((y < obstacle.Position.Y + obstacle.Size.Y) && (y > obstacle.Position.Y)))
                    )
                {
                    canMoveLeft = false;
                }

                if (y == obstacle.Position.Y + obstacle.Size.Y && (
                    ((x + this.Size.X < obstacle.Position.X + obstacle.Size.X) && (x + this.Size.X > obstacle.Position.X)) ||
                    ((x < obstacle.Position.X + obstacle.Size.X) && (x > obstacle.Position.X)))
                    )
                {
                    canMoveUp = false;
                }

            }

            if (Keyboard.IsKeyDown(Key.Down) && canMoveDown)
            {
                y += 1;
            }
            if (Keyboard.IsKeyDown(Key.Up) && canMoveUp)
            {
                y -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Left) && canMoveLeft)
            {
                x -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Right) && canMoveRight)
            {
                x += 1;
            }
            Position = new Point(x,y);
        }
    }
}
