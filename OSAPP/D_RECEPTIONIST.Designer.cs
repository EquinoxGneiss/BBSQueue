namespace OSAPP
{
    partial class D_RECEPTIONIST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(D_RECEPTIONIST));
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCASHIER = new System.Windows.Forms.Button();
            this.buttonQUES = new System.Windows.Forms.Button();
            this.buttonWALKIN = new System.Windows.Forms.Button();
            this.labelNAME = new System.Windows.Forms.Label();
            this.pictureBoxPROFILE = new System.Windows.Forms.PictureBox();
            this.buttonAPPOINTMENT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c_APPOINTMENT1 = new OSAPP.C_APPOINTMENT();
            this.c_CASHIER1 = new OSAPP.C_CASHIER();
            this.c_QUE1 = new OSAPP.C_QUE();
            this.c_WALKIN1 = new OSAPP.C_WALKIN();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonCASHIER);
            this.panel2.Controls.Add(this.buttonQUES);
            this.panel2.Controls.Add(this.buttonWALKIN);
            this.panel2.Controls.Add(this.labelNAME);
            this.panel2.Controls.Add(this.pictureBoxPROFILE);
            this.panel2.Controls.Add(this.buttonAPPOINTMENT);
            this.panel2.Location = new System.Drawing.Point(83, 148);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 676);
            this.panel2.TabIndex = 8;
            // 
            // buttonCASHIER
            // 
            this.buttonCASHIER.BackColor = System.Drawing.Color.Gold;
            this.buttonCASHIER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCASHIER.FlatAppearance.BorderSize = 0;
            this.buttonCASHIER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCASHIER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCASHIER.ForeColor = System.Drawing.Color.Black;
            this.buttonCASHIER.Location = new System.Drawing.Point(67, 586);
            this.buttonCASHIER.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCASHIER.Name = "buttonCASHIER";
            this.buttonCASHIER.Size = new System.Drawing.Size(267, 62);
            this.buttonCASHIER.TabIndex = 113;
            this.buttonCASHIER.Text = "CASHIER";
            this.buttonCASHIER.UseVisualStyleBackColor = false;
            this.buttonCASHIER.Click += new System.EventHandler(this.buttonCASHIER_Click);
            // 
            // buttonQUES
            // 
            this.buttonQUES.BackColor = System.Drawing.Color.Gold;
            this.buttonQUES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQUES.FlatAppearance.BorderSize = 0;
            this.buttonQUES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQUES.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQUES.ForeColor = System.Drawing.Color.Black;
            this.buttonQUES.Location = new System.Drawing.Point(67, 503);
            this.buttonQUES.Margin = new System.Windows.Forms.Padding(4);
            this.buttonQUES.Name = "buttonQUES";
            this.buttonQUES.Size = new System.Drawing.Size(267, 62);
            this.buttonQUES.TabIndex = 112;
            this.buttonQUES.Text = "QUES";
            this.buttonQUES.UseVisualStyleBackColor = false;
            this.buttonQUES.Click += new System.EventHandler(this.buttonQUES_Click);
            // 
            // buttonWALKIN
            // 
            this.buttonWALKIN.BackColor = System.Drawing.Color.Gold;
            this.buttonWALKIN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonWALKIN.FlatAppearance.BorderSize = 0;
            this.buttonWALKIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWALKIN.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWALKIN.ForeColor = System.Drawing.Color.Black;
            this.buttonWALKIN.Location = new System.Drawing.Point(67, 421);
            this.buttonWALKIN.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWALKIN.Name = "buttonWALKIN";
            this.buttonWALKIN.Size = new System.Drawing.Size(267, 62);
            this.buttonWALKIN.TabIndex = 111;
            this.buttonWALKIN.Text = "WALK-IN";
            this.buttonWALKIN.UseVisualStyleBackColor = false;
            this.buttonWALKIN.Click += new System.EventHandler(this.buttonWALKIN_Click);
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
            this.pictureBoxPROFILE.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPROFILE.Name = "pictureBoxPROFILE";
            this.pictureBoxPROFILE.Size = new System.Drawing.Size(265, 245);
            this.pictureBoxPROFILE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPROFILE.TabIndex = 109;
            this.pictureBoxPROFILE.TabStop = false;
            // 
            // buttonAPPOINTMENT
            // 
            this.buttonAPPOINTMENT.BackColor = System.Drawing.Color.Gold;
            this.buttonAPPOINTMENT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAPPOINTMENT.FlatAppearance.BorderSize = 0;
            this.buttonAPPOINTMENT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAPPOINTMENT.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAPPOINTMENT.ForeColor = System.Drawing.Color.Black;
            this.buttonAPPOINTMENT.Location = new System.Drawing.Point(67, 341);
            this.buttonAPPOINTMENT.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAPPOINTMENT.Name = "buttonAPPOINTMENT";
            this.buttonAPPOINTMENT.Size = new System.Drawing.Size(267, 62);
            this.buttonAPPOINTMENT.TabIndex = 108;
            this.buttonAPPOINTMENT.Text = "APPOINTMENT";
            this.buttonAPPOINTMENT.UseVisualStyleBackColor = false;
            this.buttonAPPOINTMENT.Click += new System.EventHandler(this.buttonAPPOINTMENT_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.c_APPOINTMENT1);
            this.panel1.Controls.Add(this.c_CASHIER1);
            this.panel1.Controls.Add(this.c_QUE1);
            this.panel1.Controls.Add(this.c_WALKIN1);
            this.panel1.Location = new System.Drawing.Point(491, 148);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1475, 676);
            this.panel1.TabIndex = 7;
            // 
            // c_APPOINTMENT1
            // 
            this.c_APPOINTMENT1.AFirstName = null;
            this.c_APPOINTMENT1.ALastName = null;
            this.c_APPOINTMENT1.AProfilePictureData = null;
            this.c_APPOINTMENT1.BackColor = System.Drawing.Color.Transparent;
            this.c_APPOINTMENT1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_APPOINTMENT1.Location = new System.Drawing.Point(4, -2);
            this.c_APPOINTMENT1.Margin = new System.Windows.Forms.Padding(5);
            this.c_APPOINTMENT1.Name = "c_APPOINTMENT1";
            this.c_APPOINTMENT1.Size = new System.Drawing.Size(1455, 666);
            this.c_APPOINTMENT1.TabIndex = 5;
            this.c_APPOINTMENT1.Load += new System.EventHandler(this.c_APPOINTMENT1_Load);
            // 
            // c_CASHIER1
            // 
            this.c_CASHIER1.BackColor = System.Drawing.Color.Transparent;
            this.c_CASHIER1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_CASHIER1.Location = new System.Drawing.Point(1, -2);
            this.c_CASHIER1.Margin = new System.Windows.Forms.Padding(5);
            this.c_CASHIER1.Name = "c_CASHIER1";
            this.c_CASHIER1.Size = new System.Drawing.Size(1460, 671);
            this.c_CASHIER1.TabIndex = 4;
            // 
            // c_QUE1
            // 
            this.c_QUE1.BackColor = System.Drawing.Color.Transparent;
            this.c_QUE1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_QUE1.Location = new System.Drawing.Point(1, -2);
            this.c_QUE1.Margin = new System.Windows.Forms.Padding(5);
            this.c_QUE1.Name = "c_QUE1";
            this.c_QUE1.Size = new System.Drawing.Size(1465, 676);
            this.c_QUE1.TabIndex = 3;
            // 
            // c_WALKIN1
            // 
            this.c_WALKIN1.BackColor = System.Drawing.Color.Transparent;
            this.c_WALKIN1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c_WALKIN1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c_WALKIN1.Location = new System.Drawing.Point(1, -2);
            this.c_WALKIN1.Margin = new System.Windows.Forms.Padding(5);
            this.c_WALKIN1.Name = "c_WALKIN1";
            this.c_WALKIN1.Size = new System.Drawing.Size(1465, 676);
            this.c_WALKIN1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(1864, 13);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(65, 61);
            this.panel5.TabIndex = 124;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // D_RECEPTIONIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1942, 892);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "D_RECEPTIONIST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.D_RECEPTIONIST_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCASHIER;
        private System.Windows.Forms.Button buttonQUES;
        private System.Windows.Forms.Button buttonWALKIN;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.PictureBox pictureBoxPROFILE;
        private System.Windows.Forms.Button buttonAPPOINTMENT;
        private System.Windows.Forms.Panel panel1;
        private C_WALKIN c_WALKIN1;
        private C_QUE c_QUE1;
        private C_CASHIER c_CASHIER1;
        private System.Windows.Forms.Panel panel5;
        private C_APPOINTMENT c_APPOINTMENT1;
    }
}