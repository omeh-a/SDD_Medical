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
    /// Interaction logic for RosterWindowXML.xaml
    /// </summary>
    public partial class RosterWindowXML : Window
    {
        public RosterWindowXML()
        {
            InitializeComponent();
            PopulateRoster(GetRoster());
        }


        public int DOC_NUM = Properties.Settings.Default.RosterDoctorCount;

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

        public void PopulateRoster(doctor[] d)
        {
            //This function turns the data extracted into viewable content
            int x = 0;

            TextBlock[] names = { this.Name1, this.Name2, this.Name3, this.Name4, this.Name5, this.Name6, this.Name7, this.Name8, this.Name9, this.Name10};
            TextBlock[] Mons = { this.Mon1, this.Mon2, this.Mon3, this.Mon4, this.Mon5, this.Mon6, this.Mon7, this.Mon8, this.Mon9, this.Mon10 };
            TextBlock[] Tues = { this.Tue1, this.Tue2, this.Tue3, this.Tue4, this.Tue5, this.Tue6, this.Tue7, this.Tue8, this.Tue9, this.Tue10 };
            TextBlock[] Weds = { this.Wed1, this.Wed2, this.Wed3, this.Wed4, this.Wed5, this.Wed6, this.Wed7, this.Wed8, this.Wed9, this.Wed10 };
            TextBlock[] Thus = { this.Thu1, this.Thu2, this.Thu3, this.Thu4, this.Thu5, this.Thu6, this.Thu7, this.Thu8, this.Thu9, this.Thu10 };
            TextBlock[] Fris = { this.Fri1, this.Fri2, this.Fri3, this.Fri4, this.Fri5, this.Fri6, this.Fri7, this.Fri8, this.Fri9, this.Fri10 };
            TextBlock[] Sats = { this.Sat1, this.Sat2, this.Sat3, this.Sat4, this.Sat5, this.Sat6, this.Sat7, this.Sat8, this.Sat9, this.Sat10 };
            TextBlock[] Suns = { this.Sun1, this.Sun2, this.Sun3, this.Sun4, this.Sun5, this.Sun6, this.Sun7, this.Sun8, this.Sun9, this.Sun10 };
            while (x < 10)
            {
                names[x].Text = d[x].name;
                if (d[x].mon == true) { Mons[x].Text = "PRESENT"; }
                if (d[x].tue == true) { Tues[x].Text = "PRESENT"; }
                if (d[x].wed == true) { Weds[x].Text = "PRESENT"; }
                if (d[x].thu == true) { Thus[x].Text = "PRESENT"; }
                if (d[x].fri == true) { Fris[x].Text = "PRESENT"; }
                if (d[x].sat == true) { Sats[x].Text = "PRESENT"; }
                if (d[x].sun == true) { Suns[x].Text = "PRESENT"; }

                x++;
            }
            


            return;
        }

        public doctor[] GetRoster()
        {
            // this function fetches data from roster.txt

            // the directory is fetched from settings.settings
            string directory = Properties.Settings.Default.RosterDirectory;

            // doctor d is a custom datastructure (struct)
            doctor[] d = new doctor[DOC_NUM];
            string line;
            int i = 0;
            int e = 0;
            int l = 0;


            try
            {
                using (StreamReader r = new StreamReader(directory))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        e = 0;
                        i = 0;
                        Console.Write(line + '\n');
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
                                    d[l].name += line[i];
                                }
                                else if (e == 1 && line[i] == '1')
                                {
                                    d[l].mon = true;
                                }
                                else if (e == 2 && line[i] == '1')
                                {
                                    d[l].tue = true;
                                }
                                else if (e == 3 && line[i] == '1')
                                {
                                    d[l].wed = true;
                                }
                                else if (e == 4 && line[i] == '1')
                                {
                                    d[l].thu = true;
                                }
                                else if (e == 5 && line[i] == '1')
                                {
                                    d[l].fri = true;
                                }
                                else if (e == 6 && line[i] == '1')
                                {
                                    d[l].sat = true;
                                }
                                else if (e == 7 && line[i] == '1')
                                {
                                    d[l].sun = true;
                                }
                                i++;
                            }
                            l++;
                        }
                    }
                }
            }

            // Shows an error message if something happens
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return d;
        }
        
    }


}