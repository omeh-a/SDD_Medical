// Matthew Rossouw
// SDD Term 4
// Main Menu c# code for Assessment Task 1
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SDD_term_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void rosterbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.RosterDirectory);

            if (File.Exists(Properties.Settings.Default.RosterDirectory))
            {
                RosterWindowXML rWindow = new RosterWindowXML();
                rWindow.Show();
            } else
            {
                MessageBox.Show("Roster not found");
                
            }
        }

        private void aptviewerbutton_Click(object sender, RoutedEventArgs e)
        {
            /*AppointmentViewer aptWindow = new AppointmentViewer();
            aptWindow.Show();*/
        }


   
        private void settingsButton_Click_1(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void newaptbutton_Click(object sender, RoutedEventArgs e)
        {
            Apt_Creation aptcreator = new Apt_Creation();
            aptcreator.Show();
        }

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow newSearch = new SearchWindow();
            newSearch.Show();
        }
    }
}



