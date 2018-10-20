using System.Windows;

namespace Game.View
{
    /// <summary>
    ///     Interaction logic for ChooseDifficulty.xaml
    /// </summary>
    public partial class ChooseDifficulty : Window
    {
        public static int difficulty;

        public ChooseDifficulty()
        {
            InitializeComponent();
        }

        private void LoadLevel(int difficulty)
        {
            ChooseDifficulty.difficulty = difficulty;
            try
            {
                var level1 = new Level1();
                level1.Show();
                Close();
            }
            catch
            {
            }
        }

        // Click on easy difficulty
        private void easy_Click(object sender, RoutedEventArgs e)
        {
            LoadLevel(1);
        }

        // Click on normal difficulty
        private void normal_Click(object sender, RoutedEventArgs e)
        {
            LoadLevel(2);
        }

        // Click on hard difficulty
        private void hard_Click(object sender, RoutedEventArgs e)
        {
            LoadLevel(3);
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