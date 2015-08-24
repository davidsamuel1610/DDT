using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using DDT_2_App.Resources;

namespace DDT_2_App
{
    public partial class Ref : PhoneApplicationPage
    {
        public int scoreA = 0, scoreB = 0, yellowA = 0, yellowB = 0, redA = 0, redB = 0;
        List<Fixture> Fixtures = new List<Fixture>();

        public Ref()
        {
            PopulateFixtures();
            //SelFix.ItemsSource = Fixtures;
            InitializeComponent();
            
        }

        private void PopulateFixtures()
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Fixture.aspx"));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            string[] fixes = DataNeeded.Split('|');
            foreach (string fix in fixes)
            {
                if (fix.Length > 2)
                {
                    string[] game = fix.Split(',');
                    Fixture TGame = new Fixture();
                    TGame.idfixture = game[0]; TGame.TeamA = game[1]; TGame.TeamB = game[2];
                    Fixtures.Add(TGame);
                }
            }
        }

        
        private void start_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            //browser1.Source = new Uri("http://mc:1482/aspx?UserId=Iz001&MatchId=1");
            browser1.Navigate(new Uri(AppResources.Server+"Start.aspx?UserId="+AppResources.UserID+"&MatchId="+AppResources.GameId));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            string output = "";
            if (DataNeeded.Contains("Has Started"))
            {
                string[] MatchInfo = DataNeeded.Split(',');
                AppResources.TeamA = MatchInfo[1];
                AppResources.TeamB = MatchInfo[2];
                //AppResources.GameId = MatchInfo[3];
                output = MatchInfo[0];
            }
            else output = DataNeeded;

            Commands.Text = output;
        }

        private void GoalA_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Goal.aspx?teamScoring=" + "A" + "&MatchId=" + AppResources.GameId));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Score Updated"))
            {
                scoreA++;
                ScoreA.Text = String.Format("{0}",scoreA);
            }
            else MessageBox.Show("Action Failed");
        }


        private void GoalB_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Goal.aspx?teamScoring=" + "B" + "&MatchId=" + AppResources.GameId));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Score Updated"))
            {
                scoreB++;
                ScoreB.Text = String.Format("{0}", scoreB);
            }
            else MessageBox.Show("Action Failed");
        }

        private void YellowA_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Card.aspx?Team=" + AppResources.TeamA + "&CardType=Yellow"));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Success!"))
            {
                yellowA++;
                YellowAtxt.Text = String.Format("{0}", yellowA);
            }
            else MessageBox.Show("Action Failed");
        }

        private void YellowB_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Card.aspx?Team=" + AppResources.TeamB + "&CardType=Yellow"));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Success!"))
            {
                yellowB++;
                YellowBtxt.Text = String.Format("{0}", yellowB);
            }
            else MessageBox.Show("Action Failed");
        }

        private void RedA_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Card.aspx?Team=" + AppResources.TeamA + "&CardType=Red"));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Success!"))
            {
                redA++;
                RedAtxt.Text = String.Format("{0}", redA);
            }
            else MessageBox.Show("Action Failed");
        }

        private void RedB_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            browser1.Navigate(new Uri(AppResources.Server + "Card.aspx?Team=" + AppResources.TeamB + "&CardType=Red"));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            if (DataNeeded.Contains("Success!"))
            {
                redB++;
                RedBtxt.Text = String.Format("{0}", redB);
            }
            else MessageBox.Show("Action Failed");
        }

        private void FixtureId_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FixtureId.Text = "";
        }

        private void Load_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Fixture Match in Fixtures) 
            {
                if (Match.idfixture == FixtureId.Text) 
                {
                    TeamA.Text = Match.TeamA;
                    TeamB.Text = Match.TeamB;
                    AppResources.GameId = Match.idfixture;
                }
            }
        }

        private void FixtureId_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Fixture Match in Fixtures)
            {
                if (Match.idfixture == FixtureId.Text)
                {
                    TeamA.Text = Match.TeamA;
                    TeamB.Text = Match.TeamB;
                    AppResources.GameId = Match.idfixture;
                }
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser browser1 = new WebBrowser();
            //browser1.Source = new Uri("http://mc:1482/aspx?UserId=Iz001&MatchId=1");
            browser1.Navigate(new Uri(AppResources.Server + "Stop.aspx?UserId=" + AppResources.UserID + "&MatchId=" + AppResources.GameId));
            int loadbrowser = 0;
            while (browser1.SaveToString().Length < 1) { loadbrowser++; }
            string Data = browser1.SaveToString();
            string[] RawHtmlSplit = Data.Split('`');
            string DataNeeded = RawHtmlSplit[1];
            string output = "";
            if (DataNeeded.Contains("Has Started"))
            {
                string[] MatchInfo = DataNeeded.Split(',');
                AppResources.TeamA = MatchInfo[1];
                AppResources.TeamB = MatchInfo[2];
                //AppResources.GameId = MatchInfo[3];
                output = MatchInfo[0];
            }
            else output = DataNeeded;

            Commands.Text = output;
        }


    }
}