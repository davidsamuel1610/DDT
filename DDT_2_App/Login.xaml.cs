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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            //WebBrowser browser1 = new WebBrowser();
            //browser1.Source = new Uri("http://mc:1482/aspx?UserId=Iz001&MatchId=1");
           // string Request = ;
            Browser12.Navigate(new Uri(AppResources.Server + "Login.aspx?Type=Login&Name=" + UserId.Text + "&Password=" + Password.Text));
            //string Temp = Browser12.SaveToString();
            string Data = null;// 
            int loadbrowser = 0;
            while (Browser12.SaveToString().Length < 1) { loadbrowser++; }

            Data = Browser12.SaveToString();

            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Login Success"))
            {
                string[] variables = DataNeeded.Split(',');
                AppResources.UserID = variables[1];
                AppResources.UserType = variables[3];
                if (AppResources.UserType == "r") { NavigationService.Navigate(new Uri("/Ref.xaml", UriKind.Relative)); } else if (AppResources.UserType == "u") { NavigationService.Navigate(new Uri("/User.xaml", UriKind.Relative)); }
            }
            else Response.Text = DataNeeded;
           
        }

        private void Browser12_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void UserId_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            UserId.Text = "";
        }

        private void Password_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Password.Text = "";
        }

    }
}