using System.Windows;

namespace Game.View
{
    /// <summary>
    ///     Interaction logic for ChooseDifficulty.xaml
    /// </summary>
    public partial class ChooseDifficulty : Window
    {
        public static int Difficulty;

        public ChooseDifficulty()
        {
            InitializeComponent();
        }

        private void easy_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 1;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        private void medium_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 2;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        private void hard_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 3;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }
    }
}