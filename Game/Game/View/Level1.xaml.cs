using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Game.Model;
using Game.View;

namespace Game
{
    /// <summary>
    /// Builds the level and handles interactions with Level1.xaml
    /// </summary>
    public partial class Level1 : Window
    {
        private readonly Rectangle[] candyBoxes = new Rectangle[3];
        private bool clickedPlayertxb;
        private readonly int diff = ChooseDifficulty.Difficulty;
        private readonly List<Rectangle> enemyBoxes = new List<Rectangle>();

        private bool finished = true;
        private bool gameOverBool;
        private XmlDocument highScoreXML = new XmlDocument();
        private double lightDiff;
        public bool pausebool;

        private Rectangle playerBox,
            ghostBox1,
            ghostBox2,
            skeletonBox1,
            skeletonBox2,
            zombieBox1,
            zombieBox2,
            zombieBox3,
            worldLight;

        private Ellipse playerLight;

        private readonly DispatcherTimer scoretimer = new DispatcherTimer();
        private int Time = 144;

        private readonly DispatcherTimer timer = new DispatcherTimer();
        private World world;


        /// <summary>
        /// For making the game flow there is a DispatchTimer being used with a timer on tick method.
        /// </summary>
        public Level1()
        {
            InitializeComponent();
            bool bestand = File.Exists("View/XML/Scores.xml");
            if (bestand)
            {
                highScoreXML.Load("View/XML/Scores.xml");
            }
            else
            {
                MessageBox.Show("kan bestand niet laden");
            }


            timer.Tick += CheckCandyPick;
            timer.Tick += RecalculateCollision;
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Start();

            scoretimer.Interval = TimeSpan.FromSeconds(1);
            scoretimer.Tick += Scoretimer_Tick;
            scoretimer.Start();
        }

        /// <summary>
        /// This method initializes all canvas elements and will be called on the window load event.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.Content = Time.ToString();
            world = new World();

            foreach (var child in level1.Children)
                if (child is Image)
                {
                    var obstacle = (Image)child;
                    if (obstacle.IsEnabled)
                        world.Obstacles.Add(new Obstacle(obstacle));
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


            //get the highest score
            var score = highScoreXML.FirstChild.NextSibling.FirstChild.ChildNodes[1].InnerText;
            lblHighscore.Text = "Highscore: " + score;

            world.StartGame();

            #region CandyAanmaken

            candyBoxes[0] = new Rectangle();
            candyBoxes[1] = new Rectangle();
            candyBoxes[2] = new Rectangle();

            var candyBrush = new ImageBrush();
            candyBrush.ImageSource =
                new BitmapImage(new Uri(@"View/PropIcons/candy.png", UriKind.RelativeOrAbsolute));
            foreach (var cBox in candyBoxes)
            {
                var candy = world.GetCandyNotInGame();

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

        // Button to end the game
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }

        // Button to resume the game
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

        // Time expires event
        private void Scoretimer_Tick(object sender, EventArgs e)
        {
            Time--;

            Timer.Content = Time.ToString();

            if (Time == 0)
            {
                var player = new SoundPlayer(Properties.Resources.died);
                player.Play();
                restart.Visibility = Visibility.Visible;
                exit.Visibility = Visibility.Visible;
                pausemenu.Opacity = 0.8;
                died.Visibility = Visibility.Visible;
                plaatje.Visibility = Visibility.Visible;
                pausebool = true;
                world.TimerPause();
                scoretimer.Stop();
            }
        }

        /// <summary>
        /// Timer on tick method which will call the UpdateWorld method on every tick.
        /// </summary>
        private void TimerOnTick(object sender, EventArgs e)
        {
            if (world != null) UpdateWorld();

            if (Keyboard.IsKeyDown(Key.Escape))
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

        // Get score of last position on highscore board
        private int GetLastScore()
        {
            return int.Parse(highScoreXML.FirstChild.NextSibling.LastChild.ChildNodes[1].InnerText);
        }

        // Remove placeholder on textbox for highscore form
        private void txbPlayerName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!clickedPlayertxb)
            {
                txbPlayerName.Text = "";
                txbPlayerName.Foreground = new SolidColorBrush(Colors.Black);
                clickedPlayertxb = true;
                btnSubmitScore.Visibility = Visibility.Visible;
            }
        }

        // Game restart if player restarts
        private void restart_Click(object sender, RoutedEventArgs e)
        {
            var levelreload = new Level1();
            levelreload.Show();

            Close();
        }

        //Set new highscore
        private void btnSubmitScore_Click(object sender, RoutedEventArgs e)
        {
            var root = highScoreXML.FirstChild.NextSibling;

            var playerScore = world.Score; //hier later de echte score van maken

            var scoreChanged = false;
            var list = new LinkedList<Score>();
            foreach (XmlNode scores in root.ChildNodes)
            {
                var currentScore = new
                    Score(scores.ChildNodes[0].InnerText, int.Parse(scores.ChildNodes[1].InnerText));
                var currentScoreNode = list.AddLast(currentScore);
                if (playerScore > currentScore.PlayerScore && !scoreChanged)
                {
                    list.AddBefore(currentScoreNode, new Score(txbPlayerName.Text, playerScore));
                    scoreChanged = true;
                }
            }

            if (scoreChanged)
            {
                list.RemoveLast();
                root.InnerXml = "";
                foreach (var score in list)
                {
                    var element = highScoreXML.CreateElement("entry");
                    element.InnerXml = "<name>" + score.Name + "</name><score>" + score.PlayerScore + "</score>";

                    root.AppendChild(element);
                }
                try {
                    highScoreXML.Save("View/XML/Scores.xml");
                } catch
                {
                    MessageBox.Show("kan het bestand niet laden");
                }
            }

            gameWon.Visibility =
                plaatje.Visibility = titleWin.Visibility = txbPlayerName.Visibility = Visibility.Hidden;

            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }
        /// <summary>
        /// The update world method contains all in game updates, position updates for player, enemy, candies etc...
        /// </summary>
        // Update elements in game world on timer tick
        private void UpdateWorld()
        {
            var player = world.Player;

            //Endpoint of game
            #region GameEndpoint
            var houseX = 144 + 161 / 2;
            if (player.Position.X + player.Size.X > houseX && player.Position.X < houseX &&
                Math.Floor(player.Position.Y) == 75 + 117)
                if (finished)
                {
                    finished = false;
                    gameWon.Visibility = plaatje.Visibility = titleWin.Visibility = Visibility.Visible;
                    lblHighscore.Visibility =
                        lblScore.Visibility = lblTimer.Visibility = Timer.Visibility = Visibility.Hidden;
                    pausemenu.Opacity = 0.8;
                    if (world.Score > GetLastScore())
                        txbPlayerName.Visibility = playerName.Visibility = Visibility.Visible;
                    else
                        exit.Visibility = lblNoHighscore.Visibility = Visibility.Visible;
                    world.TimerPause();
                    scoretimer.Stop();
                    gameOverBool = true;
                    new SoundPlayer(Properties.Resources.Finish).Play();
                }
            #endregion

            // Player element
            #region Player
            Canvas.SetLeft(playerBox, player.Position.X);
            Canvas.SetTop(playerBox, player.Position.Y);
            playerBox.Width = player.Size.X;
            playerBox.Height = player.Size.Y;
            var playerBrush = new ImageBrush();
            playerBrush.ImageSource =
                new BitmapImage(new Uri(@"View/PropIcons/" + player.Image, UriKind.RelativeOrAbsolute));
            playerBox.Fill = playerBrush;
            playerBox.Opacity = 1;

            var x = player.Size.X * 4.5;
            var y = player.Size.Y * 2.8;
            #endregion

            // Lightning effects
            #region LightningEffects
            Panel.SetZIndex(playerLight, 6);
            Canvas.SetLeft(playerLight, player.Position.X - x);
            Canvas.SetTop(playerLight, player.Position.Y - y);
            playerLight.Width = 300;
            playerLight.Height = 300;
            playerLight.Opacity = .25;

            var LightGradient = new RadialGradientBrush();
            LightGradient.GradientOrigin = new Point(0.5, 0.5);
            LightGradient.Center = new Point(0.5, 0.5);

            playerLight.Fill = LightGradient;

            var WhiteGS = new GradientStop();
            WhiteGS.Color = Colors.White;
            WhiteGS.Offset = 0.0;
            LightGradient.GradientStops.Add(WhiteGS);

            var BlackGS = new GradientStop();
            BlackGS.Color = Colors.Transparent;
            BlackGS.Offset = 0.85;
            LightGradient.GradientStops.Add(BlackGS);

            if (diff == 1)
                lightDiff = .65;
            else if (diff == 2)
                lightDiff = .75;
            else if (diff == 3) lightDiff = .85;

            Canvas.SetLeft(worldLight, 0);
            Canvas.SetTop(worldLight, 0);
            worldLight.Width = 1280;
            worldLight.Height = 704;
            worldLight.Fill = Brushes.Black;
            worldLight.Opacity = lightDiff;
            Panel.SetZIndex(worldLight, 5);

            #endregion

            // Enemy ghosts
            #region Ghost

            if (ghostBox1 != null)
            {
                var ghost1 = world.Ghost1;
                enemyBoxes.Add(ghostBox1);
                Canvas.SetLeft(ghostBox1, ghost1.Position.X);
                Canvas.SetTop(ghostBox1, ghost1.Position.Y);
                ghostBox1.Width = ghost1.Size.X;
                ghostBox1.Height = ghost1.Size.Y;
                var ghostBrush = new ImageBrush();
                ghostBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + ghost1.Image, UriKind.RelativeOrAbsolute));
                ghostBox1.Fill = ghostBrush;
            }

            if (ghostBox2 != null)
            {
                var ghost2 = world.Ghost2;
                enemyBoxes.Add(ghostBox2);
                Canvas.SetLeft(ghostBox2, ghost2.Position.X);
                Canvas.SetTop(ghostBox2, ghost2.Position.Y);
                ghostBox2.Width = ghost2.Size.X;
                ghostBox2.Height = ghost2.Size.Y;
                var ghostBrush = new ImageBrush();
                ghostBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + ghost2.Image, UriKind.RelativeOrAbsolute));
                ghostBox2.Fill = ghostBrush;
            }

            #endregion

            // Enemy skeletons
            #region Skeleton

            if (skeletonBox1 != null)
            {
                var skeleton1 = world.Skeleton1;
                enemyBoxes.Add(skeletonBox1);
                Canvas.SetLeft(skeletonBox1, skeleton1.Position.X);
                Canvas.SetTop(skeletonBox1, skeleton1.Position.Y);
                skeletonBox1.Width = skeleton1.Size.X;
                skeletonBox1.Height = skeleton1.Size.Y;
                var skeletonBrush = new ImageBrush();
                skeletonBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + skeleton1.Image, UriKind.RelativeOrAbsolute));
                skeletonBox1.Fill = skeletonBrush;
            }

            if (skeletonBox2 != null)
            {
                var skeleton2 = world.Skeleton2;
                enemyBoxes.Add(skeletonBox2);
                Canvas.SetLeft(skeletonBox2, skeleton2.Position.X);
                Canvas.SetTop(skeletonBox2, skeleton2.Position.Y);
                skeletonBox2.Width = skeleton2.Size.X;
                skeletonBox2.Height = skeleton2.Size.Y;
                var skeletonBrush = new ImageBrush();
                skeletonBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + skeleton2.Image, UriKind.RelativeOrAbsolute));
                skeletonBox2.Fill = skeletonBrush;
            }

            #endregion

            // Enemy zombies
            #region Zombie

            if (zombieBox1 != null)
            {
                var zombie1 = world.Zombie1;
                enemyBoxes.Add(zombieBox1);
                Canvas.SetLeft(zombieBox1, zombie1.Position.X);
                Canvas.SetTop(zombieBox1, zombie1.Position.Y);
                zombieBox1.Width = zombie1.Size.X;
                zombieBox1.Height = zombie1.Size.Y;
                var zombieBrush = new ImageBrush();
                zombieBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + zombie1.Image, UriKind.RelativeOrAbsolute));
                zombieBox1.Fill = zombieBrush;
            }

            if (zombieBox2 != null)
            {
                var zombie2 = world.Zombie2;
                enemyBoxes.Add(zombieBox2);
                Canvas.SetLeft(zombieBox2, zombie2.Position.X);
                Canvas.SetTop(zombieBox2, zombie2.Position.Y);
                zombieBox2.Width = zombie2.Size.X;
                zombieBox2.Height = zombie2.Size.Y;
                var zombieBrush = new ImageBrush();
                zombieBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + zombie2.Image, UriKind.RelativeOrAbsolute));
                zombieBox2.Fill = zombieBrush;
            }

            if (zombieBox3 != null)
            {
                var zombie3 = world.Zombie3;
                enemyBoxes.Add(zombieBox3);
                Canvas.SetLeft(zombieBox3, zombie3.Position.X);
                Canvas.SetTop(zombieBox3, zombie3.Position.Y);
                zombieBox3.Width = zombie3.Size.X;
                zombieBox3.Height = zombie3.Size.Y;
                var zombieBrush = new ImageBrush();
                zombieBrush.ImageSource =
                    new BitmapImage(new Uri(@"View/PropIcons/" + zombie3.Image, UriKind.RelativeOrAbsolute));
                zombieBox3.Fill = zombieBrush;
            }

            #endregion
        }

        // Calculate if player picked up a candy, this method is called on every tick
        private void CheckCandyPick(object sender, EventArgs e)
        {
            var playerBounds = BoundsRelativeTo(playerBox, level1);

            var pickedCandy = 0;
            foreach (var candyBox in candyBoxes)
            {
                var candy = BoundsRelativeTo(candyBox, level1);
                if (playerBounds.IntersectsWith(candy))
                {
                    var candyPosition = new Point(Canvas.GetLeft(candyBox), Canvas.GetTop(candyBox));

                    GenerateNewCandy(pickedCandy);
                    world.CandyPickedUp(candyPosition);

                    //MessageBox.Show("Points: " + world.Score);
                    lblScore.Text = "Score: " + world.Score;
                    var player = new SoundPlayer(Properties.Resources.Pickup);
                    player.Play();
                    break;
                }

                pickedCandy++;
            }
        }

        // Generate new candy location, this method is called on every tick
        private void GenerateNewCandy(int candyBox)
        {
            var candyBrush = new ImageBrush();
            candyBrush.ImageSource =
                new BitmapImage(new Uri(@"View/PropIcons/" + Candy.ImageCandy, UriKind.RelativeOrAbsolute));

            var candy = world.GetCandyNotInGame();

            Canvas.SetLeft(candyBoxes[candyBox], candy.Position.X);
            Canvas.SetTop(candyBoxes[candyBox], candy.Position.Y);
            candyBoxes[candyBox].Width = candy.Size.X;
            candyBoxes[candyBox].Height = candy.Size.Y;

            world.CandiesInGame.Add(candy);
            candyBoxes[candyBox].Fill = candyBrush;
        }

        // Check if player got hit by an enemy
        private void RecalculateCollision(object sender, EventArgs e)
        {
            var playerBounds = BoundsRelativeTo(playerBox, level1);

            foreach (var enemyBox in enemyBoxes)
            {
                var enemy = BoundsRelativeTo(enemyBox, level1);
                if (playerBounds.IntersectsWith(enemy))
                    if (!gameOverBool)
                    {
                        var player = new SoundPlayer(Properties.Resources.died);
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

            enemyBoxes.Clear();
        }

        // Ophalen Rect gegevens van bepaald element
        public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        {
            return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        }
    }
}