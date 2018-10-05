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

namespace CustomizeCharacter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string character = "";
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void character_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You chose " + ((Button)sender).Name.ToString());
            Button targetButton = (sender as Button);
            if(targetButton != null && targetButton.Name == "female") {
                character = "Female";
            }
            else if (targetButton != null && targetButton.Name == "male")
            {
                character = "Male";
            }
          
            MessageBox.Show(character);
        }
    }
}
