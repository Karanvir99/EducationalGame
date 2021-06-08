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
using System.Media;

namespace MemoryGame
{
    public partial class GameWindow : Form
    {
        //Variables
        List<Point> points = new List<Point>(); //Hold the card points
        Random Position = new Random(); //Chooses random value from points list and allocates new position to every card
        PictureBox AwaitingImage1; //Store first overturned card into this variable 
        PictureBox AwaitingImage2; //Store second overturned card into this variable
        
        int clockFlag = 0;

        public GameWindow()
        {          
            InitializeComponent();
        }

        private static OleDbConnection GetConnection()
        {
            string ConnectionString;
            //Establish database connection
            ConnectionString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=\MemoryGame\MemoryGamedb.mdb";
            return new OleDbConnection(ConnectionString);
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            //Sets countdown timer
            Countdown.Text = "10";
            //Indicates inputted username
            lblPlayerName.Text = MainMenu.Playername;
            //Sets minutes label to 02 and seconds label to 00 to create a 2:00 timer
            lblPlayTimeM.Text = "02";
            lblPlayTimeS.Text = "00";

            foreach (PictureBox picture in CardPanel.Controls)
            {
                picture.Enabled = false; //Disable image click during 5 second countdown
                points.Add(picture.Location); //List that holds all positions of all images
            }

            foreach (PictureBox picture in CardPanel.Controls)
            {
                //Counts how many points in the list and assigns it to the variable next
                int next = Position.Next(points.Count); 
                Point p = points[next];
                picture.Location = p;
                points.Remove(p);
            }

            StartGameTimer.Start(); //5 second countdown starts
            SubtractTimer.Start(); //Subtract timer starts

            ReplayButton.Visible = false; //Replay button is not visible during 5 second countdown
            LeaderboardButton.Enabled = false; //Leaderboard button is disabled during the game

            //Assigns each PictureBox to a card image
            Card1.Image = Properties.Resources.Bear;
            Card1Name.Image = Properties.Resources.BearName;
            Card2.Image = Properties.Resources.Cat;
            Card2Name.Image = Properties.Resources.CatName;
            Card3.Image = Properties.Resources.Cheetah;
            Card3Name.Image = Properties.Resources.CheetahName;
            Card4.Image = Properties.Resources.Deer;
            Card4Name.Image = Properties.Resources.DeerName;
            Card5.Image = Properties.Resources.Dog;
            Card5Name.Image = Properties.Resources.DogName;
            Card6.Image = Properties.Resources.Dolphin;
            Card6Name.Image = Properties.Resources.DolphinName;
            Card7.Image = Properties.Resources.Elephant;
            Card7Name.Image = Properties.Resources.ElephantName;
            Card8.Image = Properties.Resources.Horse;
            Card8Name.Image = Properties.Resources.HorseName;
            Card9.Image = Properties.Resources.Lion;
            Card9Name.Image = Properties.Resources.LionName;
            Card10.Image = Properties.Resources.Panda;
            Card10Name.Image = Properties.Resources.PandaName;
            Card11.Image = Properties.Resources.Wolf;
            Card11Name.Image = Properties.Resources.WolfName;
            Card12.Image = Properties.Resources.Zebra;
            Card12Name.Image = Properties.Resources.ZebraName;
        }

        private void StartGameTimer_Tick(object sender, EventArgs e)
        {
            //5 second countdown ends
            StartGameTimer.Stop();
            foreach (PictureBox picture in CardPanel.Controls)
            {
                picture.Enabled = true; //Enable image click after 5 second countdown ends
                picture.Cursor = Cursors.Hand; //Cursor changes to hand symbol when hovering over a card (after 5 seconds)
                picture.Image = Properties.Resources.QuestionMark; //Loops through each PictureBox and changes its image property to QuestionMark (after 5 seconds)

                ReplayButton.Visible = true; //Replay button is visible (after 5 seconds)
                ReplayButton.Cursor = Cursors.Hand; //Cursor changes to hand symbol when hovering over replay button (after 5 seconds)
            }
        }

        private void SubtractTimer_Tick(object sender, EventArgs e)
        {
            int timer = Convert.ToInt32(Countdown.Text); //Convert the number 5 string into an integer
            timer = timer - 1; //Takes the value of the timer and subtracts it by 1
            Countdown.Text = Convert.ToString(timer); //Convert the integer to a string as you can't have it as a text value
            if (timer == 0)
            {
                SubtractTimer.Stop(); //Stop the timer when it reaches 0 so that it doesn't go past this value
                Countdown.Text = "";
                PlayTime.Start(); //Starts the 2 minute timer
            }
        }

        //Change Card Value (from QuestionMark image to the animal image or name)
        #region Cards

        private void Card1_Click_1(object sender, EventArgs e)
        {
            Card1.Image = Properties.Resources.Bear;
            Card1.Enabled = false; //Disable functionality of the card after clicking on it once

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card1; //If AwaitingImage1 is empty then assign Card1 as its value
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null) //If AwaitingImage1 is not empty and already has a value then check if AwaitingImage2 is empty or not
            {
                AwaitingImage2 = Card1; //If AwaitingImage2 is empty then assign Card1 as its value
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null) //If AwaitingImage1 is not empty and AwaitingImage2 is not empty then compare 2 of the values to each other
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag) //Check the tag of the value in AwaitingImage1 to the value being stored in AwaitingImage2
                {
                    //Empties the variables if the Tags are the same
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    //Removes cards when matched
                    Card1.Visible = false;
                    Card1Name.Visible = false;
                    //Add 10 points when cards are matched
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start(); //Start the 5 millisecond timer which occurs if the 2 overturned images do not have the same Tag ID
                }
            }
            Winning();
        }

        private void Card1Name_Click(object sender, EventArgs e)
        {
            Card1Name.Image = Properties.Resources.BearName;
            Card1Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card1Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card1Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;


                    Card1.Visible = false;
                    Card1Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card2_Click(object sender, EventArgs e)
        {
            Card2.Image = Properties.Resources.Cat;
            Card2.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card2;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card2;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card2.Visible = false;
                    Card2Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card2Name_Click(object sender, EventArgs e)
        {
            Card2Name.Image = Properties.Resources.CatName;
            Card2Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card2Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card2Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card2.Visible = false;
                    Card2Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card3_Click(object sender, EventArgs e)
        {
            Card3.Image = Properties.Resources.Cheetah;
            Card3.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card3;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card3;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card3.Visible = false;
                    Card3Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card3Name_Click(object sender, EventArgs e)
        {
            Card3Name.Image = Properties.Resources.CheetahName;
            Card3Name.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card3Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card3Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card3.Visible = false;
                    Card3Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card4_Click(object sender, EventArgs e)
        {
            Card4.Image = Properties.Resources.Deer;
            Card4.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card4;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card4;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card4.Visible = false;
                    Card4Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card4Name_Click(object sender, EventArgs e)
        {
            Card4Name.Image = Properties.Resources.DeerName;
            Card4Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card4Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card4Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card4.Visible = false;
                    Card4Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card5_Click(object sender, EventArgs e)
        {
            Card5.Image = Properties.Resources.Dog;
            Card5.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card5;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card5;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card5.Visible = false;
                    Card5Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card5Name_Click(object sender, EventArgs e)
        {
            Card5Name.Image = Properties.Resources.DogName;
            Card5Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card5Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card5Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card5.Visible = false;
                    Card5Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card6_Click(object sender, EventArgs e)
        {
            Card6.Image = Properties.Resources.Dolphin;
            Card6.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card6;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card6;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card6.Visible = false;
                    Card6Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card6Name_Click(object sender, EventArgs e)
        {
            Card6Name.Image = Properties.Resources.DolphinName;
            Card6Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card6Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card6Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card6.Visible = false;
                    Card6Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card7_Click(object sender, EventArgs e)
        {
            Card7.Image = Properties.Resources.Elephant;
            Card7.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card7;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card7;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card7.Visible = false;
                    Card7Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card7Name_Click(object sender, EventArgs e)
        {
            Card7Name.Image = Properties.Resources.ElephantName;
            Card7Name.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card7Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card7Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card7.Visible = false;
                    Card7Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card8_Click(object sender, EventArgs e)
        {
            Card8.Image = Properties.Resources.Horse;
            Card8.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card8;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card8;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card8.Visible = false;
                    Card8Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card8Name_Click(object sender, EventArgs e)
        {
            Card8Name.Image = Properties.Resources.HorseName;
            Card8Name.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card8Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card8Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card8.Visible = false;
                    Card8Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card9_Click(object sender, EventArgs e)
        {
            Card9.Image = Properties.Resources.Lion;
            Card9.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card9;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card9;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card9.Visible = false;
                    Card9Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card9Name_Click(object sender, EventArgs e)
        {
            Card9Name.Image = Properties.Resources.LionName;
            Card9Name.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card9Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card9Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card9.Visible = false;
                    Card9Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card10_Click(object sender, EventArgs e)
        {
            Card10.Image = Properties.Resources.Panda;
            Card10.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card10;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card10;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card10.Visible = false;
                    Card10Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card10Name_Click(object sender, EventArgs e)
        {
            Card10Name.Image = Properties.Resources.PandaName;
            Card10Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card10Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card10Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card10.Visible = false;
                    Card10Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card11_Click(object sender, EventArgs e)
        {
            Card11.Image = Properties.Resources.Wolf;
            Card11.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card11;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card11;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card11.Visible = false;
                    Card11Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card11Name_Click(object sender, EventArgs e)
        {
            Card11Name.Image = Properties.Resources.WolfName;
            Card11Name.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card11Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card11Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card11.Visible = false;
                    Card11Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            Card12.Image = Properties.Resources.Zebra;
            Card12.Enabled = false;

            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card12;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card12;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card12.Visible = false;
                    Card12Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }

        private void Card12Name_Click(object sender, EventArgs e)
        {
            Card12Name.Image = Properties.Resources.ZebraName;
            Card12Name.Enabled = false;
            if (AwaitingImage1 == null)
            {
                AwaitingImage1 = Card12Name;
            }
            else if (AwaitingImage1 != null && AwaitingImage2 == null)
            {
                AwaitingImage2 = Card12Name;
            }
            if (AwaitingImage1 != null && AwaitingImage2 != null)
            {
                if (AwaitingImage1.Tag == AwaitingImage2.Tag)
                {
                    AwaitingImage1 = null;
                    AwaitingImage2 = null;
                    Card12.Visible = false;
                    Card12Name.Visible = false;
                    ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) + 10);
                }
                else
                {
                    CardFlipTimer.Start();
                }
            }
            Winning();
        }
        #endregion

        private void CardFlipTimer_Tick(object sender, EventArgs e)
        {
            CardFlipTimer.Stop(); //If the animal image does not match with the animal name then the 2 overturned cards will turn back to QuestionMark after 5 milliseconds
            ScoreCounter.Text = Convert.ToString(Convert.ToInt32(ScoreCounter.Text) - 5); //Subtracts the score if the images do not match 5 milliseconds after the cards are overturned
            AwaitingImage1.Image = Properties.Resources.QuestionMark;
            AwaitingImage2.Image = Properties.Resources.QuestionMark;
            AwaitingImage1 = null;
            AwaitingImage2 = null;

            foreach (PictureBox picture in CardPanel.Controls) //Enable functionality of the card after both cards are clicked
                picture.Enabled = true;
        }

        private void ReplayButton_Click(object sender, EventArgs e)
        {
            PlayTime.Stop(); //Timer is stopped and resetted
            clockFlag = 0;

            //Winning gif picture or Game over message is invisible
            WinPicture.Visible = false;
            lblGameOver.Visible = false;

            CardPanel.Visible = true; //Card panel is re enabled
            foreach (PictureBox picture in CardPanel.Controls) //All cards are visible again
                picture.Visible = true;

            GameWindow_Load(sender, e); //Resets the entire game
            ScoreCounter.Text = "0"; //Score counter resets to 0
        }

        private void PlayTime_Tick(object sender, EventArgs e)
        {
            //Sets 2 minute timer

            if (lblPlayTimeM.Text == "02" && lblPlayTimeS.Text == "00") //Sets the minute label to 02 and the seconds label to 00 to create 2:00 timer
            {
                //if the timer is set to 02 00 then change labels to 01 59
                lblPlayTimeM.Text = "01"; 
                lblPlayTimeS.Text = "59";
            }

            //If clockflag is equal to 1 then start subtracting down the time
            if (clockFlag == 1)
            {
                int PlayTime = Convert.ToInt32(lblPlayTimeS.Text);
                PlayTime = PlayTime - 1;

                //Counts down the time under the one minute mark
                if (PlayTime == 0 && lblPlayTimeM.Text == "01")
                {

                    lblPlayTimeM.Text = "00";
                    lblPlayTimeS.Text = "59";

                    PlayTime = Convert.ToInt32(lblPlayTimeS.Text);
                }

                //If timer is less than 10 then set the seconds label to 0
                lblPlayTimeS.Text = Convert.ToString(PlayTime);
                if (PlayTime < 10)
                {
                    lblPlayTimeS.Text = "0" + Convert.ToString(PlayTime);
                }
                else
                {
                    lblPlayTimeS.Text = Convert.ToString(PlayTime);
                }

                if (PlayTime == 0)
                {

                    this.PlayTime.Stop(); //Stop 2 minute timer
                    lblPlayTimeM.Text = "00"; //Set minutes label to 00
                    lblPlayTimeS.Text = "00"; //Set seconds label to 00
                    CardPanel.Visible = false; //Turn off card panel
                    lblGameOver.Visible = true; //Show game over message label
                    LeaderboardButton.Enabled = true; //Enable functionality of the leaderboard button

                    WinPicture.Visible = false; //Don't show winning gif picture

                    OleDbConnection connection = GetConnection();
                    //Inputs entered fields within the main menu and the score counter into the database
                    string GameQuery = "INSERT INTO PlayerDetails (UserName, FirstName, Surname, Score) VALUES ('" + MainMenu.Playername + "' , '" + MainMenu.Firstname + "' , '" + MainMenu.Surname + "' , '" + ScoreCounter.Text + "' )";
                    OleDbCommand GameCommand = new OleDbCommand(GameQuery, connection);

                    //Opens connection
                    try
                    {
                        connection.Open();
                        GameCommand.ExecuteNonQuery();
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
            }
            clockFlag = 1;
        }

        public void Winning()
        {
            //If all cards are matched then show winning picture & enable leaderboard button
            if (Card1.Visible == false && Card2.Visible == false && Card3.Visible == false && Card4.Visible == false
                  && Card5.Visible == false && Card6.Visible == false && Card7.Visible == false && Card8.Visible == false
                  && Card9.Visible == false && Card10.Visible == false && Card11.Visible == false && Card12.Visible == false
                  && Card1Name.Visible == false && Card2Name.Visible == false && Card3Name.Visible == false && Card4Name.Visible == false
                  && Card5Name.Visible == false && Card6Name.Visible == false && Card7Name.Visible == false && Card8Name.Visible == false
                  && Card9Name.Visible == false && Card10Name.Visible == false && Card11Name.Visible == false && Card12Name.Visible == false)
            {

                WinPicture.Visible = true;
                LeaderboardButton.Enabled = true;

                OleDbConnection connection = GetConnection();
                //Inputs entered fields within the main menu and the score counter into the database
                string GameQuery = "INSERT INTO PlayerDetails (UserName, FirstName, Surname,  Score) VALUES ('" + MainMenu.Playername + "' , '" + MainMenu.Firstname + "' , '" + MainMenu.Surname + "' , '" + ScoreCounter.Text + "' )";
                OleDbCommand GameCommand = new OleDbCommand(GameQuery, connection);

                try
                {
                    connection.Open();
                    GameCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception in DBHandler" + ex);
                }
                finally
                {
                    connection.Close();
                }

                PlayTime.Stop();
            }
        }

        private void LeaderboardButton_Click(object sender, EventArgs e)
        {
            Leaderboard LeaderboardWindow = new Leaderboard();
            LeaderboardWindow.Show(); //Open leaderboard window
            this.Hide(); //Hide current window

            SoundPlayer gameMusic = new SoundPlayer("littleidea.wav"); //Ends game music
            gameMusic.Stop();
        }

        private void MoveWinPic_Tick(object sender, EventArgs e)
        {
            WinPicture.Location = new Point(WinPicture.Location.X + 5, WinPicture.Location.Y); //Shows the direction for the winning gif picture to be moved to

            if (WinPicture.Location.X > this.Width)
            {
                WinPicture.Location = new Point(0 - WinPicture.Width, WinPicture.Location.Y); //Moves the gif picture to the new location
            }
        }
    }
}


