namespace BrickBreaker
{
    partial class GameScreen
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.upgrade2Quantity = new System.Windows.Forms.Label();
            this.upgrade2Price = new System.Windows.Forms.Label();
            this.upgrade2Icon = new System.Windows.Forms.Label();
            this.upgrade2Description = new System.Windows.Forms.Label();
            this.upgrade2Title = new System.Windows.Forms.Label();
            this.upgrade3Quantity = new System.Windows.Forms.Label();
            this.upgrade3Price = new System.Windows.Forms.Label();
            this.upgrade3Icon = new System.Windows.Forms.Label();
            this.upgrade3Description = new System.Windows.Forms.Label();
            this.upgrade3Title = new System.Windows.Forms.Label();
            this.upgrade4Quantity = new System.Windows.Forms.Label();
            this.upgrade4Price = new System.Windows.Forms.Label();
            this.upgrade4Description = new System.Windows.Forms.Label();
            this.upgrade4Title = new System.Windows.Forms.Label();
            this.upgrade5Quantity = new System.Windows.Forms.Label();
            this.upgrade5Price = new System.Windows.Forms.Label();
            this.upgrade5Description = new System.Windows.Forms.Label();
            this.upgrade5TItle = new System.Windows.Forms.Label();
            this.upgrade6Quantity = new System.Windows.Forms.Label();
            this.upgrade6Price = new System.Windows.Forms.Label();
            this.upgrade6Icon = new System.Windows.Forms.Label();
            this.upgrade6Description = new System.Windows.Forms.Label();
            this.upgrade6Title = new System.Windows.Forms.Label();
            this.statisticsButton = new System.Windows.Forms.Label();
            this.htpButton = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.sandwichQuantity = new System.Windows.Forms.Label();
            this.upgrade2Panel = new System.Windows.Forms.Panel();
            this.upgrade1Panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.upgrade3Panel = new System.Windows.Forms.Panel();
            this.upgrade4Panel = new System.Windows.Forms.Panel();
            this.upgrade5Panel = new System.Windows.Forms.Panel();
            this.upgrade6Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.upgrade5Icon = new System.Windows.Forms.PictureBox();
            this.upgrade4Icon = new System.Windows.Forms.PictureBox();
            this.upgrade2Panel.SuspendLayout();
            this.upgrade1Panel.SuspendLayout();
            this.upgrade3Panel.SuspendLayout();
            this.upgrade4Panel.SuspendLayout();
            this.upgrade5Panel.SuspendLayout();
            this.upgrade6Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgrade5Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgrade4Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // upgrade2Quantity
            // 
            this.upgrade2Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade2Quantity.ForeColor = System.Drawing.Color.White;
            this.upgrade2Quantity.Location = new System.Drawing.Point(210, 17);
            this.upgrade2Quantity.Name = "upgrade2Quantity";
            this.upgrade2Quantity.Size = new System.Drawing.Size(51, 52);
            this.upgrade2Quantity.TabIndex = 12;
            this.upgrade2Quantity.Text = "0";
            this.upgrade2Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade2Quantity.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade2Price
            // 
            this.upgrade2Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade2Price.ForeColor = System.Drawing.Color.White;
            this.upgrade2Price.Location = new System.Drawing.Point(20, 64);
            this.upgrade2Price.Name = "upgrade2Price";
            this.upgrade2Price.Size = new System.Drawing.Size(60, 20);
            this.upgrade2Price.TabIndex = 11;
            this.upgrade2Price.Text = "20";
            this.upgrade2Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade2Price.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade2Icon
            // 
            this.upgrade2Icon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade2Icon.ForeColor = System.Drawing.Color.White;
            this.upgrade2Icon.Location = new System.Drawing.Point(84, 64);
            this.upgrade2Icon.Name = "upgrade2Icon";
            this.upgrade2Icon.Size = new System.Drawing.Size(60, 20);
            this.upgrade2Icon.TabIndex = 10;
            this.upgrade2Icon.Text = "N/A";
            this.upgrade2Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade2Icon.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade2Description
            // 
            this.upgrade2Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade2Description.ForeColor = System.Drawing.Color.White;
            this.upgrade2Description.Location = new System.Drawing.Point(22, 25);
            this.upgrade2Description.Name = "upgrade2Description";
            this.upgrade2Description.Size = new System.Drawing.Size(189, 40);
            this.upgrade2Description.TabIndex = 9;
            this.upgrade2Description.Text = "Permanently increase paddle speed";
            this.upgrade2Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgrade2Description.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade2Title
            // 
            this.upgrade2Title.AutoSize = true;
            this.upgrade2Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade2Title.ForeColor = System.Drawing.Color.White;
            this.upgrade2Title.Location = new System.Drawing.Point(22, 5);
            this.upgrade2Title.Name = "upgrade2Title";
            this.upgrade2Title.Size = new System.Drawing.Size(195, 20);
            this.upgrade2Title.TabIndex = 8;
            this.upgrade2Title.Text = "Paddle Speed Upgrade";
            this.upgrade2Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade2Title.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade3Quantity
            // 
            this.upgrade3Quantity.AutoSize = true;
            this.upgrade3Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade3Quantity.ForeColor = System.Drawing.Color.White;
            this.upgrade3Quantity.Location = new System.Drawing.Point(215, 28);
            this.upgrade3Quantity.Name = "upgrade3Quantity";
            this.upgrade3Quantity.Size = new System.Drawing.Size(42, 31);
            this.upgrade3Quantity.TabIndex = 17;
            this.upgrade3Quantity.Text = "1x";
            this.upgrade3Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade3Quantity.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade3Price
            // 
            this.upgrade3Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade3Price.ForeColor = System.Drawing.Color.White;
            this.upgrade3Price.Location = new System.Drawing.Point(18, 63);
            this.upgrade3Price.Name = "upgrade3Price";
            this.upgrade3Price.Size = new System.Drawing.Size(60, 22);
            this.upgrade3Price.TabIndex = 16;
            this.upgrade3Price.Text = "50";
            this.upgrade3Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade3Price.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade3Icon
            // 
            this.upgrade3Icon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade3Icon.ForeColor = System.Drawing.Color.White;
            this.upgrade3Icon.Location = new System.Drawing.Point(82, 63);
            this.upgrade3Icon.Name = "upgrade3Icon";
            this.upgrade3Icon.Size = new System.Drawing.Size(60, 22);
            this.upgrade3Icon.TabIndex = 15;
            this.upgrade3Icon.Text = "N/A";
            this.upgrade3Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade3Icon.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade3Description
            // 
            this.upgrade3Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade3Description.ForeColor = System.Drawing.Color.White;
            this.upgrade3Description.Location = new System.Drawing.Point(20, 24);
            this.upgrade3Description.Name = "upgrade3Description";
            this.upgrade3Description.Size = new System.Drawing.Size(189, 40);
            this.upgrade3Description.TabIndex = 14;
            this.upgrade3Description.Text = "Multiplier for the amount of sandwiches you get per hit";
            this.upgrade3Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgrade3Description.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade3Title
            // 
            this.upgrade3Title.AutoSize = true;
            this.upgrade3Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade3Title.ForeColor = System.Drawing.Color.White;
            this.upgrade3Title.Location = new System.Drawing.Point(20, 4);
            this.upgrade3Title.Name = "upgrade3Title";
            this.upgrade3Title.Size = new System.Drawing.Size(163, 20);
            this.upgrade3Title.TabIndex = 13;
            this.upgrade3Title.Text = "Sandwich Multiplier";
            this.upgrade3Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade3Title.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade4Quantity
            // 
            this.upgrade4Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade4Quantity.ForeColor = System.Drawing.Color.White;
            this.upgrade4Quantity.Location = new System.Drawing.Point(208, 16);
            this.upgrade4Quantity.Name = "upgrade4Quantity";
            this.upgrade4Quantity.Size = new System.Drawing.Size(51, 52);
            this.upgrade4Quantity.TabIndex = 22;
            this.upgrade4Quantity.Text = "0";
            this.upgrade4Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade4Quantity.Click += new System.EventHandler(this.upgrade4Quantity_Click);
            // 
            // upgrade4Price
            // 
            this.upgrade4Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade4Price.ForeColor = System.Drawing.Color.White;
            this.upgrade4Price.Location = new System.Drawing.Point(18, 62);
            this.upgrade4Price.Name = "upgrade4Price";
            this.upgrade4Price.Size = new System.Drawing.Size(60, 20);
            this.upgrade4Price.TabIndex = 21;
            this.upgrade4Price.Text = "30";
            this.upgrade4Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade4Price.Click += new System.EventHandler(this.upgrade4Quantity_Click);
            // 
            // upgrade4Description
            // 
            this.upgrade4Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade4Description.ForeColor = System.Drawing.Color.White;
            this.upgrade4Description.Location = new System.Drawing.Point(20, 24);
            this.upgrade4Description.Name = "upgrade4Description";
            this.upgrade4Description.Size = new System.Drawing.Size(189, 40);
            this.upgrade4Description.TabIndex = 19;
            this.upgrade4Description.Text = "Explodes with flaming balls that set bricks on fire";
            this.upgrade4Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgrade4Description.Click += new System.EventHandler(this.upgrade4Quantity_Click);
            // 
            // upgrade4Title
            // 
            this.upgrade4Title.AutoSize = true;
            this.upgrade4Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade4Title.ForeColor = System.Drawing.Color.White;
            this.upgrade4Title.Location = new System.Drawing.Point(20, 4);
            this.upgrade4Title.Name = "upgrade4Title";
            this.upgrade4Title.Size = new System.Drawing.Size(150, 20);
            this.upgrade4Title.TabIndex = 18;
            this.upgrade4Title.Text = "Fireball Explosion";
            this.upgrade4Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade4Title.Click += new System.EventHandler(this.upgrade4Quantity_Click);
            // 
            // upgrade5Quantity
            // 
            this.upgrade5Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade5Quantity.ForeColor = System.Drawing.Color.White;
            this.upgrade5Quantity.Location = new System.Drawing.Point(209, 19);
            this.upgrade5Quantity.Name = "upgrade5Quantity";
            this.upgrade5Quantity.Size = new System.Drawing.Size(51, 52);
            this.upgrade5Quantity.TabIndex = 27;
            this.upgrade5Quantity.Text = "0";
            this.upgrade5Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade5Quantity.Click += new System.EventHandler(this.upgrade5Panel_Click);
            // 
            // upgrade5Price
            // 
            this.upgrade5Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade5Price.ForeColor = System.Drawing.Color.White;
            this.upgrade5Price.Location = new System.Drawing.Point(19, 64);
            this.upgrade5Price.Name = "upgrade5Price";
            this.upgrade5Price.Size = new System.Drawing.Size(60, 18);
            this.upgrade5Price.TabIndex = 26;
            this.upgrade5Price.Text = "200";
            this.upgrade5Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade5Price.Click += new System.EventHandler(this.upgrade5Panel_Click);
            // 
            // upgrade5Description
            // 
            this.upgrade5Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade5Description.ForeColor = System.Drawing.Color.White;
            this.upgrade5Description.Location = new System.Drawing.Point(21, 27);
            this.upgrade5Description.Name = "upgrade5Description";
            this.upgrade5Description.Size = new System.Drawing.Size(189, 40);
            this.upgrade5Description.TabIndex = 24;
            this.upgrade5Description.Text = "Clears the bricks in a radius around the ball";
            this.upgrade5Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgrade5Description.Click += new System.EventHandler(this.upgrade5Panel_Click);
            // 
            // upgrade5TItle
            // 
            this.upgrade5TItle.AutoSize = true;
            this.upgrade5TItle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade5TItle.ForeColor = System.Drawing.Color.White;
            this.upgrade5TItle.Location = new System.Drawing.Point(21, 7);
            this.upgrade5TItle.Name = "upgrade5TItle";
            this.upgrade5TItle.Size = new System.Drawing.Size(95, 20);
            this.upgrade5TItle.TabIndex = 23;
            this.upgrade5TItle.Text = "Black Hole";
            this.upgrade5TItle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade5TItle.Click += new System.EventHandler(this.upgrade5Panel_Click);
            // 
            // upgrade6Quantity
            // 
            this.upgrade6Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade6Quantity.ForeColor = System.Drawing.Color.White;
            this.upgrade6Quantity.Location = new System.Drawing.Point(207, 15);
            this.upgrade6Quantity.Name = "upgrade6Quantity";
            this.upgrade6Quantity.Size = new System.Drawing.Size(51, 52);
            this.upgrade6Quantity.TabIndex = 32;
            this.upgrade6Quantity.Text = "0";
            this.upgrade6Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade6Quantity.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // upgrade6Price
            // 
            this.upgrade6Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade6Price.ForeColor = System.Drawing.Color.White;
            this.upgrade6Price.Location = new System.Drawing.Point(17, 62);
            this.upgrade6Price.Name = "upgrade6Price";
            this.upgrade6Price.Size = new System.Drawing.Size(60, 17);
            this.upgrade6Price.TabIndex = 31;
            this.upgrade6Price.Text = "500";
            this.upgrade6Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade6Price.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // upgrade6Icon
            // 
            this.upgrade6Icon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade6Icon.ForeColor = System.Drawing.Color.White;
            this.upgrade6Icon.Location = new System.Drawing.Point(81, 62);
            this.upgrade6Icon.Name = "upgrade6Icon";
            this.upgrade6Icon.Size = new System.Drawing.Size(60, 17);
            this.upgrade6Icon.TabIndex = 30;
            this.upgrade6Icon.Text = "N/A";
            this.upgrade6Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade6Icon.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // upgrade6Description
            // 
            this.upgrade6Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade6Description.ForeColor = System.Drawing.Color.White;
            this.upgrade6Description.Location = new System.Drawing.Point(19, 23);
            this.upgrade6Description.Name = "upgrade6Description";
            this.upgrade6Description.Size = new System.Drawing.Size(189, 40);
            this.upgrade6Description.TabIndex = 29;
            this.upgrade6Description.Text = "Randomized level. Could be worth the price...";
            this.upgrade6Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.upgrade6Description.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // upgrade6Title
            // 
            this.upgrade6Title.AutoSize = true;
            this.upgrade6Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upgrade6Title.ForeColor = System.Drawing.Color.White;
            this.upgrade6Title.Location = new System.Drawing.Point(19, 3);
            this.upgrade6Title.Name = "upgrade6Title";
            this.upgrade6Title.Size = new System.Drawing.Size(220, 20);
            this.upgrade6Title.TabIndex = 28;
            this.upgrade6Title.Text = "Purchase Random Level💀";
            this.upgrade6Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.upgrade6Title.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsButton.ForeColor = System.Drawing.Color.White;
            this.statisticsButton.Location = new System.Drawing.Point(976, 26);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(79, 47);
            this.statisticsButton.TabIndex = 33;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // htpButton
            // 
            this.htpButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.htpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.htpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htpButton.ForeColor = System.Drawing.Color.White;
            this.htpButton.Location = new System.Drawing.Point(1070, 26);
            this.htpButton.Name = "htpButton";
            this.htpButton.Size = new System.Drawing.Size(77, 47);
            this.htpButton.TabIndex = 34;
            this.htpButton.Text = "How to Play";
            this.htpButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitLabel
            // 
            this.exitLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exitLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitLabel.ForeColor = System.Drawing.Color.White;
            this.exitLabel.Location = new System.Drawing.Point(1159, 26);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(77, 47);
            this.exitLabel.TabIndex = 35;
            this.exitLabel.Text = "Exit";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // sandwichQuantity
            // 
            this.sandwichQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sandwichQuantity.ForeColor = System.Drawing.Color.White;
            this.sandwichQuantity.Location = new System.Drawing.Point(3, 661);
            this.sandwichQuantity.Name = "sandwichQuantity";
            this.sandwichQuantity.Size = new System.Drawing.Size(60, 30);
            this.sandwichQuantity.TabIndex = 36;
            this.sandwichQuantity.Text = "20";
            this.sandwichQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upgrade2Panel
            // 
            this.upgrade2Panel.Controls.Add(this.upgrade2Title);
            this.upgrade2Panel.Controls.Add(this.upgrade2Description);
            this.upgrade2Panel.Controls.Add(this.upgrade2Icon);
            this.upgrade2Panel.Controls.Add(this.upgrade2Price);
            this.upgrade2Panel.Controls.Add(this.upgrade2Quantity);
            this.upgrade2Panel.Location = new System.Drawing.Point(953, 203);
            this.upgrade2Panel.Name = "upgrade2Panel";
            this.upgrade2Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade2Panel.TabIndex = 39;
            this.upgrade2Panel.Click += new System.EventHandler(this.upgrade2Panel_Click);
            // 
            // upgrade1Panel
            // 
            this.upgrade1Panel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.upgrade1Panel.Controls.Add(this.label2);
            this.upgrade1Panel.Controls.Add(this.label6);
            this.upgrade1Panel.Controls.Add(this.label3);
            this.upgrade1Panel.Controls.Add(this.label5);
            this.upgrade1Panel.Controls.Add(this.label4);
            this.upgrade1Panel.Location = new System.Drawing.Point(953, 103);
            this.upgrade1Panel.Name = "upgrade1Panel";
            this.upgrade1Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade1Panel.TabIndex = 41;
            this.upgrade1Panel.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(211, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 52);
            this.label2.TabIndex = 46;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(23, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Paddle Width Upgrade";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "5";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 40);
            this.label5.TabIndex = 43;
            this.label5.Text = "Permanently increase paddle width";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(85, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "N/A";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.upgrade1Panel_Click);
            // 
            // upgrade3Panel
            // 
            this.upgrade3Panel.Controls.Add(this.upgrade3Title);
            this.upgrade3Panel.Controls.Add(this.upgrade3Description);
            this.upgrade3Panel.Controls.Add(this.upgrade3Icon);
            this.upgrade3Panel.Controls.Add(this.upgrade3Price);
            this.upgrade3Panel.Controls.Add(this.upgrade3Quantity);
            this.upgrade3Panel.Location = new System.Drawing.Point(953, 303);
            this.upgrade3Panel.Name = "upgrade3Panel";
            this.upgrade3Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade3Panel.TabIndex = 42;
            this.upgrade3Panel.Click += new System.EventHandler(this.upgrade3Panel_Click);
            // 
            // upgrade4Panel
            // 
            this.upgrade4Panel.Controls.Add(this.upgrade4Icon);
            this.upgrade4Panel.Controls.Add(this.upgrade4Title);
            this.upgrade4Panel.Controls.Add(this.upgrade4Description);
            this.upgrade4Panel.Controls.Add(this.upgrade4Price);
            this.upgrade4Panel.Controls.Add(this.upgrade4Quantity);
            this.upgrade4Panel.Location = new System.Drawing.Point(953, 402);
            this.upgrade4Panel.Name = "upgrade4Panel";
            this.upgrade4Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade4Panel.TabIndex = 43;
            this.upgrade4Panel.Click += new System.EventHandler(this.upgrade4Quantity_Click);
            // 
            // upgrade5Panel
            // 
            this.upgrade5Panel.Controls.Add(this.upgrade5Icon);
            this.upgrade5Panel.Controls.Add(this.upgrade5Description);
            this.upgrade5Panel.Controls.Add(this.upgrade5TItle);
            this.upgrade5Panel.Controls.Add(this.upgrade5Price);
            this.upgrade5Panel.Controls.Add(this.upgrade5Quantity);
            this.upgrade5Panel.Location = new System.Drawing.Point(953, 503);
            this.upgrade5Panel.Name = "upgrade5Panel";
            this.upgrade5Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade5Panel.TabIndex = 44;
            this.upgrade5Panel.Click += new System.EventHandler(this.upgrade5Panel_Click);
            // 
            // upgrade6Panel
            // 
            this.upgrade6Panel.Controls.Add(this.upgrade6Title);
            this.upgrade6Panel.Controls.Add(this.upgrade6Description);
            this.upgrade6Panel.Controls.Add(this.upgrade6Icon);
            this.upgrade6Panel.Controls.Add(this.upgrade6Price);
            this.upgrade6Panel.Controls.Add(this.upgrade6Quantity);
            this.upgrade6Panel.Location = new System.Drawing.Point(953, 604);
            this.upgrade6Panel.Name = "upgrade6Panel";
            this.upgrade6Panel.Size = new System.Drawing.Size(300, 95);
            this.upgrade6Panel.TabIndex = 45;
            this.upgrade6Panel.Click += new System.EventHandler(this.upgrade6Panel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BrickBreaker.Properties.Resources.speed1;
            this.pictureBox1.Location = new System.Drawing.Point(676, 327);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // upgrade5Icon
            // 
            this.upgrade5Icon.BackColor = System.Drawing.Color.Transparent;
            this.upgrade5Icon.Location = new System.Drawing.Point(101, 61);
            this.upgrade5Icon.Name = "upgrade5Icon";
            this.upgrade5Icon.Size = new System.Drawing.Size(40, 31);
            this.upgrade5Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upgrade5Icon.TabIndex = 46;
            this.upgrade5Icon.TabStop = false;
            // 
            // upgrade4Icon
            // 
            this.upgrade4Icon.BackColor = System.Drawing.Color.Transparent;
            this.upgrade4Icon.Location = new System.Drawing.Point(84, 62);
            this.upgrade4Icon.Name = "upgrade4Icon";
            this.upgrade4Icon.Size = new System.Drawing.Size(57, 30);
            this.upgrade4Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upgrade4Icon.TabIndex = 46;
            this.upgrade4Icon.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.upgrade6Panel);
            this.Controls.Add(this.upgrade5Panel);
            this.Controls.Add(this.upgrade4Panel);
            this.Controls.Add(this.upgrade3Panel);
            this.Controls.Add(this.upgrade1Panel);
            this.Controls.Add(this.upgrade2Panel);
            this.Controls.Add(this.sandwichQuantity);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.htpButton);
            this.Controls.Add(this.statisticsButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1250, 700);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.upgrade2Panel.ResumeLayout(false);
            this.upgrade2Panel.PerformLayout();
            this.upgrade1Panel.ResumeLayout(false);
            this.upgrade1Panel.PerformLayout();
            this.upgrade3Panel.ResumeLayout(false);
            this.upgrade3Panel.PerformLayout();
            this.upgrade4Panel.ResumeLayout(false);
            this.upgrade4Panel.PerformLayout();
            this.upgrade5Panel.ResumeLayout(false);
            this.upgrade5Panel.PerformLayout();
            this.upgrade6Panel.ResumeLayout(false);
            this.upgrade6Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgrade5Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upgrade4Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label upgrade2Quantity;
        private System.Windows.Forms.Label upgrade2Price;
        private System.Windows.Forms.Label upgrade2Icon;
        private System.Windows.Forms.Label upgrade2Description;
        private System.Windows.Forms.Label upgrade2Title;
        private System.Windows.Forms.Label upgrade3Quantity;
        private System.Windows.Forms.Label upgrade3Price;
        private System.Windows.Forms.Label upgrade3Icon;
        private System.Windows.Forms.Label upgrade3Description;
        private System.Windows.Forms.Label upgrade3Title;
        private System.Windows.Forms.Label upgrade4Quantity;
        private System.Windows.Forms.Label upgrade4Price;
        private System.Windows.Forms.Label upgrade4Description;
        private System.Windows.Forms.Label upgrade4Title;
        private System.Windows.Forms.Label upgrade5Quantity;
        private System.Windows.Forms.Label upgrade5Price;
        private System.Windows.Forms.Label upgrade5Description;
        private System.Windows.Forms.Label upgrade5TItle;
        private System.Windows.Forms.Label upgrade6Quantity;
        private System.Windows.Forms.Label upgrade6Price;
        private System.Windows.Forms.Label upgrade6Icon;
        private System.Windows.Forms.Label upgrade6Description;
        private System.Windows.Forms.Label upgrade6Title;
        private System.Windows.Forms.Label statisticsButton;
        private System.Windows.Forms.Label htpButton;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label sandwichQuantity;
        private System.Windows.Forms.Panel upgrade2Panel;
        private System.Windows.Forms.Panel upgrade1Panel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel upgrade3Panel;
        private System.Windows.Forms.Panel upgrade4Panel;
        private System.Windows.Forms.Panel upgrade5Panel;
        private System.Windows.Forms.Panel upgrade6Panel;
        private System.Windows.Forms.PictureBox upgrade4Icon;
        private System.Windows.Forms.PictureBox upgrade5Icon;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
