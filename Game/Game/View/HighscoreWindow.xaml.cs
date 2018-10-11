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
            foreach(XmlNode node in highScoreXML.DocumentElement)
            {
                MessageBox.Show(node.ChildNodes.ToString());
            }
            MessageBox.Show(highScoreXML.ToString());
            //highScoreXML.

        }
    }
}
