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
        public Ghost Ghost1 { get; set; }
        public Ghost Ghost2 { get; set; }
        public Skeleton Skeleton1 { get; set; }
        public Skeleton Skeleton2 { get; set; }
        public Zombie Zombie1 { get; set; }
        public Zombie Zombie2 { get; set; }
        public Zombie Zombie3 { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();
        private Random random = new Random();

        public List<Obstacle> obstacles = new List<Obstacle>();
        public List<Candy> AllCandies = new List<Candy>();
        public List<Candy> CandiesInGame = new List<Candy>();
        public double XPos { get; set; }
        public double YPos { get; set; }

        public int Score = 0;
        
        public World(Level1 level)
        {
            Player = new Player(new Point(203,200),level);
            Ghost1 = new Ghost(new Point(500,400));
            Ghost2 = new Ghost(new Point(600, 600));
            Skeleton1 = new Skeleton(new Point(800, 600));
            Skeleton2 = new Skeleton(new Point(500, 200));
            Zombie1 = new Zombie(new Point(600,250));
            Zombie2 = new Zombie(new Point(760, 50));
            Zombie3 = new Zombie(new Point(10, 10));


            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
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
            
            Player.Move(obstacles);

            Skeleton1.Move(Player,obstacles);
            Skeleton2.Move(Player, obstacles);
            Ghost1.Move(Player,obstacles);
            Ghost2.Move(Player, obstacles);
            Zombie1.Move(Player,obstacles);
            Zombie2.Move(Player, obstacles);
            Zombie3.Move(Player, obstacles);
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
