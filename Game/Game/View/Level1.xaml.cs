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
        private Rectangle rectangle;

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
            Canvas.SetLeft(rectangle, player.Locatie.X);
            Canvas.SetTop(rectangle, player.Locatie.Y);
            rectangle.Width = player.Size.X;
            rectangle.Height = player.Size.Y;
            rectangle.Fill = Brushes.Blue;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            world = new World();
            rectangle = new Rectangle();
            level1.Children.Add(rectangle);
            world.StartGame();
        }
    }
}
