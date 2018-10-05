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

namespace MovementTest
{
    /// <summary>
    /// Interaction logic for Pause.xaml
    /// </summary>
    /// 

    public partial class Pause : Window
    {
        public bool waarde = false;
        public Pause()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            waarde = true;
            this.Close();

            
        }
    }
}
