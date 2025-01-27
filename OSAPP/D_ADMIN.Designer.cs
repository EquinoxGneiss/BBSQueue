namespace OSAPP
{
    partial class D_ADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(D_ADMIN));
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCUSTOMERS = new System.Windows.Forms.Button();
            this.buttonBARBERS = new System.Windows.Forms.Button();
            this.buttonUSERS = new System.Windows.Forms.Button();
            this.labelNAME = new System.Windows.Forms.Label();
            this.pictureBoxPROFILE = new System.Windows.Forms.PictureBox();
            this.buttonLOGOUT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_CUSTOMERS1 = new OSAPP.C_CUSTOMERS();
            this.c_USERS1 = new OSAPP.C_USERS();
            this.C_BARBERS = new OSAPP.C_BARBERS();
            this.C_USERS = new OSAPP.C_USERS();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonCUSTOMERS);
            this.panel2.Controls.Add(this.buttonBARBERS);
            this.panel2.Controls.Add(this.buttonUSERS);
            this.panel2.Controls.Add(this.labelNAME);
            this.panel2.Controls.Add(this.pictureBoxPROFILE);
            this.panel2.Controls.Add(this.buttonLOGOUT);
            this.panel2.Location = new System.Drawing.Point(225, 213);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 676);
            this.panel2.TabIndex = 4;
            // 
            // buttonCUSTOMERS
            // 
            this.buttonCUSTOMERS.BackColor = System.Drawing.Color.Gold;
            this.buttonCUSTOMERS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCUSTOMERS.FlatAppearance.BorderSize = 0;
            this.buttonCUSTOMERS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCUSTOMERS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCUSTOMERS.ForeColor = System.Drawing.Color.Black;
            this.buttonCUSTOMERS.Location = new System.Drawing.Point(67, 505);
            this.buttonCUSTOMERS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCUSTOMERS.Name = "buttonCUSTOMERS";
            this.buttonCUSTOMERS.Size = new System.Drawing.Size(267, 62);
            this.buttonCUSTOMERS.TabIndex = 113;
            this.buttonCUSTOMERS.Text = "CUSTOMERS";
            this.buttonCUSTOMERS.UseVisualStyleBackColor = false;
            this.buttonCUSTOMERS.Click += new System.EventHandler(this.buttonCUSTOMERS_Click);
            // 
            // buttonBARBERS
            // 
            this.buttonBARBERS.BackColor = System.Drawing.Color.Gold;
            this.buttonBARBERS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBARBERS.FlatAppearance.BorderSize = 0;
            this.buttonBARBERS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBARBERS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBARBERS.ForeColor = System.Drawing.Color.Black;
            this.buttonBARBERS.Location = new System.Drawing.Point(67, 421);
            this.buttonBARBERS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBARBERS.Name = "buttonBARBERS";
            this.buttonBARBERS.Size = new System.Drawing.Size(267, 62);
            this.buttonBARBERS.TabIndex = 112;
            this.buttonBARBERS.Text = "BARBERS";
            this.buttonBARBERS.UseVisualStyleBackColor = false;
            this.buttonBARBERS.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonUSERS
            // 
            this.buttonUSERS.BackColor = System.Drawing.Color.Gold;
            this.buttonUSERS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUSERS.FlatAppearance.BorderSize = 0;
            this.buttonUSERS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUSERS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUSERS.ForeColor = System.Drawing.Color.Black;
            this.buttonUSERS.Location = new System.Drawing.Point(67, 338);
            this.buttonUSERS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUSERS.Name = "buttonUSERS";
            this.buttonUSERS.Size = new System.Drawing.Size(267, 62);
            this.buttonUSERS.TabIndex = 111;
            this.buttonUSERS.Text = "USERS";
            this.buttonUSERS.UseVisualStyleBackColor = false;
            this.buttonUSERS.Click += new System.EventHandler(this.buttonUSERS_Click);
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(60, 293);
            this.labelNAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(150, 33);
            this.labelNAME.TabIndex = 110;
            this.labelNAME.Text = "NAME LABEL";
            // 
            // pictureBoxPROFILE
            // 
            this.pictureBoxPROFILE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPROFILE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPROFILE.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPROFILE.Image")));
            this.pictureBoxPROFILE.Location = new System.Drawing.Point(67, 31);
            this.pictureBoxPROFILE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxPROFILE.Name = "pictureBoxPROFILE";
            this.pictureBoxPROFILE.Size = new System.Drawing.Size(265, 245);
            this.pictureBoxPROFILE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPROFILE.TabIndex = 109;
            this.pictureBoxPROFILE.TabStop = false;
            // 
            // buttonLOGOUT
            // 
            this.buttonLOGOUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLOGOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLOGOUT.FlatAppearance.BorderSize = 0;
            this.buttonLOGOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLOGOUT.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLOGOUT.ForeColor = System.Drawing.Color.White;
            this.buttonLOGOUT.Location = new System.Drawing.Point(67, 586);
            this.buttonLOGOUT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLOGOUT.Name = "buttonLOGOUT";
            this.buttonLOGOUT.Size = new System.Drawing.Size(267, 62);
            this.buttonLOGOUT.TabIndex = 108;
            this.buttonLOGOUT.Text = "LOGOUT";
            this.buttonLOGOUT.UseVisualStyleBackColor = false;
            this.buttonLOGOUT.Click += new System.EventHandler(this.buttonREGISTER_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.c_CUSTOMERS1);
            this.panel1.Controls.Add(this.c_USERS1);
            this.panel1.Controls.Add(this.C_BARBERS);
            this.panel1.Location = new System.Drawing.Point(632, 213);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 676);
            this.panel1.TabIndex = 3;
            // 
            // c_CUSTOMERS1
            // 
            this.c_CUSTOMERS1.BackColor = System.Drawing.Color.Transparent;
            this.c_CUSTOMERS1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_CUSTOMERS1.Location = new System.Drawing.Point(11, 10);
            this.c_CUSTOMERS1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.c_CUSTOMERS1.Name = "c_CUSTOMERS1";
            this.c_CUSTOMERS1.Size = new System.Drawing.Size(1227, 671);
            this.c_CUSTOMERS1.TabIndex = 5;
            // 
            // c_USERS1
            // 
            this.c_USERS1.AFirstName = null;
            this.c_USERS1.ALastName = null;
            this.c_USERS1.AProfilePictureData = null;
            this.c_USERS1.BackColor = System.Drawing.Color.Transparent;
            this.c_USERS1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_USERS1.Location = new System.Drawing.Point(33, 31);
            this.c_USERS1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.c_USERS1.Name = "c_USERS1";
            this.c_USERS1.Size = new System.Drawing.Size(1160, 610);
            this.c_USERS1.TabIndex = 3;
            // 
            // C_BARBERS
            // 
            this.C_BARBERS.AFirstName = null;
            this.C_BARBERS.ALastName = null;
            this.C_BARBERS.AProfilePictureData = null;
            this.C_BARBERS.BackColor = System.Drawing.Color.Transparent;
            this.C_BARBERS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.C_BARBERS.Location = new System.Drawing.Point(33, 31);
            this.C_BARBERS.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.C_BARBERS.Name = "C_BARBERS";
            this.C_BARBERS.Size = new System.Drawing.Size(1160, 610);
            this.C_BARBERS.TabIndex = 2;
            // 
            // C_USERS
            // 
            this.C_USERS.AFirstName = null;
            this.C_USERS.ALastName = null;
            this.C_USERS.AProfilePictureData = null;
            this.C_USERS.BackColor = System.Drawing.Color.Transparent;
            this.C_USERS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.C_USERS.Location = new System.Drawing.Point(25, 25);
            this.C_USERS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.C_USERS.Name = "C_USERS";
            this.C_USERS.Size = new System.Drawing.Size(875, 500);
            this.C_USERS.TabIndex = 1;
            // 
            // D_ADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1900, 1102);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "D_ADMIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D_ADMIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.D_ADMIN_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCUSTOMERS;
        private System.Windows.Forms.Button buttonBARBERS;
        private System.Windows.Forms.Button buttonUSERS;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.PictureBox pictureBoxPROFILE;
        private System.Windows.Forms.Button buttonLOGOUT;
        private C_USERS C_USERS;
        private C_BARBERS C_BARBERS;
        private C_USERS c_USERS1;
        private C_CUSTOMERS c_CUSTOMERS1;
    }
}