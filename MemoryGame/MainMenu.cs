using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MemoryGame
{
    public partial class MainMenu : Form
    {
        //Referencing for the 3 textfields
        public static string Playername;
        public static string Firstname;
        public static string Surname;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlayerName.Text) || string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtSurname.Text)) //OR operator
            {
                MessageBox.Show("Please enter the missing fields!"); //If any of the 3 fields are empty then show this message in a message box
            }
            else
            {
                //If 3 required fields are filled in then show the Game Window and start game music
                Playername = txtPlayerName.Text;
                Firstname = txtFirstName.Text;
                Surname = txtSurname.Text;

                new GameWindow().Show();
                Hide();

                //Adding .wav file for background music. Starts gane music
                SoundPlayer gameMusic = new SoundPlayer("littleidea.wav");
                gameMusic.PlayLooping();
            }
        }

        private void MoveMenuText_Tick(object sender, EventArgs e)
        {
            lblMenu.Location = new Point(lblMenu.Location.X + 5, lblMenu.Location.Y); //Shows the direction for the menu label to be moved to

            if (lblMenu.Location.X > this.Width)
            {
                lblMenu.Location = new Point(0 - lblMenu.Width, lblMenu.Location.Y); //Moves the menu label to the new location
            }
            int colour = 0; //declares the variable colour
            if (colour == 0)
            {
                //Orange colour chosen for the label
                lblMenu.ForeColor = Color.Orange;
                colour = 1;
            }
            {
                lblMenu.ForeColor = Color.Orange;
                colour = 0;
            }
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            InstructionsInfo Helpinformation = new InstructionsInfo();
            //Enables message box showing the players instructions and labelling the message box
            MessageBox.Show(Helpinformation.RecieveInstruction("The objective of Elephants memory is to turn 2 cards at a time. The player has to match the animal image to the matching animal name."), "Player Instructions");
            MessageBox.Show(Helpinformation.GetPlayerInstruction(true), "Player Instructions");
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
        }
    }
}

