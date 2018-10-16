using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace Game.Model
{
    class World
    {
        public const int windowWidth = 1280, windowHeight = 704;

        public Player Player { get; set; }
        public Ghost Ghost1 { get; set; }
        public Ghost Ghost2 { get; set; }
        public Skeleton Skeleton1 { get; set; }
        public Skeleton Skeleton2 { get; set; }
        public Zombie Zombie1 { get; set; }
        public Zombie Zombie2 { get; set; }
        public Zombie Zombie3 { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();
        public double XPos { get; set; }
        public double YPos { get; set; }
        public List<Obstacle> obstacles = new List<Obstacle>();
        

        public World(Level1 level)
        {
            Player = new Player(new Point(203,200),level);
            Ghost1 = new Ghost(new Point(500,200));
            Ghost2 = new Ghost(new Point(500, 600));
            Skeleton1 = new Skeleton(new Point(800, 600));
            Skeleton2 = new Skeleton(new Point(400, 200));
            Zombie1 = new Zombie(new Point(600,250));
            Zombie2 = new Zombie(new Point(760, 50));
            Zombie3 = new Zombie(new Point(10, 10));

            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        public void StartGame()
        {
            timer.Start();
        }

        public void TimerPause()
        {
            timer.Stop();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            Player.Move(obstacles);

            Skeleton1.Move(Player,obstacles);
            Skeleton2.Move(Player, obstacles);
            Ghost1.Move(Player,obstacles);
            Ghost2.Move(Player, obstacles);
            Zombie1.Move(Player,obstacles);
            Zombie2.Move(Player, obstacles);
            Zombie3.Move(Player, obstacles);
        }

    }
}
