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
        private Rectangle playerBox, ghostBox;

        private List<Obstacle> obstacles = new List<Obstacle>();

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
            playerBox.Fill = Brushes.Blue;

            Ghost ghost = world.Ghost;
            Canvas.SetLeft(ghostBox, ghost.Position.X);
            Canvas.SetTop(ghostBox, ghost.Position.Y);
            ghostBox.Width = ghost.Size.X;
            ghostBox.Height = ghost.Size.Y;
            ghostBox.Fill = Brushes.Blue;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var child in level1.Children)
            {
                if(child is Image)
                {
                    Image obstacle = (Image)child;
                    if(obstacle.IsEnabled)
                        obstacles.Add(new Obstacle(obstacle));
                }
            }
            world = new World();
            playerBox = new Rectangle();
            level1.Children.Add(playerBox);
            ghostBox = new Rectangle();
            level1.Children.Add(ghostBox);
            world.StartGame();
        }
    }
}
