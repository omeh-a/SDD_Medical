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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }
        



        public struct appointment
        {
            public string doctor;
            public string patient;
            public string date;
            public string info;
            public string duration;
            public string time;
        }

        public appointment pathToApt(string directory)
        {
            appointment apt = new appointment();
            string line;
            int i = 0;
            int e = 0;

            try
            {
                using (StreamReader r = new StreamReader(directory))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        e = 0;
                        i = 0;
                        if (line[0] != '~')
                        {
                            while (line[i] != '$')
                            {
                                if (line[i] == '#')
                                {
                                    e++;
                                }
                                else if (e == 0)
                                {
                                    apt.doctor += line[i];
                                }
                                else if (e == 1)
                                {
                                    apt.patient += line[i];
                                }
                                else if (e == 2)
                                {
                                    apt.date += line[i];
                                }
                                else if (e == 3)
                                {
                                    apt.info += line[i];
                                }
                                else if (e == 4)
                                {
                                    apt.duration += line[i];
                                }
                                else if (e == 5)
                                {
                                    apt.time += line[i];
                                }
                                i++;
                            }
                        }
                    }

                }
            }
            catch (Exception er) { MessageBox.Show(er.Message); }

            return apt;
        }




        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Looking for all .apt files
            string[] results = Directory.GetFiles(Properties.Settings.Default.DatabaseDirectory, @"*.apt");
            List<string> validResults = new List<string>();
            List<string> filesList = results.ToList();
            int count = (filesList.Count);
            string targetDate = this.DatePicker.Text;
            string targetDoc = this.DocBox.Text;
            string targetPat = this.PatBox.Text;
            string targetTime = this.TimeBox.Text;
            int x = 0;


            // Scouring results for target
                
                string finalDate = "";
                int d = 0;
                while (((targetDate[d] >= '0' && targetDate[d] <= '9') || (targetDate[d] == '/') || (targetDate[d] == ',')) && (d < 9))
                {
                    if (targetDate[d] != '/')
                    {
                        finalDate += targetDate[d];
                    }
                    else if (targetDate[d] == '/')
                    {
                        finalDate += ',';
                    }
                    d++;
                }
                targetDate = finalDate;
            

            while (x < count)
            {
                if (results[x].ToUpper().Contains($"{targetDoc.ToUpper()}") == true && results[x].ToUpper().Contains($"{targetDoc.ToUpper()}") && results[x].ToUpper().Contains($"{targetDate}"))
                {
                    validResults.Add(results[x]);
                }
                x++;
            }

            // doctor/patient check

            int u = 0;
                while (u < validResults.Count)
                {
                File.Delete(validResults[u]);
                u++;
                }
            MessageBox.Show($"Successfully deleted {u} files.");
        }
    }
}
