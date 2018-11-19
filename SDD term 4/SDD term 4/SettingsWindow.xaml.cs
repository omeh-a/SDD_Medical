// Matthew Rossouw
// SDD Term 4
// Settings Window c# code for Assessment Task 1
// Year 12, 2018/19

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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            
        }

        private void rosterloc_change_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.RosterDirectory = this.Roster_location_box.Text;
        }



        private void OnExit(object SettingsWindow, ExitEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void dbloc_change_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DatabaseDirectory = this.Database_location_box.Text;
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings saved successfully!");
        }
    }
}
