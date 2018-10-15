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
        public int CandyId;
        public int Score = 100;
        public static string ImageCandy = "candy.png";

        public Candy(int id, Point position)
        {
            CandyId = id;
            Position = position;
            Size = new Point(36, 36);
        }
        
    }
}
