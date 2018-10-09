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
        public Ghost Ghost { get; set; }
        public Skeleton Skeleton { get; set; }
        public Zombie Zombie { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();
        public double XPos { get; set; }
        public double YPos { get; set; }

        

        public List<Obstacle> obstacles = new List<Obstacle>();

        public World()
        {
            
            Player = new Player(new Point(0,0));
            Ghost = new Ghost(new Point(500,500));
            Skeleton = new Skeleton(new Point(400, 200));
            Zombie = new Zombie(new Point(750,750));
            
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
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
            
            Skeleton.Move(Player,obstacles);
            Ghost.Move(Player);
            Player.Move(obstacles);
            Zombie.Move(Player);
            
        }

    }
}
