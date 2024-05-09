namespace BrickBreaker
{
    partial class MenuScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.instructionButton = new System.Windows.Forms.Button();
            this.arsBackgroundLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.mrRoll = new System.Windows.Forms.PictureBox();
            this.ricktimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mrRoll)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.playButton.Location = new System.Drawing.Point(1050, 460);
            this.playButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(400, 144);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.exitButton.Location = new System.Drawing.Point(1050, 1037);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(400, 144);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.White;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.resetButton.Location = new System.Drawing.Point(1050, 748);
            this.resetButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(400, 144);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset Save";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // instructionButton
            // 
            this.instructionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.instructionButton.Location = new System.Drawing.Point(2314, 1171);
            this.instructionButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.instructionButton.Name = "instructionButton";
            this.instructionButton.Size = new System.Drawing.Size(120, 115);
            this.instructionButton.TabIndex = 4;
            this.instructionButton.Text = "?";
            this.instructionButton.UseVisualStyleBackColor = true;
            this.instructionButton.Click += new System.EventHandler(this.instructionButton_Click);
            // 
            // arsBackgroundLabel
            // 
            this.arsBackgroundLabel.BackColor = System.Drawing.Color.Silver;
            this.arsBackgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arsBackgroundLabel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.arsBackgroundLabel.Location = new System.Drawing.Point(1692, 219);
            this.arsBackgroundLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.arsBackgroundLabel.Name = "arsBackgroundLabel";
            this.arsBackgroundLabel.Size = new System.Drawing.Size(600, 385);
            this.arsBackgroundLabel.TabIndex = 5;
            this.arsBackgroundLabel.Text = "Are You Sure?";
            this.arsBackgroundLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.arsBackgroundLabel.Visible = false;
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.White;
            this.yesButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.yesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.yesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.yesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.ForeColor = System.Drawing.Color.Black;
            this.yesButton.Location = new System.Drawing.Point(2038, 460);
            this.yesButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(160, 77);
            this.yesButton.TabIndex = 6;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Visible = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.White;
            this.noButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.noButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Snow;
            this.noButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.Color.Black;
            this.noButton.Location = new System.Drawing.Point(1788, 460);
            this.noButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(160, 77);
            this.noButton.TabIndex = 7;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Visible = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // mrRoll
            // 
            this.mrRoll.Image = global::BrickBreaker.Properties.Resources.rick_roll_night;
            this.mrRoll.Location = new System.Drawing.Point(72, 100);
            this.mrRoll.Name = "mrRoll";
            this.mrRoll.Size = new System.Drawing.Size(935, 720);
            this.mrRoll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mrRoll.TabIndex = 8;
            this.mrRoll.TabStop = false;
            this.mrRoll.Visible = false;
            // 
            // ricktimer
            // 
            this.ricktimer.Interval = 50;
            this.ricktimer.Tick += new System.EventHandler(this.ricktimer_Tick);
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.mrRoll);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.arsBackgroundLabel);
            this.Controls.Add(this.instructionButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.playButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(2500, 1346);
            ((System.ComponentModel.ISupportInitialize)(this.mrRoll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button instructionButton;
        private System.Windows.Forms.Label arsBackgroundLabel;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;
        private System.Windows.Forms.PictureBox mrRoll;
        private System.Windows.Forms.Timer ricktimer;
    }
}
