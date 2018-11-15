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
    /// Interaction logic for RosterWindow.xaml
    /// </summary>
    public partial class RosterWindow : Window
    {
        public RosterWindow()
        {
            InitializeComponent();
        }

        public struct doctor
        {
                public string name;
                public bool mon;
                public bool tue;
                public bool wed;
                public bool thu;
                public bool fri;
                public bool sat;
                public bool sun;
            }
        
        

        public void GetRoster()
        {
            string directory = Properties.Settings.Default.RosterDirectory;
            

            try
            {
                using (StreamReader r = new StreamReader(directory))
                {
                    doctor[] d = new doctor[10];
                    int i = 0;
                    int e = 0;
                    int l = 0;
                    string intake;
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        // readline doesn't go char by char like the stream in C
                        // instead takes a whole line as a string

                        intake = line;
                        i = 0;
                        e = 0
                        while (line[i] != '\n') 
                        {
                            if (line[i] == '#') { e++; }
                            else if (intake[0] != '~')
                            {
                                if (intake[e] != '$')
                                {
                                    if (e == 0)
                                    {
                                        d[l].name += line;
                                    }
                                    else if (e == 1)
                                    {
                                        if (line[i] == '1') 
                                        {
                                            d[l].mon = true;
                                        }
                                        else
                                        {
                                            d[l].mon = false;
                                        }
                                        // note that if a date is not 0 nor 1, it will be set false
                                    }
                                    else if (e == 2)
                                    {
                                        if (line[i] == '1')
                                        {
                                            d[l].tue = true;
                                        }
                                        else
                                        {
                                            d[l].tue = false;
                                        }
                                    }
                            }
                            i++;
                        }
                        // doctor count
                        l++;
                    }
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }
    }


}
