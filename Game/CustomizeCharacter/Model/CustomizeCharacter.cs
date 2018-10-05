using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomizeCharacter.Model
{
    public partial class CustomizeCharacter : Window
    {
        public CustomizeCharacter()
        {
            
        }
        private void character_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You chose " + ((Button)sender).Content.ToString());
        }
    }
}
