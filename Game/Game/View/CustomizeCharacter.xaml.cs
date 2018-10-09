﻿using System;
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
        public string character = "";

        public CustomizeCharacter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void character_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You chose " + ((Button)sender).Name.ToString());
            Button targetButton = (sender as Button);
            
            character = targetButton.Name;

            MessageBox.Show(character);
        }
    }
}