using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.Model
{
    class Candy : Prop
    {
        public int Score = 100;

        public Candy(Point position)
        {
            Position = position;
            Size = new Point(36, 36);
            Image = "candy.png";
        }
        
    }
}
