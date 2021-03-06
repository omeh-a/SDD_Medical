﻿using System;
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
    /// Interaction logic for AppointmentViewer.xaml
    /// </summary>
    public partial class AppointmentViewer : Window
    {
        public AppointmentViewer()
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
            List<appointment> validResults = new List<appointment>();
            List<string> filesList = results.ToList();
            int count = (filesList.Count);
            int x = 0;


           
            

            while (x < count)
            {
                validResults.Add(pathToApt(results[x]));
                x++;
            }

            

            int u = 0;
            string toShow = "";
            
            while (u < validResults.Count)
            {
            toShow += $"{validResults[u].patient} with Doctor {validResults[u].doctor} on {validResults[u].date} " +
            $", {validResults[u].info} // at {validResults[u].time}\n";
            u++;
            }
            
            

            this.ResultBox.Text = toShow;

        }
    }

    public struct appointment
    {
        public string doctor;
        public string patient;
        public string date;
        public string info;
    }
    



}
