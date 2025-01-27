namespace OSAPP
{
    partial class C_PRODUCTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C_PRODUCTS));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNAME = new System.Windows.Forms.Label();
            this.buttonAPRODUCT = new System.Windows.Forms.Button();
            this.listViewPRODUCTS = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEDIT = new System.Windows.Forms.Button();
            this.buttonRESTOCK = new System.Windows.Forms.Button();
            this.pictureBoxPROFILE = new System.Windows.Forms.PictureBox();
            this.progressBarVALIDITY = new System.Windows.Forms.ProgressBar();
            this.labelVALIDITY = new System.Windows.Forms.Label();
            this.progressBarQUANTITY = new System.Windows.Forms.ProgressBar();
            this.labelQUANTITY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPNAME = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPRICE = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelNAME);
            this.panel1.Controls.Add(this.buttonAPRODUCT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 75);
            this.panel1.TabIndex = 120;
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(317, 6);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(229, 58);
            this.labelNAME.TabIndex = 117;
            this.labelNAME.Text = "PRODUCTS:";
            // 
            // buttonAPRODUCT
            // 
            this.buttonAPRODUCT.BackColor = System.Drawing.Color.Gold;
            this.buttonAPRODUCT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAPRODUCT.FlatAppearance.BorderSize = 0;
            this.buttonAPRODUCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAPRODUCT.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAPRODUCT.ForeColor = System.Drawing.Color.Black;
            this.buttonAPRODUCT.Location = new System.Drawing.Point(707, 19);
            this.buttonAPRODUCT.Name = "buttonAPRODUCT";
            this.buttonAPRODUCT.Size = new System.Drawing.Size(150, 35);
            this.buttonAPRODUCT.TabIndex = 123;
            this.buttonAPRODUCT.Text = "ADD PRODUCTS";
            this.buttonAPRODUCT.UseVisualStyleBackColor = false;
            this.buttonAPRODUCT.Click += new System.EventHandler(this.buttonAPRODUCT_Click);
            // 
            // listViewPRODUCTS
            // 
            this.listViewPRODUCTS.BackColor = System.Drawing.Color.LightGray;
            this.listViewPRODUCTS.HideSelection = false;
            this.listViewPRODUCTS.LargeImageList = this.imageList1;
            this.listViewPRODUCTS.Location = new System.Drawing.Point(284, 81);
            this.listViewPRODUCTS.Name = "listViewPRODUCTS";
            this.listViewPRODUCTS.Size = new System.Drawing.Size(575, 400);
            this.listViewPRODUCTS.SmallImageList = this.imageList1;
            this.listViewPRODUCTS.TabIndex = 122;
            this.listViewPRODUCTS.UseCompatibleStateImageBehavior = false;
            this.listViewPRODUCTS.SelectedIndexChanged += new System.EventHandler(this.listViewPRODUCTS_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(130, 130);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(-2, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 427);
            this.panel2.TabIndex = 134;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.buttonEDIT);
            this.panel3.Controls.Add(this.buttonRESTOCK);
            this.panel3.Controls.Add(this.pictureBoxPROFILE);
            this.panel3.Controls.Add(this.progressBarVALIDITY);
            this.panel3.Controls.Add(this.labelVALIDITY);
            this.panel3.Controls.Add(this.progressBarQUANTITY);
            this.panel3.Controls.Add(this.labelQUANTITY);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textBoxPNAME);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textBoxPRICE);
            this.panel3.Location = new System.Drawing.Point(3, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 400);
            this.panel3.TabIndex = 122;
            // 
            // buttonEDIT
            // 
            this.buttonEDIT.BackColor = System.Drawing.Color.DimGray;
            this.buttonEDIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEDIT.FlatAppearance.BorderSize = 0;
            this.buttonEDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEDIT.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEDIT.ForeColor = System.Drawing.Color.Gold;
            this.buttonEDIT.Location = new System.Drawing.Point(138, 352);
            this.buttonEDIT.Name = "buttonEDIT";
            this.buttonEDIT.Size = new System.Drawing.Size(125, 35);
            this.buttonEDIT.TabIndex = 155;
            this.buttonEDIT.Text = "EDIT";
            this.buttonEDIT.UseVisualStyleBackColor = false;
            this.buttonEDIT.Click += new System.EventHandler(this.buttonEDIT_Click);
            // 
            // buttonRESTOCK
            // 
            this.buttonRESTOCK.BackColor = System.Drawing.Color.DimGray;
            this.buttonRESTOCK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRESTOCK.FlatAppearance.BorderSize = 0;
            this.buttonRESTOCK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRESTOCK.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRESTOCK.ForeColor = System.Drawing.Color.Gold;
            this.buttonRESTOCK.Location = new System.Drawing.Point(3, 352);
            this.buttonRESTOCK.Name = "buttonRESTOCK";
            this.buttonRESTOCK.Size = new System.Drawing.Size(125, 35);
            this.buttonRESTOCK.TabIndex = 154;
            this.buttonRESTOCK.Text = "RESTOCK";
            this.buttonRESTOCK.UseVisualStyleBackColor = false;
            this.buttonRESTOCK.Click += new System.EventHandler(this.buttonRESTOCK_Click);
            // 
            // pictureBoxPROFILE
            // 
            this.pictureBoxPROFILE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPROFILE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPROFILE.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPROFILE.Image")));
            this.pictureBoxPROFILE.Location = new System.Drawing.Point(13, -1);
            this.pictureBoxPROFILE.Name = "pictureBoxPROFILE";
            this.pictureBoxPROFILE.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxPROFILE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPROFILE.TabIndex = 153;
            this.pictureBoxPROFILE.TabStop = false;
            // 
            // progressBarVALIDITY
            // 
            this.progressBarVALIDITY.Location = new System.Drawing.Point(13, 323);
            this.progressBarVALIDITY.Name = "progressBarVALIDITY";
            this.progressBarVALIDITY.Size = new System.Drawing.Size(250, 23);
            this.progressBarVALIDITY.TabIndex = 152;
            // 
            // labelVALIDITY
            // 
            this.labelVALIDITY.AutoSize = true;
            this.labelVALIDITY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelVALIDITY.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVALIDITY.ForeColor = System.Drawing.Color.White;
            this.labelVALIDITY.Location = new System.Drawing.Point(8, 295);
            this.labelVALIDITY.Name = "labelVALIDITY";
            this.labelVALIDITY.Size = new System.Drawing.Size(86, 25);
            this.labelVALIDITY.TabIndex = 151;
            this.labelVALIDITY.Text = "VALIDITY:";
            // 
            // progressBarQUANTITY
            // 
            this.progressBarQUANTITY.Location = new System.Drawing.Point(13, 269);
            this.progressBarQUANTITY.Name = "progressBarQUANTITY";
            this.progressBarQUANTITY.Size = new System.Drawing.Size(250, 23);
            this.progressBarQUANTITY.TabIndex = 150;
            // 
            // labelQUANTITY
            // 
            this.labelQUANTITY.AutoSize = true;
            this.labelQUANTITY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelQUANTITY.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQUANTITY.ForeColor = System.Drawing.Color.White;
            this.labelQUANTITY.Location = new System.Drawing.Point(8, 241);
            this.labelQUANTITY.Name = "labelQUANTITY";
            this.labelQUANTITY.Size = new System.Drawing.Size(95, 25);
            this.labelQUANTITY.TabIndex = 149;
            this.labelQUANTITY.Text = "QUANTITY:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 148;
            this.label2.Text = "PRODUCT NAME:";
            // 
            // textBoxPNAME
            // 
            this.textBoxPNAME.BackColor = System.Drawing.Color.White;
            this.textBoxPNAME.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPNAME.ForeColor = System.Drawing.Color.Black;
            this.textBoxPNAME.Location = new System.Drawing.Point(13, 155);
            this.textBoxPNAME.Name = "textBoxPNAME";
            this.textBoxPNAME.ReadOnly = true;
            this.textBoxPNAME.Size = new System.Drawing.Size(250, 26);
            this.textBoxPNAME.TabIndex = 147;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 25);
            this.label7.TabIndex = 146;
            this.label7.Text = "PRICE:";
            // 
            // textBoxPRICE
            // 
            this.textBoxPRICE.BackColor = System.Drawing.Color.White;
            this.textBoxPRICE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPRICE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPRICE.ForeColor = System.Drawing.Color.Black;
            this.textBoxPRICE.Location = new System.Drawing.Point(13, 212);
            this.textBoxPRICE.Name = "textBoxPRICE";
            this.textBoxPRICE.ReadOnly = true;
            this.textBoxPRICE.Size = new System.Drawing.Size(250, 26);
            this.textBoxPRICE.TabIndex = 145;
            // 
            // C_PRODUCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewPRODUCTS);
            this.Controls.Add(this.panel2);
            this.Name = "C_PRODUCTS";
            this.Size = new System.Drawing.Size(871, 496);
            this.Load += new System.EventHandler(this.C_PRODUCTS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROFILE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewPRODUCTS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonAPRODUCT;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonRESTOCK;
        private System.Windows.Forms.PictureBox pictureBoxPROFILE;
        private System.Windows.Forms.ProgressBar progressBarVALIDITY;
        private System.Windows.Forms.Label labelVALIDITY;
        private System.Windows.Forms.ProgressBar progressBarQUANTITY;
        private System.Windows.Forms.Label labelQUANTITY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPNAME;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPRICE;
        private System.Windows.Forms.Button buttonEDIT;
    }
}
