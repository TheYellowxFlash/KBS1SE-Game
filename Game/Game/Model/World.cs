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
        public Player Player { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();
        public double XPos { get; set; }
        public double YPos { get; set; }

        public World()
        {
            Player = new Player(new Point(0,0));

            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void StartGame()
        {
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            Player.Collide();
            Player.Move();
        }

    }
}
