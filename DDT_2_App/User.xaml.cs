using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DDT_2_App.Resources;

namespace DDT_2_App
{
    public partial class User : PhoneApplicationPage
    {
        public User()
        {

            LogView = new WebBrowser();
            LogView.Navigate(new Uri(AppResources.Server + "League.aspx"));
            //int loadbrowser = 0;
            //while (LogView.SaveToString().Length < 1) { loadbrowser++; }
            //string x = LogView.SaveToString();
            //MessageBox.Show("Done");


            InitializeComponent();
        }
    }
}