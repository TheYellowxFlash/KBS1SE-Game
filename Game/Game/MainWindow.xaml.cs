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

        // Playbutton clicked
        private void play_Click(object sender, RoutedEventArgs e)
        {
            var chooseDifficulty = new ChooseDifficulty();
            chooseDifficulty.Show();
            Close();
        }

        // Customize button clicked
        private void customize_Click(object sender, RoutedEventArgs e)
        {
            var CustomCharacter = new CustomizeCharacter();
            CustomCharacter.Show();
            Close();
        }

        // Highscore button clicked
        private void highscore_Click(object sender, RoutedEventArgs e)
        {
            var h = new HighscoreWindow();
            h.Show();
            Close();
        }

        // Exit button clicked
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}