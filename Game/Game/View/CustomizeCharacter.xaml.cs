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
    /// Interaction logic for CustomizeCharacter.xaml
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

        private void character_Click(object sender, RoutedEventArgs e)
        {
        Button targetButton = (sender as Button);
        character = targetButton.Name;

            if(targetButton.Name == "Adventure")
            {
                player = 1;
            } else if (targetButton.Name == "Elf")
            {
                player = 2;
            } else if (targetButton.Name == "Pirate")
            {
                player = 3;
            } else
            {
                player = 1;
            }

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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();
        }

    }
}
