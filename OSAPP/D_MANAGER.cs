using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class D_MANAGER : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public D_MANAGER(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            c_PRODUCTS.Visible = false;
            c_SERVICES1.Visible = false;
            c_SALES1.Visible = false;
            c_PROMO1.Visible = false;
        }

        private void D_MANAGER_Load(object sender, EventArgs e)
        {
                panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
                panel2.BackColor = Color.FromArgb(200, 0, 0, 0);
                panel5.BackColor = Color.FromArgb(100, 100, 0, 0);

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

        private void buttonPRODUCTS_Click(object sender, EventArgs e)
        {
            c_PRODUCTS.AFirstName = this.AfirstName;
            c_PRODUCTS.ALastName = this.AlastName;
            c_PRODUCTS.AProfilePictureData = this.AprofilePictureData;

            c_PRODUCTS.Visible = true;
            c_PRODUCTS.BringToFront();

            c_SERVICES1.Visible = false;
            c_SALES1.Visible = false;
            c_PROMO1.Visible = false;
        }

        private void buttonSERVICES_Click(object sender, EventArgs e)
        {

            c_SERVICES1.AFirstName = this.AfirstName;
            c_SERVICES1.ALastName = this.AlastName;
            c_SERVICES1.AProfilePictureData = this.AprofilePictureData;

            c_SERVICES1.Visible = true;
            c_SERVICES1.BringToFront();

            c_PRODUCTS.Visible = false;
            c_SALES1.Visible = false;
            c_PROMO1.Visible = false;
        }

        private void buttonREPORTS_Click(object sender, EventArgs e)
        {
            c_SALES1.Visible = true;
            c_SALES1.BringToFront();

            c_PRODUCTS.Visible = false;
            c_SERVICES1.Visible = false;
            c_PROMO1.Visible = false;
        }

        private void pictureBoxPROFILE_Click(object sender, EventArgs e)
        {
            c_PRODUCTS.Visible = false;
            c_SERVICES1.Visible = false;
            c_SALES1.Visible = false;
            c_PROMO1.Visible = false;
        }

        private void buttonPROMOS_Click(object sender, EventArgs e)
        {
            c_PROMO1.AFirstName = this.AfirstName;
            c_PROMO1.ALastName = this.AlastName;
            c_PROMO1.AProfilePictureData = this.AprofilePictureData;

            c_PROMO1.Visible = true;
            c_PROMO1.BringToFront();

            c_PRODUCTS.Visible = false;
            c_SALES1.Visible = false;
            c_SERVICES1.Visible = false;
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
    }
}
