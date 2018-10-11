﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game.Model
{
    class Player : Walker
    {

        public Player(Point position) : base(position)
        {
            CustomizeCharacter CC = new CustomizeCharacter();
            Size = new Point(40, 40);
            if(CC.character == "Finn")
            {
                Image = "finn.png";
            }else if(CC.character == "Mario")
            {
                Image = "mario.png";
            }else if(CC.character == "Zombie")
            {
                Image = "player-zombie.png";
            }
            else
            {
                Image = "finn.png";
            }
            movementSpeed = 1;
        }

        public void Move(List<Obstacle> obstacles)
        {
            Walker.HorizontalDirection hor = Walker.HorizontalDirection.none;
            Walker.VerticalDirection ver = Walker.VerticalDirection.none;
            if (Keyboard.IsKeyDown(Key.Down))
            {
                ver = Walker.VerticalDirection.down;
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                ver = Walker.VerticalDirection.up;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                hor = Walker.HorizontalDirection.left;
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                hor = Walker.HorizontalDirection.right;
            }
            Move(hor, ver, obstacles);
        }
    }
}
