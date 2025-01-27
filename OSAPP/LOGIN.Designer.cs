namespace OSAPP
{
    partial class LOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLOGIN = new System.Windows.Forms.Button();
            this.pictureBoxLOADING = new System.Windows.Forms.PictureBox();
            this.labelFPASS = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxSHOWPASS = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPASS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxUNAME = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.c_APPOINTMENT1 = new OSAPP.C_APPOINTMENT();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxRATE = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLOADING)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRATE)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonLOGIN);
            this.panel1.Controls.Add(this.pictureBoxLOADING);
            this.panel1.Controls.Add(this.labelFPASS);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkBoxSHOWPASS);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxPASS);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxUNAME);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(846, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 475);
            this.panel1.TabIndex = 122;
            // 
            // buttonLOGIN
            // 
            this.buttonLOGIN.BackColor = System.Drawing.Color.Gold;
            this.buttonLOGIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLOGIN.FlatAppearance.BorderSize = 0;
            this.buttonLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLOGIN.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLOGIN.ForeColor = System.Drawing.Color.Black;
            this.buttonLOGIN.Location = new System.Drawing.Point(85, 340);
            this.buttonLOGIN.Name = "buttonLOGIN";
            this.buttonLOGIN.Size = new System.Drawing.Size(200, 50);
            this.buttonLOGIN.TabIndex = 5;
            this.buttonLOGIN.Text = "LOGIN";
            this.buttonLOGIN.UseVisualStyleBackColor = false;
            this.buttonLOGIN.Click += new System.EventHandler(this.buttonLOGIN_Click);
            // 
            // pictureBoxLOADING
            // 
            this.pictureBoxLOADING.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLOADING.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLOADING.Image")));
            this.pictureBoxLOADING.Location = new System.Drawing.Point(163, 340);
            this.pictureBoxLOADING.Name = "pictureBoxLOADING";
            this.pictureBoxLOADING.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLOADING.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLOADING.TabIndex = 136;
            this.pictureBoxLOADING.TabStop = false;
            // 
            // labelFPASS
            // 
            this.labelFPASS.AutoSize = true;
            this.labelFPASS.BackColor = System.Drawing.Color.Transparent;
            this.labelFPASS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFPASS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPASS.ForeColor = System.Drawing.Color.Gold;
            this.labelFPASS.Location = new System.Drawing.Point(27, 295);
            this.labelFPASS.Name = "labelFPASS";
            this.labelFPASS.Size = new System.Drawing.Size(159, 23);
            this.labelFPASS.TabIndex = 4;
            this.labelFPASS.Text = "FORGOT PASSWORD?";
            this.labelFPASS.Click += new System.EventHandler(this.labelFPASS_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBoxRATE);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 396);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 75);
            this.panel2.TabIndex = 130;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(83, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "BOOK APPOINTMENT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxSHOWPASS
            // 
            this.checkBoxSHOWPASS.AutoSize = true;
            this.checkBoxSHOWPASS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSHOWPASS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSHOWPASS.ForeColor = System.Drawing.Color.White;
            this.checkBoxSHOWPASS.Location = new System.Drawing.Point(190, 296);
            this.checkBoxSHOWPASS.Name = "checkBoxSHOWPASS";
            this.checkBoxSHOWPASS.Size = new System.Drawing.Size(135, 23);
            this.checkBoxSHOWPASS.TabIndex = 3;
            this.checkBoxSHOWPASS.Text = "SHOW PASSWORD";
            this.checkBoxSHOWPASS.UseVisualStyleBackColor = true;
            this.checkBoxSHOWPASS.Click += new System.EventHandler(this.checkBoxSHOWPASS_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 128;
            this.label6.Text = "PASSWORD:";
            // 
            // textBoxPASS
            // 
            this.textBoxPASS.BackColor = System.Drawing.Color.White;
            this.textBoxPASS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPASS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPASS.ForeColor = System.Drawing.Color.Black;
            this.textBoxPASS.Location = new System.Drawing.Point(31, 257);
            this.textBoxPASS.Name = "textBoxPASS";
            this.textBoxPASS.Size = new System.Drawing.Size(294, 33);
            this.textBoxPASS.TabIndex = 2;
            this.textBoxPASS.UseSystemPasswordChar = true;
            this.textBoxPASS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPASS_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 126;
            this.label5.Text = "USERNAME:";
            // 
            // textBoxUNAME
            // 
            this.textBoxUNAME.BackColor = System.Drawing.Color.White;
            this.textBoxUNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUNAME.ForeColor = System.Drawing.Color.Black;
            this.textBoxUNAME.Location = new System.Drawing.Point(31, 193);
            this.textBoxUNAME.Name = "textBoxUNAME";
            this.textBoxUNAME.Size = new System.Drawing.Size(294, 33);
            this.textBoxUNAME.TabIndex = 1;
            this.textBoxUNAME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUNAME_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(110, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(1264, 162);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(49, 50);
            this.panel4.TabIndex = 125;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // c_APPOINTMENT1
            // 
            this.c_APPOINTMENT1.AFirstName = null;
            this.c_APPOINTMENT1.ALastName = null;
            this.c_APPOINTMENT1.AProfilePictureData = null;
            this.c_APPOINTMENT1.BackColor = System.Drawing.Color.Transparent;
            this.c_APPOINTMENT1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_APPOINTMENT1.Location = new System.Drawing.Point(232, 151);
            this.c_APPOINTMENT1.Margin = new System.Windows.Forms.Padding(4);
            this.c_APPOINTMENT1.Name = "c_APPOINTMENT1";
            this.c_APPOINTMENT1.Size = new System.Drawing.Size(1092, 542);
            this.c_APPOINTMENT1.TabIndex = 124;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(1390, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(49, 50);
            this.panel3.TabIndex = 121;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // pictureBoxRATE
            // 
            this.pictureBoxRATE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRATE.Image = global::OSAPP.Properties.Resources.filledstar;
            this.pictureBoxRATE.Location = new System.Drawing.Point(16, 5);
            this.pictureBoxRATE.Name = "pictureBoxRATE";
            this.pictureBoxRATE.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxRATE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRATE.TabIndex = 195;
            this.pictureBoxRATE.TabStop = false;
            this.pictureBoxRATE.Click += new System.EventHandler(this.pictureBoxRATE_Click);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1451, 894);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.c_APPOINTMENT1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LOGIN";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LOGIN_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLOADING)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRATE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelFPASS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxLOADING;
        private System.Windows.Forms.CheckBox checkBoxSHOWPASS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPASS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUNAME;
        private System.Windows.Forms.PictureBox pictureBox1;
        private C_APPOINTMENT c_APPOINTMENT1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonLOGIN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBoxRATE;
    }
}