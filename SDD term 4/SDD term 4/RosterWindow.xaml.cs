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
    /// Interaction logic for RosterWindow.xaml
    /// </summary>
    public partial class RosterWindow : Window
    {
        public RosterWindow()
        {
            InitializeComponent();
        }

        
/*
        public void GetRoster()
        {
            string directory = Properties.Settings.Default.RosterDirectory;
            try
            {
                using (StreamReader r = new StreamReader(directory))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        ;
                    }
                }
            }
            

        }*/
    }


}
