namespace MemoryGame
{
    partial class Leaderboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ViewChartButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblLeaderboard = new System.Windows.Forms.Label();
            this.MoveLeaderboardText = new System.Windows.Forms.Timer(this.components);
            this.ScoreListButton = new System.Windows.Forms.Button();
            this.FirstNamelistbox = new System.Windows.Forms.ListBox();
            this.PlayerScorelistbox = new System.Windows.Forms.ListBox();
            this.MenuButton = new System.Windows.Forms.Button();
            this.Surnamelistbox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewChartButton
            // 
            this.ViewChartButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ViewChartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewChartButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.ViewChartButton.ForeColor = System.Drawing.Color.White;
            this.ViewChartButton.Location = new System.Drawing.Point(608, 501);
            this.ViewChartButton.Name = "ViewChartButton";
            this.ViewChartButton.Size = new System.Drawing.Size(281, 50);
            this.ViewChartButton.TabIndex = 1;
            this.ViewChartButton.Text = "View player performance";
            this.ViewChartButton.UseVisualStyleBackColor = true;
            this.ViewChartButton.Click += new System.EventHandler(this.ViewChartbtn_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(417, 98);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Points";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(658, 368);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // lblLeaderboard
            // 
            this.lblLeaderboard.AutoSize = true;
            this.lblLeaderboard.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.lblLeaderboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLeaderboard.Location = new System.Drawing.Point(464, 30);
            this.lblLeaderboard.Name = "lblLeaderboard";
            this.lblLeaderboard.Size = new System.Drawing.Size(141, 35);
            this.lblLeaderboard.TabIndex = 3;
            this.lblLeaderboard.Text = "Leaderboard";
            // 
            // MoveLeaderboardText
            // 
            this.MoveLeaderboardText.Enabled = true;
            this.MoveLeaderboardText.Interval = 400;
            this.MoveLeaderboardText.Tick += new System.EventHandler(this.MoveLeaderboardText_Tick);
            // 
            // ScoreListButton
            // 
            this.ScoreListButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ScoreListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScoreListButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.ScoreListButton.ForeColor = System.Drawing.Color.White;
            this.ScoreListButton.Location = new System.Drawing.Point(904, 501);
            this.ScoreListButton.Name = "ScoreListButton";
            this.ScoreListButton.Size = new System.Drawing.Size(171, 50);
            this.ScoreListButton.TabIndex = 4;
            this.ScoreListButton.Text = "View score list";
            this.ScoreListButton.UseVisualStyleBackColor = true;
            this.ScoreListButton.Click += new System.EventHandler(this.ScoreListButton_Click);
            // 
            // FirstNamelistbox
            // 
            this.FirstNamelistbox.FormattingEnabled = true;
            this.FirstNamelistbox.Location = new System.Drawing.Point(23, 98);
            this.FirstNamelistbox.Name = "FirstNamelistbox";
            this.FirstNamelistbox.Size = new System.Drawing.Size(125, 368);
            this.FirstNamelistbox.TabIndex = 5;
            // 
            // PlayerScorelistbox
            // 
            this.PlayerScorelistbox.FormattingEnabled = true;
            this.PlayerScorelistbox.Location = new System.Drawing.Point(269, 98);
            this.PlayerScorelistbox.Name = "PlayerScorelistbox";
            this.PlayerScorelistbox.Size = new System.Drawing.Size(125, 368);
            this.PlayerScorelistbox.TabIndex = 6;
            // 
            // MenuButton
            // 
            this.MenuButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.MenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButton.Font = new System.Drawing.Font("Segoe Print", 15F);
            this.MenuButton.ForeColor = System.Drawing.Color.White;
            this.MenuButton.Location = new System.Drawing.Point(23, 501);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(171, 50);
            this.MenuButton.TabIndex = 7;
            this.MenuButton.Text = "Main Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // Surnamelistbox
            // 
            this.Surnamelistbox.FormattingEnabled = true;
            this.Surnamelistbox.Location = new System.Drawing.Point(145, 98);
            this.Surnamelistbox.Name = "Surnamelistbox";
            this.Surnamelistbox.Size = new System.Drawing.Size(125, 368);
            this.Surnamelistbox.TabIndex = 8;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1103, 563);
            this.Controls.Add(this.Surnamelistbox);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.PlayerScorelistbox);
            this.Controls.Add(this.FirstNamelistbox);
            this.Controls.Add(this.ScoreListButton);
            this.Controls.Add(this.lblLeaderboard);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ViewChartButton);
            this.MaximizeBox = false;
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ViewChartButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblLeaderboard;
        private System.Windows.Forms.Timer MoveLeaderboardText;
        private System.Windows.Forms.Button ScoreListButton;
        private System.Windows.Forms.ListBox FirstNamelistbox;
        private System.Windows.Forms.ListBox PlayerScorelistbox;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.ListBox Surnamelistbox;
    }
}