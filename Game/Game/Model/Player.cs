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
        public Player(Point position) : base(position)
        {
            position = new Point(0,0);
        }

        public void Move(Point pos, MainWindow player)
        {
            if (Keyboard.IsKeyDown(Key.S))
            {
                pos.Y += 1;
                Canvas.SetTop(player, pos.Y);
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                pos.Y -= 1;
                Canvas.SetTop(player, pos.Y);
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                pos.X -= 1;
                Canvas.SetLeft(player, pos.X);
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                pos.X += 1;
                Canvas.SetLeft(player, pos.X);
            }

        }
    }
}
