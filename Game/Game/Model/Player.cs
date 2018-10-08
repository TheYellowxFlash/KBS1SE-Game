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
            Image = "player-idle.png";
        }

        public void Move()
        {
            y = Position.Y;
            x = Position.X;

            if (Keyboard.IsKeyDown(Key.Down))
            {
                y += 1;
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                y -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                x -= 1;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                x += 1;
            }

            Position = new Point(x,y);
        }
    }
}
