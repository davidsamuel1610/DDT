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
    public partial class SignUp : PhoneApplicationPage
    {
        public SignUp()
        {
            
            InitializeComponent();
        }

        private void Name_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            Name.Text = "";
        }

        private void Password_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Password.Text = "";
        }

        private void e_mail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            e_mail.Text = "";
        }

        private void team_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            team.Text = "";
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser Browser12 = new WebBrowser();
            Browser12.Navigate(new Uri(AppResources.Server + "Login.aspx?Type=Register&Name=" + Name.Text + "&Password=" + Password.Text + "&email=" + e_mail.Text + "&team="+team.Text));
            //string Temp = Browser12.SaveToString();
            string Data = null;// 
            int loadbrowser = 0;
            while (Browser12.SaveToString().Length < 1) { loadbrowser++; }

            Data = Browser12.SaveToString();

            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if(DataNeeded.Contains("User Added"))
            {
                string[] Clean = DataNeeded.Split(',');
                UserData.Text = Clean[0] + "\n" + "Your New Username is: " + Clean[1];
            }
        }

        private void Cont_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }
    }
}