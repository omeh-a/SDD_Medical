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
using System.IO;

namespace SDD_term_4
{
    /// <summary>
    /// Interaction logic for Apt_Creation.xaml
    /// </summary>
    public partial class Apt_Creation : Window
    {
        public Apt_Creation()
        {
            InitializeComponent();
        }

        private void AptCreateButton_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointment(this.DoctorInput.Text, this.PatientInput.Text, this.DatePicker.Text, this.InfoInput.Text, this.DurationInput.Text, this.TimeInput.Text);
            MessageBox.Show($" Appointment Successfully created for \"{PatientInput.Text}\" under Doctor \"{DoctorInput.Text}\" on {DatePicker.Text}");
        }

        public void MakeAppointment(string doctor, string patient, string date, string details, string duration, string time)
        {
            // dates must be reformatted because slashes are not allowed in filenames
            string reformattedDate = (string)date;
            reformattedDate += '$';
            string finalDate = "";
            int d = 0;
            while (reformattedDate[d] != '$' )
            {
                if (reformattedDate[d] != '/')
                {
                    finalDate += reformattedDate[d];
                } else if (reformattedDate[d] == '/')
                {
                    finalDate += ',';
                }
                d++;
            }
            
            // Filenames are formatted for machine reading to be efficient
            string directory = $"{Properties.Settings.Default.DatabaseDirectory}{doctor}#{patient}#{finalDate}$.apt";
            try
            {
                using (StreamWriter w = new StreamWriter(directory))
                {
                    w.WriteLine("~ APPOINTMENT  Do not edit any hashes or dollar signs $");
                    w.WriteLine($"{doctor}#{patient}#{(string)date}#{details}#{duration}#{time}$");
                    //{(string)date}
                    w.Close();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
        
    }
    public class TextInputToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Always test MultiValueConverter inputs for non-null
            // (to avoid crash bugs for views in the designer)
            if (values[0] is bool && values[1] is bool)
            {
                bool hasText = !(bool)values[0];
                bool hasFocus = (bool)values[1];

                if (hasFocus || hasText)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
