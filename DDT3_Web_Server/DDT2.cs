using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DDT2
{
    public class User
    {
        public DateTime Start;
        public string connect = "server=localhost;uid=root;" + "pwd=password;database=ddt_data";
        public DateTime Stop;
        public List<string> teamId = new List<string>();
        int position = 1;
        public List<int> points = new List<int>();
        public Dictionary<string, int> log = new Dictionary<string, int>();
        public Dictionary<string, int> sorted = new Dictionary<string, int>();
        public string login(string password, string userId)
        {
            MySqlConnection conn;
            
            try 
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                /*MySqlCommand select = new MySqlCommand(@"SELECT * FROM `league`", conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                List<string> data = new List<string>();
                while (reader.Read()) 
                {
                 //SELECT * FROM `users` WHERE `userId` = 'Iz001'
                    data.Add(String.Format("{0},{2},{3},{4},{5},{6},{7},{8},{9},{10}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10]));
                } 
                 */
                string command = String.Format("SELECT * FROM `users` WHERE `userId` = '{0}'", userId);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                List<string> data = new List<string>(1);
                while (reader.Read())
               {
                    data.Add(String.Format("{0}",reader[0]));
                    data.Add(String.Format("{0}",reader[1]));
                    data.Add(String.Format("{0}",reader[2]));
                   data.Add(String.Format("{0}",reader[3]));
               } if (data.Count() < 1) { return "`Username Does Not Exist!`"; }
                 if(password==data[3])
                {
                    conn.Close(); return "`Login Success" + ',' + data[0] + ',' + data[1] + ',' + data[2] + '`';
                }
                 conn.Close(); return "`incorrect password`";
                
            }
            catch(MySqlException ex)
            {
           return '`'+ex.Message+'`';
            }
        }

        public string singup(string name, string password,string email,string team)
        {
            Random jack = new Random();
            int id = jack.Next(001, 999);
           // INSERT INTO `ddt_data`.`users` (`userId`, `Name`, `password`) VALUES ('Me003', 'Mell', '123456789')
                MySqlConnection conn;
            string userId = String.Format("{0}{1}{2}", name[0], name[1], id);

            try 
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("INSERT INTO users (userId, Name, password,email,Team) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", userId, name, password,email,team);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                reader.Close();
                List<string> data = new List<string>();
                string command2 = String.Format("SELECT * FROM `users` WHERE `userId` = '{0}'", userId);
                select = new MySqlCommand(command2, conn);
                reader = select.ExecuteReader();

                while (reader.Read())
               {
                   data.Add(String.Format("{0}",reader[3]));
               }
                 if(password==data[0])
                {
                    conn.Close(); return "`User Added," + userId+'`';
                }
                 conn.Close();
                    return "`Data Missmatch`";
                
        }
            catch(MySqlException ex)
            {
                //conn.Close();
                return '`' + ex.Message + '`';
            //conn.Close();
            }
    }

        public string StartMatch(string MatchId, string Username)
        {
            int i = -1;
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `fixture` WHERE `idfixture` = {0}",MatchId);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                List<string> data = new List<string>();
                while (reader.Read())
                {
                    data.Add(String.Format("{0}",reader[i+=1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                }
                reader.Close();
                if (Username == data[6])
                {
                    Start = DateTime.Now;
                    conn.Close(); 
                    updatePlayed(data[3],data[5]);
                    return '`' + "Match: " + MatchId + "Has Started" +','+data[3]+','+data[5]+','+MatchId+ '`';
                }
                conn.Close();
                return "`User Not Authorised To Start Match`";

            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return '`' + ex.Message + '`';
                //conn.Close();
            }
        }

        private void updatePlayed(string teamName, string teamName2)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `league` WHERE `NAME` = '{0}'", teamName);
                string command2 = String.Format("SELECT * FROM `league` WHERE `NAME` = '{0}'", teamName2);
                MySqlCommand select = new MySqlCommand(command, conn);
                int score = 0;
                int score2 = 0;
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    int teamscore = Convert.ToInt32(reader[3]);
                    score = teamscore + 1;
                }
                select = new MySqlCommand(command2, conn);
                reader.Close();
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    int teamscore2 = Convert.ToInt32(reader[3]);
                    score2 = teamscore2 + 1;
                    
                }
                reader.Close();
                string update = String.Format("UPDATE `ddt_data`.`league` SET `PLD` = '{2}' WHERE `league`.`NAME` = '{3}';UPDATE `ddt_data`.`league` SET `PLD` = '{0}' WHERE `league`.`NAME` = '{1}'", score, teamName, score2, teamName2);
                select = new MySqlCommand(update, conn);
                reader = select.ExecuteReader();
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return;
                //conn.Close();
            }
        }

        public string StopMatch(string MatchId, string Username)
        {
            int i = -1;
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `fixture` WHERE `idfixture` = {0}", MatchId);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                string Winner = "";
                reader = select.ExecuteReader();
                string results="";
                List<string> data = new List<string>();
                
                    while (reader.Read())
                    {
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                        data.Add(String.Format("{0}", reader[i += 1]));
                    }
                    reader.Close();
                
                if (Username == data[6])
                {
                    Stop = DateTime.Now;
                    TimeSpan Duration = Stop-Start;
                    //conn.Close();
                    if(Convert.ToInt32(data[7]) > Convert.ToInt32(data[8]))
                    {
                        Winner = data[3];
                        results = '`' + Winner + '`';
                        results = '`' + Winner + " Has Won`";
                        string update = String.Format("UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+3,`W`=`W`+1  WHERE `league`.`NAME` = '{0}';UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+0,`L`=`L`+1  WHERE `league`.`NAME` = '{1}'", Winner,data[5]);
                        select = new MySqlCommand(update, conn);
                        reader = select.ExecuteReader();
                        reader.Close();
                    }
                    else if (Convert.ToInt32(data[7]) < Convert.ToInt32(data[8]))
                    {
                        Winner = data[5];
                        results = '`' + Winner + '`';
                        string update = String.Format("UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+3,`W`=`W`+1  WHERE `league`.`NAME` = '{0}';UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+0,`L`=`L`+1  WHERE `league`.`NAME` = '{1}'", Winner,data[3]);
                        select = new MySqlCommand(update, conn);
                        reader = select.ExecuteReader();
                        reader.Close();
                    }
                    else if (Convert.ToInt32(data[7]) == Convert.ToInt32(data[8]))
                    {
                        Winner = "Draw";
                        results = '`' + Winner + '`';
                        string update = String.Format("UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+1,`D`=`D`+1  WHERE `league`.`NAME` = '{0}';UPDATE `ddt_data`.`league` SET `PTS` =`PTS`+1,`D`=`D`+1  WHERE `league`.`NAME` = '{1}'", data[3], data[5]);
                        select = new MySqlCommand(update, conn);
                        reader = select.ExecuteReader();
                        reader.Close();
                    }
                    string updater = String.Format("UPDATE `ddt_data`.`fixture` SET `Winner` = '{0}' WHERE `fixture`.`idfixture` = {1}", Winner, MatchId);
                    select = new MySqlCommand(updater, conn);
                    reader = select.ExecuteReader();
                    reader.Close();
                    conn.Close();
                    return results;
                     
                }


                conn.Close();
                return "`User Not Authorised To Sop Match`";

            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return '`'+ex.Message+'`';
                //conn.Close();
            }
        }

        public string GiveCard(string Team, string Card)
        {
            int i = -1;
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `league` WHERE `NAME` = "+'"'+"{0}"+'"', Team);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                List<string> data = new List<string>();

                while (reader.Read())
                {
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                    data.Add(String.Format("{0}", reader[i += 1]));
                }
                reader.Close();
                if (Card == "Yellow")
                {
                    int current = Convert.ToInt32(data[11]);
                    string update = String.Format("UPDATE `ddt_data`.`league` SET `YellowC` = '{0}' WHERE `league`.`NAME` = "+'"'+"{1}"+'"', current+1, Team);
                    select = new MySqlCommand(update, conn);
                    reader = select.ExecuteReader();
                    reader.Close();
                    select = new MySqlCommand(command, conn);
                    reader = select.ExecuteReader();
                    List<string> data2 = new List<string>();

                    while (reader.Read())
                    {
                        i = -1;
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                    }

                    reader.Close();
                    int newscore = Convert.ToInt32(data2[11]);
                    if (current+1 == newscore)
                    {
                        return String.Format("`Success!,{0}`", newscore);
                    }
                    conn.Close();
                    return "`Error, Database Not Updated`";

                }
                else if (Card == "Red")
                {
                    int current = Convert.ToInt32(data[12]);
                    string update = String.Format("UPDATE `ddt_data`.`league` SET `RedC` = '{0}' WHERE `league`.`NAME` = " + '"' + "{1}" + '"', current + 1, Team);
                    select = new MySqlCommand(update, conn);
                    reader = select.ExecuteReader();
                    reader.Close();
                    select = new MySqlCommand(command, conn);
                    reader = select.ExecuteReader();
                    List<string> data2 = new List<string>();

                    while (reader.Read())
                    {
                        i = -1;
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                        data2.Add(String.Format("{0}", reader[i += 1]));
                    }

                    reader.Close();
                    int newscore = Convert.ToInt32(data2[12]);
                    if (current+1 == newscore)
                    {
                        return String.Format("`Success!,{0}`", newscore);
                    }
                    conn.Close();
                    return "`Error, Database Not Updated`";

                }
                else return "`Error Unable To Identify Card`";
            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return '`'+ex.Message+'`';
                //conn.Close();
            }
        }

        public string Log() 
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `league` ORDER BY `PTS` DESC");
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                string startTable = "`<table>\n<thead>\n<tr>\n<th>Pos.</th>\n<th>Team</th>\n<th>PLD</th>\n<th>W</th>\n<th>D</th>\n<th>L</th>\n<th>GF</th>\n<th>GA</th>\n<th>GD</th>\n<th>PTS</th>\n<th>YellowC</th>\n<th>RedC</th>\n</tr>\n</thead>\n<tbody>\n";
                string BodyTable = "";
                string EndTable = "</tbody>\n</table>`";
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    //1-11
                    string TeamRow = String.Format("<tr>\n<td>{11}</td>\n<td>{0}</td>\n<td>{1}</td>\n<td>{2}</td>\n<td>{3}</td>\n<td>{4}</td>\n<td>{5}</td>\n<td>{6}</td>\n<td>{7}</td>\n<td>{8}</td>\n<td>{9}</td>\n<td>{10}</td>\n</tr>\n", reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12],position);
                    teamId.Add(TeamRow);
                    position++;
                } foreach (string Team in teamId) 
                {
                    BodyTable = BodyTable + Team;
                }
                reader.Close();
                return startTable + BodyTable + EndTable;
               // SortLog();

            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return new List<string>() { ex.Message }.ToString() ;
                //conn.Close();
            }
            //string x="";
            //foreach (string a in teamId) 
            //{
            //    x += a;
            //}
            //return x;
        }

        public string Fix() 
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `fixture`");
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                string result="";
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    result = result + String.Format("{0},{1},{2}|",reader[0],reader[3],reader[5]);
                } 
                reader.Close();
                return '`'+result+'`';

            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return new List<string>() { ex.Message }.ToString();
                //conn.Close();
            }
        }

        private void SortLog() 
        {
            points.Sort();
            foreach(int x in points)
            {
            
            }
        
        }

        public string Goal(string matchId, string teamScoring)
        {
            
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `fixture` WHERE `idfixture` = {0}", matchId);
                MySqlCommand select = new MySqlCommand(command, conn);
                MySqlDataReader reader;
                reader = select.ExecuteReader();
                List<string> data = new List<string>();

                while (reader.Read())
                {
                    data.Add(String.Format("{0}", reader[0]));
                    data.Add(String.Format("{0}", reader[1]));
                    data.Add(String.Format("{0}", reader[2]));
                    data.Add(String.Format("{0}", reader[3]));
                    data.Add(String.Format("{0}", reader[4]));
                    data.Add(String.Format("{0}", reader[5]));
                    data.Add(String.Format("{0}", reader[6]));
                    data.Add(String.Format("{0}", reader[7]));
                    data.Add(String.Format("{0}", reader[8]));
                    data.Add(String.Format("{0}", reader[9])); 
                }
                reader.Close();
                if (teamScoring == "A")
                {
                    int current = Convert.ToInt32(data[7]);
                    string update = String.Format("UPDATE `ddt_data`.`fixture` SET `scoreA` = '{0}' WHERE `fixture`.`idfixture` = {1}", current + 1, matchId);
                    select = new MySqlCommand(update, conn);
                    reader = select.ExecuteReader();
                    reader.Close();
                    select = new MySqlCommand(command, conn);
                    reader = select.ExecuteReader();
                    List<string> data2 = new List<string>();

                    while (reader.Read())
                    {
                        data2.Add(String.Format("{0}", reader[0]));
                        data2.Add(String.Format("{0}", reader[1]));
                        data2.Add(String.Format("{0}", reader[2]));
                        data2.Add(String.Format("{0}", reader[3]));
                        data2.Add(String.Format("{0}", reader[4]));
                        data2.Add(String.Format("{0}", reader[5]));
                        data2.Add(String.Format("{0}", reader[6]));
                        data2.Add(String.Format("{0}", reader[7]));
                        data2.Add(String.Format("{0}", reader[8]));
                        data2.Add(String.Format("{0}", reader[9]));
                       
                    }

                    reader.Close();
                    int newscore = Convert.ToInt32(data2[7]);
                    if (current + 1 == newscore)
                    {
                        updateLeague(data2[3],data2[5]);
                        return "`Score Updated`";
                    }
                    conn.Close();
                    return "`Error, Database Not Updated`";

                }
                else if (teamScoring == "B")
                {
                    int current = Convert.ToInt32(data[8]);
                    string update = String.Format("UPDATE `ddt_data`.`fixture` SET `scoreB` = '{0}' WHERE `fixture`.`idfixture` = {1}", current + 1, matchId);
                    select = new MySqlCommand(update, conn);
                    reader = select.ExecuteReader();
                    reader.Close();
                    select = new MySqlCommand(command, conn);
                    reader = select.ExecuteReader();
                    List<string> data2 = new List<string>();

                    while (reader.Read())
                    {
                        data2.Add(String.Format("{0}", reader[0]));
                        data2.Add(String.Format("{0}", reader[1]));
                        data2.Add(String.Format("{0}", reader[2]));
                        data2.Add(String.Format("{0}", reader[3]));
                        data2.Add(String.Format("{0}", reader[4]));
                        data2.Add(String.Format("{0}", reader[5]));
                        data2.Add(String.Format("{0}", reader[6]));
                        data2.Add(String.Format("{0}", reader[7]));
                        data2.Add(String.Format("{0}", reader[8]));
                        data2.Add(String.Format("{0}", reader[9]));
                    }

                    reader.Close();
                    int newscore = Convert.ToInt32(data2[8]);
                    if (current + 1 == newscore)
                    {
                        updateLeague(data2[5],data2[3]);
                        return "`Score Updated`";
                    }
                    conn.Close();
                    return "`Error, Database Not Updated`";

                }
                else return "`Error Unable To Identify Team`";
            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return '`'+ex.Message+'`';
                //conn.Close();
            }
        }

        private void updateLeague(string teamName, string teamName2)
        {
            MySqlConnection conn;
            try
            {
                conn = new MySqlConnection(connect);
                conn.Open();

                string command = String.Format("SELECT * FROM `league` WHERE `NAME` = '{0}'",teamName);
                string command2 = String.Format("SELECT * FROM `league` WHERE `NAME` = '{0}'", teamName2);
                MySqlCommand select = new MySqlCommand(command, conn);
                int GFS = 0, GAS = 0, GDS = 0;
                int GAL = 0,GFL = 0, GDL = 0;
                MySqlDataReader reader = select.ExecuteReader();
                while (reader.Read()) 
                {
                    int team1 = Convert.ToInt32(reader[7]);
                    GFS =  team1+ 1;
                    GAS = Convert.ToInt32(reader[8]);
                } reader.Close();
                GDS = GFS - GAS;
                select = new MySqlCommand(command2, conn);
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    int team2 = Convert.ToInt32(reader[8]);
                    GAL = team2 + 1;
                    GFL = Convert.ToInt32(reader[7]);
                } reader.Close();
                GDL = GFL - GAL;
                string update = String.Format("UPDATE `ddt_data`.`league` SET `GA` = '{2}',`GD`='{4}' WHERE `league`.`NAME` = '{3}';UPDATE `ddt_data`.`league` SET `GF` = '{0}',`GD`='{5}' WHERE `league`.`NAME` = '{1}'", GFS, teamName, GAL, teamName2,GDL,GDS);
                select = new MySqlCommand(update, conn);
                reader = select.ExecuteReader();
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                //conn.Close();
                return ;
                //conn.Close();
            }
        }
    }
}
