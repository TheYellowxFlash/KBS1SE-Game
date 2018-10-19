using System;
using System.Windows;
using System.Xml;

namespace Game.View
{
    /// <summary>
    ///     Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        public HighscoreWindow()
        {
            InitializeComponent();
        }

        // Get scores from xml document
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var highScoreXML = new XmlDocument();
            highScoreXML.LoadXml("XML/Scores.xml");

            var root = highScoreXML.FirstChild.NextSibling;

            var position = 1;
            foreach (XmlNode scores in root.ChildNodes)
            {
                var name = scores.ChildNodes[0].InnerText;
                var score = scores.ChildNodes[1].InnerText;
                txbHighscoresNames.Text += position++ + ": " + name + Environment.NewLine;
                txbHighscoresScores.Text += ": " + score + Environment.NewLine;
            }
        }

        // Button to exit highscore screen
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainWindow();
            mainMenu.Show();
            Close();
        }
    }
}