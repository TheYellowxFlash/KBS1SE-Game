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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MovementTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double x, y;
        private double maxWidth, maxHeight;

        DispatcherTimer timer = new DispatcherTimer();

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            maxWidth = PlayingField.ActualWidth;
            maxHeight = PlayingField.ActualHeight;
            MessageBox.Show("Width= " + maxWidth + "Height: " + maxHeight);
        }

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0,0,0,0,1);
            timer.Start();

            
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {

            if (Keyboard.IsKeyDown(Key.Down))
            {
                y += 1;
                Canvas.SetTop(Player, y);
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                y -= 1;
                Canvas.SetTop(Player, y);
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                x -= 1;
                Canvas.SetLeft(Player, x);
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                x += 1;
                Canvas.SetLeft(Player, x);
            }
        }

    }
}
