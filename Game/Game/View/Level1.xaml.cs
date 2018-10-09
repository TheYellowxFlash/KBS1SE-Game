using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game
{
    public partial class Level1 : Window
    {
        private World world;
        private Rectangle playerBox, ghostBox, skeletonBox, zombieBox;
        private Ellipse playerLight;

        DispatcherTimer timer = new DispatcherTimer();

        public Level1()
        {
            InitializeComponent();

            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (world != null)
            {
                UpdateWorld();
            }
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

            //double x = Canvas.GetLeft(playerBox);
            //double y = Canvas.GetTop(playerBox);

            Ghost ghost = world.Ghost;
            Canvas.SetLeft(ghostBox, ghost.Position.X);
            Canvas.SetTop(ghostBox, ghost.Position.Y);
            ghostBox.Width = ghost.Size.X;
            ghostBox.Height = ghost.Size.Y;
            ImageBrush ghostBrush = new ImageBrush();
            ghostBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + ghost.Image, UriKind.RelativeOrAbsolute));
            ghostBox.Fill = ghostBrush;

            Skeleton skeleton = world.Skeleton;
            Canvas.SetLeft(skeletonBox, skeleton.Position.X);
            Canvas.SetTop(skeletonBox, skeleton.Position.Y);
            skeletonBox.Width = skeleton.Size.X;
            skeletonBox.Height = skeleton.Size.Y;
            ImageBrush skeletonBrush = new ImageBrush();
            skeletonBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + skeleton.Image, UriKind.RelativeOrAbsolute));
            skeletonBox.Fill = skeletonBrush;

            Zombie zombie = world.Zombie;
            Canvas.SetLeft(zombieBox, zombie.Position.X);
            Canvas.SetTop(zombieBox, zombie.Position.Y);
            zombieBox.Width = zombie.Size.X;
            zombieBox.Height = zombie.Size.Y;
            ImageBrush zombieBrush = new ImageBrush();
            zombieBrush.ImageSource = new BitmapImage(new Uri(@"../../PropIcons/" + zombie.Image, UriKind.RelativeOrAbsolute));
            zombieBox.Fill = zombieBrush;
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
            playerBox = new Rectangle();
            level1.Children.Add(playerBox);

            ghostBox = new Rectangle();
            level1.Children.Add(ghostBox);

            skeletonBox = new Rectangle();
            level1.Children.Add(skeletonBox);

            zombieBox = new Rectangle();
            level1.Children.Add(zombieBox);

            world.StartGame();
        }
    }
}
