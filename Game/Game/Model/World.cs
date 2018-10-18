using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using Game.View;

namespace Game.Model
{
    internal class World
    {
        public const int windowWidth = 1280, windowHeight = 704;
        public List<Candy> AllCandies = new List<Candy>();
        public List<Candy> CandiesInGame = new List<Candy>();

        public List<Obstacle> obstacles = new List<Obstacle>();
        private readonly Random random = new Random();

        public int Score;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        // Props aanmaken
        public World()
        {
            Player = new Player(new Point(203, 225));
            Ghost1 = new Ghost(new Point(500, 400));
            Ghost2 = new Ghost(new Point(600, 600));
            Skeleton1 = new Skeleton(new Point(800, 600));
            Skeleton2 = new Skeleton(new Point(500, 200));
            Zombie1 = new Zombie(new Point(600, 250));
            Zombie2 = new Zombie(new Point(760, 50));
            Zombie3 = new Zombie(new Point(10, 10));

            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        public Player Player { get; set; }
        public Ghost Ghost1 { get; set; }
        public Ghost Ghost2 { get; set; }
        public Skeleton Skeleton1 { get; set; }
        public Skeleton Skeleton2 { get; set; }
        public Zombie Zombie1 { get; set; }
        public Zombie Zombie2 { get; set; }
        public Zombie Zombie3 { get; set; }

        // Start timer
        public void StartGame()
        {
            timer.Start();
            GenerateCandy();
        }

        // Stop the timer
        public void TimerPause()
        {
            timer.Stop();
        }

        // Timer on tick listeners
        private void TimerOnTick(object sender, EventArgs e)
        {
            Player.Move(obstacles);

            Skeleton1.Move(Player, obstacles);
            Skeleton2.Move(Player, obstacles);
            Ghost1.Move(Player, obstacles);
            Ghost2.Move(Player, obstacles);
            Zombie1.Move(Player, obstacles);
            Zombie2.Move(Player, obstacles);
            Zombie3.Move(Player, obstacles);
        }

        // Create all candy locations
        public void GenerateCandy()
        {
            var i = 1;
            AllCandies.Add(new Candy(i++, new Point(900, 500)));
            AllCandies.Add(new Candy(i++, new Point(450, 650)));
            AllCandies.Add(new Candy(i++, new Point(340, 120)));
            AllCandies.Add(new Candy(i++, new Point(600, 600)));
            AllCandies.Add(new Candy(i++, new Point(800, 400)));
            AllCandies.Add(new Candy(i++, new Point(820, 532)));
            AllCandies.Add(new Candy(i++, new Point(679, 121)));
            AllCandies.Add(new Candy(i++, new Point(1147, 83)));
            AllCandies.Add(new Candy(i++, new Point(105, 400)));
            AllCandies.Add(new Candy(i++, new Point(80, 125)));
            AllCandies.Add(new Candy(i++, new Point(1203, 534)));
            AllCandies.Add(new Candy(i++, new Point(49, 439)));
            AllCandies.Add(new Candy(i++, new Point(864, 222)));
            AllCandies.Add(new Candy(i++, new Point(544, 233)));
            AllCandies.Add(new Candy(i++, new Point(352, 674)));
        }

        // Get random candy from all candies
        public Candy GetRandomCandy()
        {
            var i = random.Next(AllCandies.Count);
            return AllCandies[i];
        }

        // Get new random candy which is not in-game already
        public Candy GetCandyNotInGame()
        {
            var candy = GetRandomCandy();

            while (ListContainsCandyID(candy)) candy = GetRandomCandy();

            return candy;
        }

        // Check if Candies in game specific candy
        public bool ListContainsCandyID(Candy c)
        {
            foreach (var candy in CandiesInGame)
                if (candy.CandyId == c.CandyId)
                    return true;
            return false;
        }

        // Method for candy pick up and score handling
        public void CandyPickedUp(Point candyP)
        {
            CandiesInGame.RemoveAll(c => c.Position.Equals(candyP));
            var addScore = 0;
            if (ChooseDifficulty.Difficulty == 1)
                addScore = 30;
            else if (ChooseDifficulty.Difficulty == 2)
                addScore = 50;
            else if (ChooseDifficulty.Difficulty == 3)
                addScore = 100;
            Score += addScore;
        }
    }
}