namespace OSAPP
{
    partial class APPOINTMENTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APPOINTMENTS));
            this.panel5 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPRICE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxSERVICES = new System.Windows.Forms.ListBox();
            this.pictureBoxCPIC = new System.Windows.Forms.PictureBox();
            this.labelGENDER = new System.Windows.Forms.Label();
            this.labelNAME = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewAPPOINTMENTS = new System.Windows.Forms.ListView();
            this.labelAPPOINTMENTS = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewBARBERS = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCPIC)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(1217, 15);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(65, 61);
            this.panel5.TabIndex = 125;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(250, 75);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(125, 125);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.labelPRICE);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.listBoxSERVICES);
            this.panel3.Controls.Add(this.pictureBoxCPIC);
            this.panel3.Controls.Add(this.labelGENDER);
            this.panel3.Controls.Add(this.labelNAME);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(791, 94);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(432, 491);
            this.panel3.TabIndex = 324;
            // 
            // labelPRICE
            // 
            this.labelPRICE.AutoSize = true;
            this.labelPRICE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPRICE.ForeColor = System.Drawing.Color.White;
            this.labelPRICE.Location = new System.Drawing.Point(5, 437);
            this.labelPRICE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPRICE.Name = "labelPRICE";
            this.labelPRICE.Size = new System.Drawing.Size(82, 33);
            this.labelPRICE.TabIndex = 331;
            this.labelPRICE.Text = "PRICE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 271);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 33);
            this.label3.TabIndex = 330;
            this.label3.Text = "SERVICES:";
            // 
            // listBoxSERVICES
            // 
            this.listBoxSERVICES.BackColor = System.Drawing.Color.LightGray;
            this.listBoxSERVICES.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold);
            this.listBoxSERVICES.FormattingEnabled = true;
            this.listBoxSERVICES.ItemHeight = 31;
            this.listBoxSERVICES.Location = new System.Drawing.Point(11, 305);
            this.listBoxSERVICES.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxSERVICES.Name = "listBoxSERVICES";
            this.listBoxSERVICES.Size = new System.Drawing.Size(263, 97);
            this.listBoxSERVICES.TabIndex = 325;
            // 
            // pictureBoxCPIC
            // 
            this.pictureBoxCPIC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxCPIC.Location = new System.Drawing.Point(133, 52);
            this.pictureBoxCPIC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxCPIC.Name = "pictureBoxCPIC";
            this.pictureBoxCPIC.Size = new System.Drawing.Size(165, 153);
            this.pictureBoxCPIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCPIC.TabIndex = 329;
            this.pictureBoxCPIC.TabStop = false;
            // 
            // labelGENDER
            // 
            this.labelGENDER.AutoSize = true;
            this.labelGENDER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGENDER.ForeColor = System.Drawing.Color.White;
            this.labelGENDER.Location = new System.Drawing.Point(5, 240);
            this.labelGENDER.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGENDER.Name = "labelGENDER";
            this.labelGENDER.Size = new System.Drawing.Size(106, 33);
            this.labelGENDER.TabIndex = 328;
            this.labelGENDER.Text = "GENDER:";
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(5, 209);
            this.labelNAME.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(81, 33);
            this.labelNAME.TabIndex = 326;
            this.labelNAME.Text = "NAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 45);
            this.label1.TabIndex = 323;
            this.label1.Text = "CUSTOMER DETAILS:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listViewAPPOINTMENTS);
            this.panel2.Controls.Add(this.labelAPPOINTMENTS);
            this.panel2.Location = new System.Drawing.Point(349, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 491);
            this.panel2.TabIndex = 323;
            // 
            // listViewAPPOINTMENTS
            // 
            this.listViewAPPOINTMENTS.BackColor = System.Drawing.Color.LightGray;
            this.listViewAPPOINTMENTS.HideSelection = false;
            this.listViewAPPOINTMENTS.LargeImageList = this.imageList2;
            this.listViewAPPOINTMENTS.Location = new System.Drawing.Point(12, 47);
            this.listViewAPPOINTMENTS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewAPPOINTMENTS.Name = "listViewAPPOINTMENTS";
            this.listViewAPPOINTMENTS.Size = new System.Drawing.Size(399, 430);
            this.listViewAPPOINTMENTS.SmallImageList = this.imageList2;
            this.listViewAPPOINTMENTS.TabIndex = 294;
            this.listViewAPPOINTMENTS.UseCompatibleStateImageBehavior = false;
            this.listViewAPPOINTMENTS.SelectedIndexChanged += new System.EventHandler(this.listViewAPPOINTMENTS_SelectedIndexChanged);
            // 
            // labelAPPOINTMENTS
            // 
            this.labelAPPOINTMENTS.AutoSize = true;
            this.labelAPPOINTMENTS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPPOINTMENTS.ForeColor = System.Drawing.Color.White;
            this.labelAPPOINTMENTS.Location = new System.Drawing.Point(4, 0);
            this.labelAPPOINTMENTS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAPPOINTMENTS.Name = "labelAPPOINTMENTS";
            this.labelAPPOINTMENTS.Size = new System.Drawing.Size(309, 45);
            this.labelAPPOINTMENTS.TabIndex = 293;
            this.labelAPPOINTMENTS.Text = "ALL APPOINTMENTS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.listViewBARBERS);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(75, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 491);
            this.panel1.TabIndex = 322;
            // 
            // listViewBARBERS
            // 
            this.listViewBARBERS.BackColor = System.Drawing.Color.LightGray;
            this.listViewBARBERS.HideSelection = false;
            this.listViewBARBERS.LargeImageList = this.imageList1;
            this.listViewBARBERS.Location = new System.Drawing.Point(17, 50);
            this.listViewBARBERS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewBARBERS.Name = "listViewBARBERS";
            this.listViewBARBERS.Size = new System.Drawing.Size(225, 430);
            this.listViewBARBERS.SmallImageList = this.imageList1;
            this.listViewBARBERS.TabIndex = 296;
            this.listViewBARBERS.UseCompatibleStateImageBehavior = false;
            this.listViewBARBERS.SelectedIndexChanged += new System.EventHandler(this.listViewBARBERS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 45);
            this.label4.TabIndex = 295;
            this.label4.Text = "BARBERS:";
            // 
            // APPOINTMENTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 677);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "APPOINTMENTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APPOINTMENTS";
            this.Load += new System.EventHandler(this.APPOINTMENTS_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCPIC)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewAPPOINTMENTS;
        private System.Windows.Forms.Label labelAPPOINTMENTS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewBARBERS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxCPIC;
        private System.Windows.Forms.Label labelGENDER;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxSERVICES;
        private System.Windows.Forms.Label labelPRICE;
    }
}