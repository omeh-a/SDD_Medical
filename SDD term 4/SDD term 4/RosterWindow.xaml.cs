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

namespace SDD_term_4
{
    /// <summary>
    /// Interaction logic for RosterWindow.xaml
    /// </summary>
    public partial class RosterWindow : Window
    {
        public RosterWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void GetRoster()
        {
            // File IO operations here

        }
    }


}
