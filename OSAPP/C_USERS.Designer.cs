namespace OSAPP
{
    partial class C_USERS
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
            this.buttonMANAGER = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNAME = new System.Windows.Forms.Label();
            this.buttonRECEPTIONIST = new System.Windows.Forms.Button();
            this.listViewUSERS = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonAUSER = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonEDITUSER = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMANAGER
            // 
            this.buttonMANAGER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonMANAGER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMANAGER.FlatAppearance.BorderSize = 0;
            this.buttonMANAGER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMANAGER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMANAGER.ForeColor = System.Drawing.Color.Black;
            this.buttonMANAGER.Location = new System.Drawing.Point(17, 92);
            this.buttonMANAGER.Name = "buttonMANAGER";
            this.buttonMANAGER.Size = new System.Drawing.Size(200, 50);
            this.buttonMANAGER.TabIndex = 112;
            this.buttonMANAGER.Text = "MANAGERS";
            this.buttonMANAGER.UseVisualStyleBackColor = false;
            this.buttonMANAGER.Click += new System.EventHandler(this.buttonMANAGER_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelNAME);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 75);
            this.panel1.TabIndex = 113;
            // 
            // labelNAME
            // 
            this.labelNAME.AutoSize = true;
            this.labelNAME.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNAME.ForeColor = System.Drawing.Color.White;
            this.labelNAME.Location = new System.Drawing.Point(359, 8);
            this.labelNAME.Name = "labelNAME";
            this.labelNAME.Size = new System.Drawing.Size(156, 58);
            this.labelNAME.TabIndex = 116;
            this.labelNAME.Text = "USERS:";
            // 
            // buttonRECEPTIONIST
            // 
            this.buttonRECEPTIONIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonRECEPTIONIST.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRECEPTIONIST.FlatAppearance.BorderSize = 0;
            this.buttonRECEPTIONIST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRECEPTIONIST.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRECEPTIONIST.ForeColor = System.Drawing.Color.Black;
            this.buttonRECEPTIONIST.Location = new System.Drawing.Point(17, 159);
            this.buttonRECEPTIONIST.Name = "buttonRECEPTIONIST";
            this.buttonRECEPTIONIST.Size = new System.Drawing.Size(200, 50);
            this.buttonRECEPTIONIST.TabIndex = 114;
            this.buttonRECEPTIONIST.Text = "RECEPTIONIST";
            this.buttonRECEPTIONIST.UseVisualStyleBackColor = false;
            this.buttonRECEPTIONIST.Click += new System.EventHandler(this.buttonRECEPTIONIST_Click);
            // 
            // listViewUSERS
            // 
            this.listViewUSERS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listViewUSERS.HideSelection = false;
            this.listViewUSERS.LargeImageList = this.imageList1;
            this.listViewUSERS.Location = new System.Drawing.Point(243, 18);
            this.listViewUSERS.Name = "listViewUSERS";
            this.listViewUSERS.Size = new System.Drawing.Size(625, 375);
            this.listViewUSERS.SmallImageList = this.imageList1;
            this.listViewUSERS.TabIndex = 115;
            this.listViewUSERS.UseCompatibleStateImageBehavior = false;
            this.listViewUSERS.SelectedIndexChanged += new System.EventHandler(this.listViewUSERS_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(150, 150);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonAUSER
            // 
            this.buttonAUSER.BackColor = System.Drawing.Color.Gold;
            this.buttonAUSER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAUSER.FlatAppearance.BorderSize = 0;
            this.buttonAUSER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAUSER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAUSER.ForeColor = System.Drawing.Color.Black;
            this.buttonAUSER.Location = new System.Drawing.Point(17, 264);
            this.buttonAUSER.Name = "buttonAUSER";
            this.buttonAUSER.Size = new System.Drawing.Size(200, 50);
            this.buttonAUSER.TabIndex = 117;
            this.buttonAUSER.Text = "ADD USERS";
            this.buttonAUSER.UseVisualStyleBackColor = false;
            this.buttonAUSER.Click += new System.EventHandler(this.buttonREGISTER_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-5, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 25);
            this.label1.TabIndex = 118;
            this.label1.Text = "--------------------------";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listViewUSERS);
            this.panel2.Controls.Add(this.buttonEDITUSER);
            this.panel2.Location = new System.Drawing.Point(-2, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 426);
            this.panel2.TabIndex = 119;
            // 
            // buttonEDITUSER
            // 
            this.buttonEDITUSER.BackColor = System.Drawing.Color.Gold;
            this.buttonEDITUSER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEDITUSER.FlatAppearance.BorderSize = 0;
            this.buttonEDITUSER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEDITUSER.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEDITUSER.ForeColor = System.Drawing.Color.Black;
            this.buttonEDITUSER.Location = new System.Drawing.Point(17, 256);
            this.buttonEDITUSER.Name = "buttonEDITUSER";
            this.buttonEDITUSER.Size = new System.Drawing.Size(200, 50);
            this.buttonEDITUSER.TabIndex = 118;
            this.buttonEDITUSER.Text = "EDIT USER";
            this.buttonEDITUSER.UseVisualStyleBackColor = false;
            this.buttonEDITUSER.Click += new System.EventHandler(this.buttonEDITUSER_Click);
            // 
            // C_USERS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.buttonAUSER);
            this.Controls.Add(this.buttonRECEPTIONIST);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonMANAGER);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "C_USERS";
            this.Size = new System.Drawing.Size(871, 496);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonMANAGER;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRECEPTIONIST;
        private System.Windows.Forms.ListView listViewUSERS;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonAUSER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNAME;
        private System.Windows.Forms.Button buttonEDITUSER;
    }
}
