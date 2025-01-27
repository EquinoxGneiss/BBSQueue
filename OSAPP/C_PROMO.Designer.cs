namespace OSAPP
{
    partial class C_PROMO
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonABARBER = new System.Windows.Forms.Button();
            this.labelNAME = new System.Windows.Forms.Label();
            this.listViewPROMOS = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxPROMO = new System.Windows.Forms.PictureBox();
            this.PROMONAME = new System.Windows.Forms.Label();
            this.richTextBoxPROMO = new System.Windows.Forms.RichTextBox();
            this.labelPROMOVALUE = new System.Windows.Forms.Label();
            this.labelSTATUS = new System.Windows.Forms.Label();
            this.buttonACTIVATE = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROMO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonABARBER);
            this.panel1.Controls.Add(this.labelNAME);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 75);
            this.panel1.TabIndex = 136;
            // 
            // buttonABARBER
            // 
            this.buttonABARBER.BackColor = System.Drawing.Color.Green;
            this.buttonABARBER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonABARBER.FlatAppearance.BorderSize = 0;
            this.buttonABARBER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonABARBER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonABARBER.ForeColor = System.Drawing.Color.White;
            this.buttonABARBER.Location = new System.Drawing.Point(782, 17);
            this.buttonABARBER.Name = "buttonABARBER";
            this.buttonABARBER.Size = new System.Drawing.Size(125, 35);
            this.buttonABARBER.TabIndex = 127;
            this.buttonABARBER.Text = "ADD PROMO";
            this.buttonABARBER.UseVisualStyleBackColor = false;
            this.buttonABARBER.Click += new System.EventHandler(this.buttonABARBER_Click);
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(365, 6);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(191, 58);
            this.labelNAME.TabIndex = 126;
            this.labelNAME.Text = "PROMOS:";
            // 
            // listViewPROMOS
            // 
            this.listViewPROMOS.BackColor = System.Drawing.Color.Silver;
            this.listViewPROMOS.ForeColor = System.Drawing.Color.Black;
            this.listViewPROMOS.HideSelection = false;
            this.listViewPROMOS.LargeImageList = this.imageList1;
            this.listViewPROMOS.Location = new System.Drawing.Point(16, 97);
            this.listViewPROMOS.Name = "listViewPROMOS";
            this.listViewPROMOS.Size = new System.Drawing.Size(400, 395);
            this.listViewPROMOS.SmallImageList = this.imageList1;
            this.listViewPROMOS.TabIndex = 137;
            this.listViewPROMOS.UseCompatibleStateImageBehavior = false;
            this.listViewPROMOS.SelectedIndexChanged += new System.EventHandler(this.listViewPROMOS_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(125, 125);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBoxPROMO
            // 
            this.pictureBoxPROMO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPROMO.Location = new System.Drawing.Point(423, 97);
            this.pictureBoxPROMO.Name = "pictureBoxPROMO";
            this.pictureBoxPROMO.Size = new System.Drawing.Size(175, 175);
            this.pictureBoxPROMO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPROMO.TabIndex = 138;
            this.pictureBoxPROMO.TabStop = false;
            // 
            // PROMONAME
            // 
            this.PROMONAME.AutoSize = true;
            this.PROMONAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PROMONAME.ForeColor = System.Drawing.Color.White;
            this.PROMONAME.Location = new System.Drawing.Point(417, 275);
            this.PROMONAME.Name = "PROMONAME";
            this.PROMONAME.Size = new System.Drawing.Size(169, 35);
            this.PROMONAME.TabIndex = 139;
            this.PROMONAME.Text = "PROMO NAME";
            // 
            // richTextBoxPROMO
            // 
            this.richTextBoxPROMO.BackColor = System.Drawing.Color.Silver;
            this.richTextBoxPROMO.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxPROMO.Location = new System.Drawing.Point(423, 348);
            this.richTextBoxPROMO.Name = "richTextBoxPROMO";
            this.richTextBoxPROMO.Size = new System.Drawing.Size(486, 144);
            this.richTextBoxPROMO.TabIndex = 140;
            this.richTextBoxPROMO.Text = "";
            // 
            // labelPROMOVALUE
            // 
            this.labelPROMOVALUE.AutoSize = true;
            this.labelPROMOVALUE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPROMOVALUE.ForeColor = System.Drawing.Color.White;
            this.labelPROMOVALUE.Location = new System.Drawing.Point(417, 310);
            this.labelPROMOVALUE.Name = "labelPROMOVALUE";
            this.labelPROMOVALUE.Size = new System.Drawing.Size(174, 35);
            this.labelPROMOVALUE.TabIndex = 141;
            this.labelPROMOVALUE.Text = "PROMO VALUE";
            // 
            // labelSTATUS
            // 
            this.labelSTATUS.AutoSize = true;
            this.labelSTATUS.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSTATUS.ForeColor = System.Drawing.Color.White;
            this.labelSTATUS.Location = new System.Drawing.Point(604, 237);
            this.labelSTATUS.Name = "labelSTATUS";
            this.labelSTATUS.Size = new System.Drawing.Size(188, 35);
            this.labelSTATUS.TabIndex = 142;
            this.labelSTATUS.Text = "STATUS: ACTIVE";
            // 
            // buttonACTIVATE
            // 
            this.buttonACTIVATE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonACTIVATE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonACTIVATE.FlatAppearance.BorderSize = 0;
            this.buttonACTIVATE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonACTIVATE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonACTIVATE.ForeColor = System.Drawing.Color.White;
            this.buttonACTIVATE.Location = new System.Drawing.Point(784, 307);
            this.buttonACTIVATE.Name = "buttonACTIVATE";
            this.buttonACTIVATE.Size = new System.Drawing.Size(125, 35);
            this.buttonACTIVATE.TabIndex = 143;
            this.buttonACTIVATE.Text = "ACTIVATE";
            this.buttonACTIVATE.UseVisualStyleBackColor = false;
            this.buttonACTIVATE.Click += new System.EventHandler(this.buttonACTIVATE_Click);
            // 
            // C_PROMO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.buttonACTIVATE);
            this.Controls.Add(this.labelSTATUS);
            this.Controls.Add(this.labelPROMOVALUE);
            this.Controls.Add(this.richTextBoxPROMO);
            this.Controls.Add(this.PROMONAME);
            this.Controls.Add(this.pictureBoxPROMO);
            this.Controls.Add(this.listViewPROMOS);
            this.Controls.Add(this.panel1);
            this.Name = "C_PROMO";
            this.Size = new System.Drawing.Size(925, 550);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPROMO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.Button buttonABARBER;
        private System.Windows.Forms.ListView listViewPROMOS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxPROMO;
        private System.Windows.Forms.Label PROMONAME;
        private System.Windows.Forms.RichTextBox richTextBoxPROMO;
        private System.Windows.Forms.Label labelPROMOVALUE;
        private System.Windows.Forms.Label labelSTATUS;
        private System.Windows.Forms.Button buttonACTIVATE;
    }
}
