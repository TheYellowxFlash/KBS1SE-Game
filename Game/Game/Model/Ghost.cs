﻿using System.Windows;
using Game.View;

namespace Game.Model
{
    internal class Ghost : Enemy
    {
        public Ghost(Point position) : base(position)
        {
            Position = position;
            Size = new Point(36, 36);
            Image = "Ghost/Still/Front.png";
            Name = "Ghost";
            canMoveThroughWalls = true;

            if (Diff == 1)
            {
                movementSpeed = .35;
                AttackRange = 200;
            }
            else if (Diff == 2)
            {
                movementSpeed = .4;
                AttackRange = 250;
            }
            else if (Diff == 3)
            {
                movementSpeed = .4;
                AttackRange = 250;
            }
        }
    }
}