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
            Position = position;
            Size = new Point(40, 40);
        }

        public void Move()
        {
            y = Position.Y;
            x = Position.X;

            if (Keyboard.IsKeyDown(Key.S))
            {
                y += 1;
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                y -= 1;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                x -= 1;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                x += 1;
            }

            Position = new Point(x,y);
        }
    }
}
