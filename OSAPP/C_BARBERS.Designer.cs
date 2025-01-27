namespace OSAPP
{
    partial class C_BARBERS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_BARBERS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNAME = new System.Windows.Forms.Label();
            this.buttonABARBER = new System.Windows.Forms.Button();
            this.listViewBARBERS = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonUPDATEPIC = new System.Windows.Forms.Button();
            this.pictureBoxPROFILE = new System.Windows.Forms.PictureBox();
            this.textBoxFNAME = new System.Windows.Forms.TextBox();
            this.textBoxLNAME = new System.Windows.Forms.TextBox();
            this.buttonUPDATE = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelNAME);
            this.panel1.Controls.Add(this.buttonABARBER);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 75);
            this.panel1.TabIndex = 114;
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(329, 6);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(209, 58);
            this.labelNAME.TabIndex = 117;
            this.labelNAME.Text = "BARBERS:";
            // 
            // buttonABARBER
            // 
            this.buttonABARBER.BackColor = System.Drawing.Color.Gold;
            this.buttonABARBER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonABARBER.FlatAppearance.BorderSize = 0;
            this.buttonABARBER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonABARBER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonABARBER.ForeColor = System.Drawing.Color.Black;
            this.buttonABARBER.Location = new System.Drawing.Point(731, 17);
            this.buttonABARBER.Name = "buttonABARBER";
            this.buttonABARBER.Size = new System.Drawing.Size(125, 35);
            this.buttonABARBER.TabIndex = 119;
            this.buttonABARBER.Text = "ADD BARBER";
            this.buttonABARBER.UseVisualStyleBackColor = false;
            this.buttonABARBER.Click += new System.EventHandler(this.buttonABARBER_Click);
            // 
            // listViewBARBERS
            // 
            this.listViewBARBERS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listViewBARBERS.ForeColor = System.Drawing.Color.Black;
            this.listViewBARBERS.HideSelection = false;
            this.listViewBARBERS.Location = new System.Drawing.Point(269, 81);
            this.listViewBARBERS.Name = "listViewBARBERS";
            this.listViewBARBERS.Size = new System.Drawing.Size(589, 395);
            this.listViewBARBERS.TabIndex = 118;
            this.listViewBARBERS.UseCompatibleStateImageBehavior = false;
            this.listViewBARBERS.SelectedIndexChanged += new System.EventHandler(this.listViewBARBERS_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonUPDATEPIC
            // 
            this.buttonUPDATEPIC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonUPDATEPIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUPDATEPIC.FlatAppearance.BorderSize = 0;
            this.buttonUPDATEPIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUPDATEPIC.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUPDATEPIC.ForeColor = System.Drawing.Color.Black;
            this.buttonUPDATEPIC.Location = new System.Drawing.Point(50, 262);
            this.buttonUPDATEPIC.Name = "buttonUPDATEPIC";
            this.buttonUPDATEPIC.Size = new System.Drawing.Size(175, 35);
            this.buttonUPDATEPIC.TabIndex = 120;
            this.buttonUPDATEPIC.Text = "UPDATE PHOTO";
            this.buttonUPDATEPIC.UseVisualStyleBackColor = false;
            this.buttonUPDATEPIC.Click += new System.EventHandler(this.buttonUPDATEPIC_Click);
            // 
            // pictureBoxPROFILE
            // 
            this.pictureBoxPROFILE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPROFILE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPROFILE.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPROFILE.Image")));
            this.pictureBoxPROFILE.Location = new System.Drawing.Point(50, 81);
            this.pictureBoxPROFILE.Name = "pictureBoxPROFILE";
            this.pictureBoxPROFILE.Size = new System.Drawing.Size(175, 175);
            this.pictureBoxPROFILE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPROFILE.TabIndex = 121;
            this.pictureBoxPROFILE.TabStop = false;
            this.pictureBoxPROFILE.Click += new System.EventHandler(this.pictureBoxPROFILE_Click);
            // 
            // textBoxFNAME
            // 
            this.textBoxFNAME.BackColor = System.Drawing.Color.White;
            this.textBoxFNAME.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFNAME.ForeColor = System.Drawing.Color.Black;
            this.textBoxFNAME.Location = new System.Drawing.Point(13, 328);
            this.textBoxFNAME.Name = "textBoxFNAME";
            this.textBoxFNAME.Size = new System.Drawing.Size(250, 26);
            this.textBoxFNAME.TabIndex = 122;
            this.textBoxFNAME.TextChanged += new System.EventHandler(this.textBoxFNAME_TextChanged);
            // 
            // textBoxLNAME
            // 
            this.textBoxLNAME.BackColor = System.Drawing.Color.White;
            this.textBoxLNAME.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLNAME.ForeColor = System.Drawing.Color.Black;
            this.textBoxLNAME.Location = new System.Drawing.Point(13, 385);
            this.textBoxLNAME.Name = "textBoxLNAME";
            this.textBoxLNAME.Size = new System.Drawing.Size(250, 26);
            this.textBoxLNAME.TabIndex = 123;
            this.textBoxLNAME.TextChanged += new System.EventHandler(this.textBoxLNAME_TextChanged);
            // 
            // buttonUPDATE
            // 
            this.buttonUPDATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonUPDATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUPDATE.FlatAppearance.BorderSize = 0;
            this.buttonUPDATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUPDATE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUPDATE.ForeColor = System.Drawing.Color.Black;
            this.buttonUPDATE.Location = new System.Drawing.Point(50, 429);
            this.buttonUPDATE.Name = "buttonUPDATE";
            this.buttonUPDATE.Size = new System.Drawing.Size(175, 35);
            this.buttonUPDATE.TabIndex = 124;
            this.buttonUPDATE.Text = "UPDATE BARBER";
            this.buttonUPDATE.UseVisualStyleBackColor = false;
            this.buttonUPDATE.Click += new System.EventHandler(this.buttonUPDATE_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 25);
            this.label8.TabIndex = 126;
            this.label8.Text = "LASTNAME:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 25);
            this.label7.TabIndex = 125;
            this.label7.Text = "FIRSTNAME:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-2, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 426);
            this.panel2.TabIndex = 127;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // C_BARBERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonUPDATE);
            this.Controls.Add(this.textBoxLNAME);
            this.Controls.Add(this.textBoxFNAME);
            this.Controls.Add(this.pictureBoxPROFILE);
            this.Controls.Add(this.buttonUPDATEPIC);
            this.Controls.Add(this.listViewBARBERS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "C_BARBERS";
            this.Size = new System.Drawing.Size(871, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.ListView listViewBARBERS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonABARBER;
        private System.Windows.Forms.Button buttonUPDATEPIC;
        private System.Windows.Forms.PictureBox pictureBoxPROFILE;
        private System.Windows.Forms.TextBox textBoxFNAME;
        private System.Windows.Forms.TextBox textBoxLNAME;
        private System.Windows.Forms.Button buttonUPDATE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
    }
}
