namespace MemoryGame
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.llblPlayerName = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblMainMenu = new System.Windows.Forms.Label();
            this.MoveMenuText = new System.Windows.Forms.Timer(this.components);
            this.lblMenu = new System.Windows.Forms.Label();
            this.InstructionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(293, 117);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(163, 20);
            this.txtPlayerName.TabIndex = 18;
            // 
            // llblPlayerName
            // 
            this.llblPlayerName.AutoSize = true;
            this.llblPlayerName.Font = new System.Drawing.Font("Segoe Print", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.llblPlayerName.ForeColor = System.Drawing.Color.White;
            this.llblPlayerName.Location = new System.Drawing.Point(75, 106);
            this.llblPlayerName.Name = "llblPlayerName";
            this.llblPlayerName.Size = new System.Drawing.Size(212, 35);
            this.llblPlayerName.TabIndex = 19;
            this.llblPlayerName.Text = "Enter Player name:";
            // 
            // EnterButton
            // 
            this.EnterButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EnterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.EnterButton.ForeColor = System.Drawing.Color.White;
            this.EnterButton.Location = new System.Drawing.Point(211, 285);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(122, 50);
            this.EnterButton.TabIndex = 20;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe Print", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(75, 163);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(188, 35);
            this.lblFirstName.TabIndex = 21;
            this.lblFirstName.Text = "Enter first name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(293, 177);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(163, 20);
            this.txtFirstName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 35);
            this.label1.TabIndex = 23;
            this.label1.Text = "Enter Surname:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(293, 233);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(163, 20);
            this.txtSurname.TabIndex = 24;
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.Location = new System.Drawing.Point(0, 0);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(100, 23);
            this.lblMainMenu.TabIndex = 0;
            // 
            // MoveMenuText
            // 
            this.MoveMenuText.Enabled = true;
            this.MoveMenuText.Interval = 400;
            this.MoveMenuText.Tick += new System.EventHandler(this.MoveMenuText_Tick);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.lblMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblMenu.Location = new System.Drawing.Point(206, 31);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(127, 35);
            this.lblMenu.TabIndex = 25;
            this.lblMenu.Text = "Main Menu";
            // 
            // InstructionsButton
            // 
            this.InstructionsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.InstructionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.InstructionsButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsButton.Location = new System.Drawing.Point(12, 364);
            this.InstructionsButton.Name = "InstructionsButton";
            this.InstructionsButton.Size = new System.Drawing.Size(207, 50);
            this.InstructionsButton.TabIndex = 26;
            this.InstructionsButton.Text = "Game Instructions";
            this.InstructionsButton.UseVisualStyleBackColor = true;
            this.InstructionsButton.Click += new System.EventHandler(this.InstructionsButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(570, 426);
            this.Controls.Add(this.InstructionsButton);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.lblMainMenu);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.llblPlayerName);
            this.Controls.Add(this.txtPlayerName);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label llblPlayerName;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblMainMenu;
        private System.Windows.Forms.Timer MoveMenuText;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button InstructionsButton;
    }
}