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
        private double x, y, xE, yE, pX, pY, startPosX, startPosY;
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

            //startPosX = Canvas.GetLeft(enemy2);
            //startPosY = Canvas.GetTop(enemy2);

            timer.Tick += TimerOnTick;
            //timer.Tick += RecalculateCollision;
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

            //pX = Canvas.GetLeft(Player);
            //pY = Canvas.GetTop(Player);

            //xE = Canvas.GetLeft(enemy2);
            //yE = Canvas.GetTop(enemy2);

            //if (pX < xE)
            //{
            //    xE -= .5;
            //}
            //else
            //{
            //    xE += .5;
            //}

            //if (pY < yE)
            //{
            //    yE -= .5;
            //}
            //else
            //{
            //    yE += .5;
            //}

            //Canvas.SetLeft(enemy2, xE);
            //Canvas.SetTop(enemy2, yE);
        }

        //public void RecalculateCollision(object sender, EventArgs e)
        //{
        //    Rect r1 = BoundsRelativeTo(Player, PlayingField);
        //    Rect r2 = BoundsRelativeTo(enemy, PlayingField);
        //   Rect r3 = BoundsRelativeTo(enemy2, PlayingField);

        //    if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3))
        //    {
        //        MessageBox.Show("Game over");

        //        // hier moet de reset functie
        //        x = 0;
        //        y = 0;
        //        xE = startPosX;
        //        yE = startPosY;
        //        Canvas.SetLeft(enemy2, xE);
        //        Canvas.SetTop(enemy2, yE);
        //        Canvas.SetLeft(Player, x);
        //        Canvas.SetTop(Player, y);
        //    }
        //}

        //public static Rect BoundsRelativeTo(FrameworkElement element, Visual relativeTo)
        //{
        //    return element.TransformToVisual(relativeTo).TransformBounds(new Rect(element.RenderSize));
        //}

    }
}
