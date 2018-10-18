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

        // Click on easy difficulty
        private void easy_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 1;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        // Click on normal difficulty
        private void normal_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 2;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        // Click on hard difficulty
        private void hard_Click(object sender, RoutedEventArgs e)
        {
            Difficulty = 3;
            var level1 = new Level1();
            level1.Show();
            Close();
        }

        // Click on back button
        private void back_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }
    }
}