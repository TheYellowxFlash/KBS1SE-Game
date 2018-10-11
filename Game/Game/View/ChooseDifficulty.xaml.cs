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

namespace Game.View
{
    /// <summary>
    /// Interaction logic for ChooseDifficulty.xaml
    /// </summary>
    public partial class ChooseDifficulty : Window
    {
        public static int Difficulty = 0;

        public ChooseDifficulty()
        {
            InitializeComponent();
        }

        private void easy_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 1;

            Level1 level1 = new Level1();
            level1.Show();
            this.Close();
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 2;
            Level1 level1 = new Level1();
            level1.Show();
            this.Close();
        }

        private void hard_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 3;
            Level1 level1 = new Level1();
            level1.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();
        }
    }
}
