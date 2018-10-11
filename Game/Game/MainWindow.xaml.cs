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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            //MovementTest.MainWindow m = new MovementTest.MainWindow();
            Level1 level1 = new Level1();
            level1.Show();
            this.Close();
        }
        
        private void customize_Click(object sender, RoutedEventArgs e)
        {
            CustomizeCharacter CustomCharacter = new CustomizeCharacter();
            CustomCharacter.Show();
            this.Close();
        }

        //private void highscore_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
