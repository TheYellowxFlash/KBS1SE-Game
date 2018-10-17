using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Game.View
{
    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            XmlDocument highScoreXML = new XmlDocument();
            highScoreXML.Load("../../Scores.xml");

            XmlNode root = highScoreXML.FirstChild.NextSibling;

            int position = 1;
            foreach (XmlNode scores in root.ChildNodes)
            {
                string name = scores.ChildNodes[0].InnerText;
                string score = scores.ChildNodes[1].InnerText;
                txbHighscoresNames.Text += position++.ToString() + ": " + name + Environment.NewLine;
                txbHighscoresScores.Text += ": " + score + Environment.NewLine;
            }
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            this.Close();
        }
    }
}
