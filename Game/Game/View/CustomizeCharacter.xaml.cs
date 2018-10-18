using System.Windows;
using System.Windows.Controls;

namespace Game
{
    /// <summary>
    ///     Interaction logic for CustomizeCharacter.xaml
    /// </summary>
    public partial class CustomizeCharacter : Window
    {
        public static string character = "";
        private int player = 1;

        public CustomizeCharacter()
        {
            InitializeComponent();

            Ad.Opacity = 1;
            El.Opacity = 0.5;
            Pi.Opacity = 0.5;
        }

        // Choose character handling
        private void character_Click(object sender, RoutedEventArgs e)
        {
            var targetButton = sender as Button;
            character = targetButton.Name;

            if (targetButton.Name == "Adventure")
                player = 1;
            else if (targetButton.Name == "Elf")
                player = 2;
            else if (targetButton.Name == "Pirate")
                player = 3;
            else
                player = 1;

            if (player == 1)
            {
                Ad.Opacity = 1;
                El.Opacity = 0.5;
                Pi.Opacity = 0.5;
            }
            else if (player == 2)
            {
                Ad.Opacity = 0.5;
                El.Opacity = 1;
                Pi.Opacity = 0.5;
            }
            else if (player == 3)
            {
                Ad.Opacity = 0.5;
                El.Opacity = 0.5;
                Pi.Opacity = 1;
            }
        }

        // Back button handling
        private void back_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }
    }
}