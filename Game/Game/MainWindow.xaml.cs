using System.Windows;
using Game.View;

namespace Game
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            //MovementTest.MainWindow m = new MovementTest.MainWindow();
            //Level1 level1 = new Level1();
            var chooseDifficulty = new ChooseDifficulty();
            chooseDifficulty.Show();
            Close();
        }

        private void customize_Click(object sender, RoutedEventArgs e)
        {
            var CustomCharacter = new CustomizeCharacter();
            CustomCharacter.Show();
            Close();
        }

        private void highscore_Click(object sender, RoutedEventArgs e)
        {
            var h = new HighscoreWindow();
            h.Show();
            Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}