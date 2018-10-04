﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Prop
    {
        public Point Position { get; set; }
        public Point Size { get; set; }

        public Prop(Point position)
        {
            Position = position;
            Size = new Point(40, 40);
        }
    }
}
