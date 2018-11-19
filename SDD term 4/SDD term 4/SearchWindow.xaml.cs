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
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

          
        private void PatCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.PatCheckBox.IsChecked = true;
            this.DocCheckBox.IsChecked = false;
        }

        private void DocCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.PatCheckBox.IsChecked = false;
            this.DocCheckBox.IsChecked = true;
        }
    }

    

}
