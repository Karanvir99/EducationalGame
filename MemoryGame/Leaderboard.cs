using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {

        }

        private static OleDbConnection GetConnection()
        {
            string ConnectionString;
            //change to your connection string in the following line
            ConnectionString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=\MemoryGame\MemoryGamedb.mdb";
            return new OleDbConnection(ConnectionString);
        }

        private void ViewChartbtn_Click(object sender, EventArgs e)
        {
            //ViewChartButton.Enabled = false;
            OleDbConnection connection = GetConnection();
            string GameQuery = "SELECT * FROM PlayerDetails";
            OleDbCommand GameCommand = new OleDbCommand(GameQuery, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = GameCommand.ExecuteReader();
                while (reader.Read())
                {

                    chart1.Series["Points"].Points.AddXY(reader["UserName"].ToString(), reader["Score"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in DBHandler" + ex);
            }
            finally
            {
                connection.Close();

            }
        }

        private void MoveLeaderboardText_Tick(object sender, EventArgs e)
        {
            lblLeaderboard.Location = new Point(lblLeaderboard.Location.X + 5, lblLeaderboard.Location.Y);

            if (lblLeaderboard.Location.X > this.Width)
            {
                lblLeaderboard.Location = new Point(0 - lblLeaderboard.Width, lblLeaderboard.Location.Y);
            }
            int colour = 0;
            if (colour == 0)
            {
                lblLeaderboard.ForeColor = Color.Orange;
                colour = 1;
            }
            {
                lblLeaderboard.ForeColor = Color.Orange;
                colour = 0;
            }
        }

        private void ScoreListButton_Click(object sender, EventArgs e)
        {

            OleDbConnection connection = GetConnection();
            string GameQuery = "SELECT * FROM PlayerDetails";
            OleDbCommand GameCommand = new OleDbCommand(GameQuery, connection);

            try
            {
                connection.Open();
                OleDbDataReader dbDataReader = GameCommand.ExecuteReader();
                while (dbDataReader.Read())
                {
                    FirstNamelistbox.Items.Add(dbDataReader["FirstName"].ToString());
                    Surnamelistbox.Items.Add(dbDataReader["Surname"].ToString());
                    PlayerScorelistbox.Items.Add(dbDataReader["Score"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in DBHandler" + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }
    }
}
