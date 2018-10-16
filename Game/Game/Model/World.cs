using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
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
        private Random random = new Random();

        public List<Obstacle> obstacles = new List<Obstacle>();
        public List<Candy> AllCandies = new List<Candy>();
        public List<Candy> CandiesInGame = new List<Candy>();

        public int Score = 0;

        public World()
        {
            Player = new Player(new Point(0,0));
            Ghost = new Ghost(new Point(500,500));
            Skeleton = new Skeleton(new Point(400, 200));
            Zombie = new Zombie(new Point(600,250)); 
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        public void StartGame()
        {
            timer.Start();
            GenerateCandy();
        }

        public void TimerPause()
        {
            timer.Stop();
        }

        private void TimerOnTick(object sender, EventArgs e)
        { 
            Skeleton.Move(Player,obstacles);
            Ghost.Move(Player,obstacles);
            Player.Move(obstacles);
            Zombie.Move(Player,obstacles);
            
        }

        public void GenerateCandy()
        {
            AllCandies.Add(new Candy(1, new Point(900,500)));
            AllCandies.Add(new Candy(2, new Point(450,650)));
            AllCandies.Add(new Candy(3, new Point(340,120)));
            AllCandies.Add(new Candy(4, new Point(600,600)));
            AllCandies.Add(new Candy(5, new Point(800,400)));
        }

        public Candy GetRandomCandy()
        {
            int i = random.Next((AllCandies.Count));
            return AllCandies[i];
        }

        public Candy GetCandyNotInGame()
        {
            Candy candy = GetRandomCandy();

            while (ListContainsCandyID(candy))
            {
                candy = GetRandomCandy();
            }
            
            return candy;
        }
        public bool ListContainsCandyID(Candy c)
        {
            foreach(Candy candy in CandiesInGame)
            {
                if (candy.CandyId == c.CandyId)
                    return true;
            }
            return false;
        }

        public void CandyPickedUp(Point candyP)
        {
            CandiesInGame.RemoveAll(c => c.Position.Equals(candyP));
            Score += 100;
        }

        


    }
}
