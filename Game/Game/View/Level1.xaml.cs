using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    public partial class Level1 : Window
    {
        private World world;
        private Rectangle playerBox, ghostBox, skeletonBox, zombieBox, worldLight;
        private Ellipse playerLight;
        private List<Rectangle> enemyBoxes = new List<Rectangle>();
        public bool pausebool = false;
        private bool gameOverBool = false;

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
        }

        public Level1()
        {
            InitializeComponent();

            timer.Tick += RecalculateCollision;
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timer.Start();
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
                }
            }
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Level1 levelreload = new Level1();
            levelreload.Show();
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

            double x = player.Size.X * 2;
            double y = player.Size.Y * 2;

            Canvas.SetZIndex(playerLight, 6);
            Canvas.SetLeft(playerLight, player.Position.X - x - 55);
            Canvas.SetTop(playerLight, player.Position.Y - y - 55);
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

            Canvas.SetLeft(worldLight, 0);
            Canvas.SetTop(worldLight, 0);
            worldLight.Width = 1280;
            worldLight.Height = 704;
            worldLight.Fill = Brushes.Black;
            worldLight.Opacity = 0.75;
            Canvas.SetZIndex(worldLight, 5);

            Ghost ghost = world.Ghost;
            enemyBoxes.Add(ghostBox);
            Canvas.SetLeft(ghostBox, ghost.Position.X);
            Canvas.SetTop(ghostBox, ghost.Position.Y);
            ghostBox.Width = ghost.Size.X;
            ghostBox.Height = ghost.Size.Y;
            ImageBrush ghostBrush = new ImageBrush();
            ghostBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + ghost.Image, UriKind.RelativeOrAbsolute));
            ghostBox.Fill = ghostBrush;

            Skeleton skeleton = world.Skeleton;
            enemyBoxes.Add(skeletonBox);
            Canvas.SetLeft(skeletonBox, skeleton.Position.X);
            Canvas.SetTop(skeletonBox, skeleton.Position.Y);
            skeletonBox.Width = skeleton.Size.X;
            skeletonBox.Height = skeleton.Size.Y;
            ImageBrush skeletonBrush = new ImageBrush();
            skeletonBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + skeleton.Image, UriKind.RelativeOrAbsolute));
            skeletonBox.Fill = skeletonBrush;

            Zombie zombie = world.Zombie;
            enemyBoxes.Add(zombieBox);
            
            Canvas.SetLeft(zombieBox, zombie.Position.X);
            Canvas.SetTop(zombieBox, zombie.Position.Y);
            zombieBox.Width = zombie.Size.X;
            zombieBox.Height = zombie.Size.Y;
            ImageBrush zombieBrush = new ImageBrush();
            zombieBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + zombie.Image, UriKind.RelativeOrAbsolute));
            zombieBox.Fill = zombieBrush;
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
                        exit.Visibility = Visibility.Visible;
                        pausemenu.Opacity = 0.8;
                        died.Visibility = Visibility.Visible;
                        plaatje.Visibility = Visibility.Visible;
                        world.TimerPause();
                        gameOverBool = true;
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
            world = new World();

            foreach (var child in level1.Children)
            {
                if(child is Image)
                {
                    Image obstacle = (Image)child;
                    if(obstacle.IsEnabled)
                        world.obstacles.Add(new Obstacle(obstacle));
                }
            }

            ghostBox = new Rectangle();
            level1.Children.Add(ghostBox);

            skeletonBox = new Rectangle();
            level1.Children.Add(skeletonBox);

            zombieBox = new Rectangle();
            level1.Children.Add(zombieBox);

            playerBox = new Rectangle();
            level1.Children.Add(playerBox);

            worldLight = new Rectangle();
            level1.Children.Add(worldLight);

            playerLight = new Ellipse();
            level1.Children.Add(playerLight);

            world.StartGame();
        }
    }
}
