using System.Windows;

namespace Game.Model
{
    internal class Candy : Prop
    {
        public static string ImageCandy = "candy.png";
        public int CandyId;

        public Candy(int id, Point position)
        {
            CandyId = id;
            Position = position;
            Size = new Point(36, 36);
        }
    }
}