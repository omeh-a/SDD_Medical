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



        public struct appointment
        {
            public string doctor;
            public string patient;
            public string date;
            public string info;
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
                                i++;
                            }
                        }
                    }

                } 
            } catch (Exception er) { MessageBox.Show(er.Message); }

            return apt;
        }

            
        

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Looking for all .apt files
            string[] results = Directory.GetFiles(Properties.Settings.Default.DatabaseDirectory, @"*.apt");
            List<appointment> validResults = new List<appointment>();
            List<string> filesList = results.ToList();
            int count = (filesList.Count);
            string target = this.SearchBox.Text;
            int x = 0;


            // Scouring results for target
            
            while (x < count)
            {
                if (results[x].ToUpper().Contains($"{target.ToUpper()}") == true)
                {
                    validResults.Add(pathToApt(results[x]));
                }
                x++;
            }

            // doctor/patient check

            int u = 0;
            string toShow = "";
            if (this.DocCheckBox.IsChecked == true)
            {
                while (u < validResults.Count)
                {
                    if (validResults[u].doctor.ToUpper() == target.ToUpper())
                    {
                        toShow += $"{validResults[u].patient} with Doctor {validResults[u].doctor} on {validResults[u].date}: {validResults[u].info}\n";
                    }
                    u++;
                }
            }
            else if (this.PatCheckBox.IsChecked == true)
            {
                while (u < validResults.Count)
                {
                    if (validResults[u].patient.ToUpper() == target.ToUpper())
                    {
                        toShow += $"{validResults[u].patient} with Doctor {validResults[u].doctor} on {validResults[u].date}: {validResults[u].info}\n";
                    }
                    u++;
                }
            }

            this.ResultBox.Text = toShow;

        }
        



    }
}






