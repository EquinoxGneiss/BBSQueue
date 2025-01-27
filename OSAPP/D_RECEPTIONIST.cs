using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class D_RECEPTIONIST : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public D_RECEPTIONIST(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            c_WALKIN1.Visible = false;
            c_QUE1.Visible = false;
            c_CASHIER1.Visible = false;
            c_APPOINTMENT1.Visible = false;
        }
        private void D_RECEPTIONIST_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(200, 0, 0, 0);

            labelNAME.Text = $"{AfirstName} {AlastName}";

            if (AprofilePictureData != null && AprofilePictureData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(AprofilePictureData))
                {
                    pictureBoxPROFILE.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxPROFILE.Image = null;
            }
        }
        private void buttonWALKIN_Click(object sender, EventArgs e)
        {
            c_WALKIN1.Visible = true;
            c_WALKIN1.BringToFront();

            c_QUE1.Visible = false;
            c_CASHIER1.Visible = false;
            c_APPOINTMENT1.Visible = false;
        }

        private void buttonQUES_Click(object sender, EventArgs e)
        {
            c_QUE1.Visible = true;
            c_QUE1.BringToFront();

            c_WALKIN1.Visible = false;
            c_CASHIER1.Visible = false;
            c_APPOINTMENT1.Visible = false;
        }

        private void buttonCASHIER_Click(object sender, EventArgs e)
        {
            c_CASHIER1.Visible = true;
            c_CASHIER1.BringToFront();

            c_QUE1.Visible = false;
            c_WALKIN1.Visible = false;
            c_APPOINTMENT1.Visible = false;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to go Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LOGIN loginform = new LOGIN();
                loginform.Show();
                this.Close();
            }
        }

        private void buttonAPPOINTMENT_Click(object sender, EventArgs e)
        {
            c_APPOINTMENT1.AFirstName = this.AfirstName;
            c_APPOINTMENT1.ALastName = this.AlastName;
            c_APPOINTMENT1.AProfilePictureData = this.AprofilePictureData;

            c_APPOINTMENT1.Visible = true;
            c_APPOINTMENT1.BringToFront();

            c_QUE1.Visible = false;
            c_WALKIN1.Visible = false;
            c_CASHIER1.Visible = false;
        }

        private void c_APPOINTMENT1_Load(object sender, EventArgs e)
        {

        }
    }
}
