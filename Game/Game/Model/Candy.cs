using System.Windows;

namespace Game.Model
{
    /// <summary>
    /// Contains properties for candy
    /// </summary>
    internal class Candy : Prop
    {
        public static string ImageCandy = "candy.png";
        public int CandyId { get; set; }

        public Candy(int id, Point position)
        {
            CandyId = id;
            Position = position;
            Size = new Point(36, 36);
        }
    }
}   