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
    /// Interaction logic for AppointmentViewer.xaml
    /// </summary>
    public partial class AppointmentViewer : Window
    {
        public AppointmentViewer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            SDD_term_4.AppointmentsDataSet appointmentsDataSet = ((SDD_term_4.AppointmentsDataSet)(this.FindResource("appointmentsDataSet")));
            // Load data into the table Appointments. You can modify this code as needed.
            SDD_term_4.AppointmentsDataSetTableAdapters.AppointmentsTableAdapter appointmentsDataSetAppointmentsTableAdapter = new SDD_term_4.AppointmentsDataSetTableAdapters.AppointmentsTableAdapter();
            appointmentsDataSetAppointmentsTableAdapter.Fill(appointmentsDataSet.Appointments);
            System.Windows.Data.CollectionViewSource appointmentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("appointmentsViewSource")));
            appointmentsViewSource.View.MoveCurrentToFirst();
        }

        private void appointmentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
