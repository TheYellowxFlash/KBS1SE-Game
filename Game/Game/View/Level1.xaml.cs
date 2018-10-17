using Game.Model;
using Game.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace Game
{
    public partial class Level1 : Window
    {
        private World world;
        private int diff = ChooseDifficulty.Difficulty;
        private Rectangle playerBox, ghostBox1, ghostBox2, skeletonBox1, skeletonBox2, zombieBox1, zombieBox2, zombieBox3, worldLight;
        private Ellipse playerLight;
        private List<Rectangle> enemyBoxes = new List<Rectangle>();
        public bool pausebool = false;
        private bool gameOverBool = false;
        private double lightDiff;
        private int Time = 60;
        private Rectangle[] candyBoxes = new Rectangle[3];

        DispatcherTimer scoretimer = new DispatcherTimer();

        DispatcherTimer timer = new DispatcherTimer();

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();
        }

        private void resume_Click(object sender, RoutedEventArgs e)
        {
            resume.Visibility = Visibility.Hidden;
            restart.Visibility = Visibility.Hidden;
            exit.Visibility = Visibility.Hidden;
            title.Visibility = Visibility.Hidden;
            plaatje.Visibility = Visibility.Hidden;
            pausebool = false;
            world.StartGame();
            pausemenu.Opacity = 0;
            scoretimer.Start();
        }

        public Level1()
        {
            InitializeComponent();
            timer.Tick += CheckCandyPick;
            timer.Tick += RecalculateCollision;
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Start();

            scoretimer.Interval = TimeSpan.FromSeconds(1);
            scoretimer.Tick += Scoretimer_Tick;
            scoretimer.Start();
        }

        private void Scoretimer_Tick(object sender, EventArgs e)
        {
            Time--;

            Timer.Content = Time.ToString();

            if (Time == 0)
            {
                restart.Visibility = Visibility.Visible;
                exit.Visibility = Visibility.Visible;
                pausemenu.Opacity = 0.8;
                title.Visibility = Visibility.Visible;
                plaatje.Visibility = Visibility.Visible;
                pausebool = true;
                world.TimerPause();
                scoretimer.Stop();
            }
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (world != null)
            {
                UpdateWorld();
            }

            if (Keyboard.IsKeyDown(Key.Escape))
            {
                if (!pausebool && !gameOverBool)
                {
                    resume.Visibility = Visibility.Visible;
                    restart.Visibility = Visibility.Visible;
                    exit.Visibility = Visibility.Visible;
                    pausemenu.Opacity = 0.8;
                    title.Visibility = Visibility.Visible;
                    plaatje.Visibility = Visibility.Visible;
                    pausebool = true;
                    world.TimerPause();
                    scoretimer.Stop();
                }
            }
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Level1 levelreload = new Level1();
            levelreload.Show();
            this.Close();
        }

        private void btnSubmitScore_Click(object sender, RoutedEventArgs e)
        {
            string fileLocation = "../../Scores.xml";
            XmlDocument highScoreXML = new XmlDocument();
            highScoreXML.Load(fileLocation);

            XmlNode root = highScoreXML.FirstChild.NextSibling;

            int playerScore = world.Score; //hier later de echte score van maken

            bool scoreChanged = false;
            var list = new LinkedList<Score>();
            foreach (XmlNode scores in root.ChildNodes)
            {
                Score currentScore = new Score(scores.ChildNodes[0].InnerText, int.Parse(scores.ChildNodes[1].InnerText));
                LinkedListNode<Score> currentScoreNode = list.AddLast(currentScore);
                if (playerScore > currentScore.score && !scoreChanged)
                {
                    list.AddBefore(currentScoreNode, new Score(txbPlayerName.Text, playerScore));
                    scoreChanged = true;
                }
            }
            if (scoreChanged)
            {
                list.RemoveLast();
                root.InnerXml = "";
                foreach (Score score in list)
                {
                    XmlElement element = highScoreXML.CreateElement("entry");
                    element.InnerXml = "<name>" + score.name + "</name><score>" + score.score.ToString() + "</score>";

                    root.AppendChild(element);
                }
                highScoreXML.Save(fileLocation);
            }
            gameWon.Visibility = plaatje.Visibility = titleWin.Visibility = txbPlayerName.Visibility = btnSubmitScore.Visibility = Visibility.Hidden;

            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();

        }


        private void UpdateWorld()
        {
            Player player = world.Player;
            Canvas.SetLeft(playerBox, player.Position.X);
            Canvas.SetTop(playerBox, player.Position.Y);
            playerBox.Width = player.Size.X;
            playerBox.Height = player.Size.Y;
            ImageBrush playerBrush = new ImageBrush();
            playerBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + player.Image, UriKind.RelativeOrAbsolute));
            playerBox.Fill = playerBrush;
            playerBox.Opacity = 1;

            double x = player.Size.X * 4.5;
            double y = player.Size.Y * 2.8;

            Canvas.SetZIndex(playerLight, 6);
            Canvas.SetLeft(playerLight, player.Position.X - x);
            Canvas.SetTop(playerLight, player.Position.Y - y);
            playerLight.Width = 300;
            playerLight.Height = 300;
            playerLight.Opacity = .25;

            RadialGradientBrush LightGradient = new RadialGradientBrush();
            LightGradient.GradientOrigin = new Point(0.5, 0.5);
            LightGradient.Center = new Point(0.5, 0.5);

            playerLight.Fill = LightGradient;

            GradientStop WhiteGS = new GradientStop();
            WhiteGS.Color = Colors.White;
            WhiteGS.Offset = 0.0;
            LightGradient.GradientStops.Add(WhiteGS);

            GradientStop BlackGS = new GradientStop();
            BlackGS.Color = Colors.Transparent;
            BlackGS.Offset = 0.85;
            LightGradient.GradientStops.Add(BlackGS);

            if (diff == 1)
            {
                lightDiff = .65;
            }
            else if (diff == 2)
            {
                lightDiff = .75;
            }
            else if (diff == 3)
            {
                lightDiff = .85;
            }

            Canvas.SetLeft(worldLight, 0);
            Canvas.SetTop(worldLight, 0);
            worldLight.Width = 1280;
            worldLight.Height = 704;
            worldLight.Fill = Brushes.Black;
            worldLight.Opacity = lightDiff;
            Canvas.SetZIndex(worldLight, 5);

            #region Ghost
            if (ghostBox1 != null)
            {
                Ghost ghost1 = world.Ghost1;
                enemyBoxes.Add(ghostBox1);
                Canvas.SetLeft(ghostBox1, ghost1.Position.X);
                Canvas.SetTop(ghostBox1, ghost1.Position.Y);
                ghostBox1.Width = ghost1.Size.X;
                ghostBox1.Height = ghost1.Size.Y;
                ImageBrush ghostBrush = new ImageBrush();
                ghostBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + ghost1.Image, UriKind.RelativeOrAbsolute));
                ghostBox1.Fill = ghostBrush;
            }

            if (ghostBox2 != null)
            {
                Ghost ghost2 = world.Ghost2;
                enemyBoxes.Add(ghostBox2);
                Canvas.SetLeft(ghostBox2, ghost2.Position.X);
                Canvas.SetTop(ghostBox2, ghost2.Position.Y);
                ghostBox2.Width = ghost2.Size.X;
                ghostBox2.Height = ghost2.Size.Y;
                ImageBrush ghostBrush = new ImageBrush();
                ghostBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + ghost2.Image, UriKind.RelativeOrAbsolute));
                ghostBox2.Fill = ghostBrush;
            }
            #endregion

            #region Skeleton
            if (skeletonBox1 != null)
            {
                Skeleton skeleton1 = world.Skeleton1;
                enemyBoxes.Add(skeletonBox1);
                Canvas.SetLeft(skeletonBox1, skeleton1.Position.X);
                Canvas.SetTop(skeletonBox1, skeleton1.Position.Y);
                skeletonBox1.Width = skeleton1.Size.X;
                skeletonBox1.Height = skeleton1.Size.Y;
                ImageBrush skeletonBrush = new ImageBrush();
                skeletonBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + skeleton1.Image, UriKind.RelativeOrAbsolute));
                skeletonBox1.Fill = skeletonBrush;
            }

            if (skeletonBox2 != null)
            {
                Skeleton skeleton2 = world.Skeleton2;
                enemyBoxes.Add(skeletonBox2);
                Canvas.SetLeft(skeletonBox2, skeleton2.Position.X);
                Canvas.SetTop(skeletonBox2, skeleton2.Position.Y);
                skeletonBox2.Width = skeleton2.Size.X;
                skeletonBox2.Height = skeleton2.Size.Y;
                ImageBrush skeletonBrush = new ImageBrush();
                skeletonBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + skeleton2.Image, UriKind.RelativeOrAbsolute));
                skeletonBox2.Fill = skeletonBrush;
            }
            #endregion

            #region Zombie
            if (zombieBox1 != null)
            {
                Zombie zombie1 = world.Zombie1;
                enemyBoxes.Add(zombieBox1);
                Canvas.SetLeft(zombieBox1, zombie1.Position.X);
                Canvas.SetTop(zombieBox1, zombie1.Position.Y);
                zombieBox1.Width = zombie1.Size.X;
                zombieBox1.Height = zombie1.Size.Y;
                ImageBrush zombieBrush = new ImageBrush();
                zombieBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + zombie1.Image, UriKind.RelativeOrAbsolute));
                zombieBox1.Fill = zombieBrush;
            }

            if (zombieBox2 != null)
            {
                Zombie zombie2 = world.Zombie2;
                enemyBoxes.Add(zombieBox2);
                Canvas.SetLeft(zombieBox2, zombie2.Position.X);
                Canvas.SetTop(zombieBox2, zombie2.Position.Y);
                zombieBox2.Width = zombie2.Size.X;
                zombieBox2.Height = zombie2.Size.Y;
                ImageBrush zombieBrush = new ImageBrush();
                zombieBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + zombie2.Image, UriKind.RelativeOrAbsolute));
                zombieBox2.Fill = zombieBrush;
            }

            if (zombieBox3 != null)
            {
                Zombie zombie3 = world.Zombie3;
                enemyBoxes.Add(zombieBox3);
                Canvas.SetLeft(zombieBox3, zombie3.Position.X);
                Canvas.SetTop(zombieBox3, zombie3.Position.Y);
                zombieBox3.Width = zombie3.Size.X;
                zombieBox3.Height = zombie3.Size.Y;
                ImageBrush zombieBrush = new ImageBrush();
                zombieBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + zombie3.Image, UriKind.RelativeOrAbsolute));
                zombieBox3.Fill = zombieBrush;
            }
            #endregion
        }

        // Calculate if player picked up a candy
        public void CheckCandyPick(object sender, EventArgs e)
        {
            Rect playerBounds = BoundsRelativeTo(playerBox, level1);

            int pickedCandy = 0;
            foreach (var candyBox in candyBoxes)
            {
                Rect candy = BoundsRelativeTo(candyBox, level1);
                if (playerBounds.IntersectsWith(candy))
                {

                    Point candyPosition = new Point(Canvas.GetLeft(candyBox), Canvas.GetTop(candyBox));

                    GenerateNewCandy(pickedCandy);
                    world.CandyPickedUp(candyPosition);

                    //MessageBox.Show("Points: " + world.Score);
                    lblScore.Text = "Score: " + world.Score.ToString();
                    break;
                }

                pickedCandy++;
            }
        }

        public void GenerateNewCandy(int candyBox)
        {
            ImageBrush candyBrush = new ImageBrush();
            candyBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + Candy.ImageCandy, UriKind.RelativeOrAbsolute));

            Candy candy = world.GetCandyNotInGame();

            Canvas.SetLeft(candyBoxes[candyBox], candy.Position.X);
            Canvas.SetTop(candyBoxes[candyBox], candy.Position.Y);
            candyBoxes[candyBox].Width = candy.Size.X;
            candyBoxes[candyBox].Height = candy.Size.Y;

            world.CandiesInGame.Add(candy);
            candyBoxes[candyBox].Fill = candyBrush;
        }

        public void RecalculateCollision(object sender, EventArgs e)
        {
            Rect playerBounds = BoundsRelativeTo(playerBox, level1);

            List<Rect> enemyBounds = new List<Rect>();
            foreach (Rectangle enemyBox in enemyBoxes)
            {
                Rect item = BoundsRelativeTo(enemyBox, level1);
                enemyBounds.Add(item);
            }

            foreach (var enemy in enemyBounds)
            {
                if (playerBounds.IntersectsWith(enemy))
                {
                    if (!pausebool)
                    {
                        var diedAudio = new Uri(@"View/Audio/YouDied.mp3", UriKind.RelativeOrAbsolute);
                        SoundPlayer player = new SoundPlayer(@"View/Audio/YouDied.mp3");
                        player.Load();
                        player.Play();

                        exit.Visibility = Visibility.Visible;
                        pausemenu.Opacity = 0.8;
                        died.Visibility = Visibility.Visible;
                        plaatje.Visibility = Visibility.Visible;
                        restart.Visibility = Visibility.Visible;
                        world.TimerPause();
                        gameOverBool = true;
                        scoretimer.Stop();
                    }
                }
            }
            enemyBoxes.Clear();
        }

        public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        {
            return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            world = new World(this);

            foreach (var child in level1.Children)
            {
                if (child is Image)
                {
                    Image obstacle = (Image)child;
                    if (obstacle.IsEnabled)
                        world.obstacles.Add(new Obstacle(obstacle));
                }
            }

            playerBox = new Rectangle();
            level1.Children.Add(playerBox);

            worldLight = new Rectangle();
            level1.Children.Add(worldLight);

            playerLight = new Ellipse();
            level1.Children.Add(playerLight);

            if (diff == 1)
            {
                zombieBox1 = new Rectangle();
                level1.Children.Add(zombieBox1);
                zombieBox2 = new Rectangle();
                level1.Children.Add(zombieBox2);
                zombieBox3 = new Rectangle();
                level1.Children.Add(zombieBox3);
            }
            else if (diff == 2)
            {
                ghostBox1 = new Rectangle();
                level1.Children.Add(ghostBox1);

                skeletonBox1 = new Rectangle();
                level1.Children.Add(skeletonBox1);

                zombieBox1 = new Rectangle();
                level1.Children.Add(zombieBox1);
            }
            else if (diff == 3)
            {
                ghostBox1 = new Rectangle();
                level1.Children.Add(ghostBox1);
                ghostBox2 = new Rectangle();
                level1.Children.Add(ghostBox2);

                skeletonBox1 = new Rectangle();
                level1.Children.Add(skeletonBox1);
                skeletonBox2 = new Rectangle();
                level1.Children.Add(skeletonBox2);

                zombieBox1 = new Rectangle();
                level1.Children.Add(zombieBox1);
                zombieBox2 = new Rectangle();
                level1.Children.Add(zombieBox2);
                zombieBox3 = new Rectangle();
                level1.Children.Add(zombieBox3);

            }

            XmlDocument highScoreXML = new XmlDocument();
            highScoreXML.Load("../../Scores.xml");

            //get the highest score
            string score = highScoreXML.FirstChild.NextSibling.FirstChild.ChildNodes[1].InnerText;
            lblHighscore.Text = "Highscore: " + score;

            world.StartGame();

            #region CandyAanmaken
            candyBoxes[0] = new Rectangle();
            candyBoxes[1] = new Rectangle();
            candyBoxes[2] = new Rectangle();

            ImageBrush candyBrush = new ImageBrush();
            candyBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + Candy.ImageCandy, UriKind.RelativeOrAbsolute));
            foreach (var cBox in candyBoxes)
            {
                Candy candy = world.GetCandyNotInGame();

                Canvas.SetLeft(cBox, candy.Position.X);
                Canvas.SetTop(cBox, candy.Position.Y);
                cBox.Width = candy.Size.X;
                cBox.Height = candy.Size.Y;

                world.CandiesInGame.Add(candy);
                cBox.Fill = candyBrush;
                level1.Children.Add(cBox);
            }

            #endregion
        }
        private class Score
        {
            public string name;
            public int score;

            public Score(string n, int s)
            {
                name = n;
                score = s;
            }
        }
    }

}