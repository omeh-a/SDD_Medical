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
            RosterWindow rWindow = new RosterWindow();
            rWindow.Show();

            if (File.Exists("roster.txt") == true)
            {
                
            } else
            {
               // MessageBox.Show("Roster not found");
                
            }
        }

        private void aptviewerbutton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentViewer aptWindow = new AppointmentViewer();
            aptWindow.Show();
        }
    }
}



