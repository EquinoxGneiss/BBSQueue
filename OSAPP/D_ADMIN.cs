using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class D_ADMIN : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;

        public D_ADMIN(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();

            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            c_USERS1.Visible = false;
            C_BARBERS.Visible = false;
            c_CUSTOMERS1.Visible = false;
        }

        private void D_ADMIN_Load(object sender, EventArgs e)
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
        private void buttonREGISTER_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to go Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LOGIN loginform = new LOGIN();
                loginform.Show();
                this.Close();
            }
        }

        private void buttonUSERS_Click(object sender, EventArgs e)
        {
            c_USERS1.AFirstName = this.AfirstName;
            c_USERS1.ALastName = this.AlastName;
            c_USERS1.AProfilePictureData = this.AprofilePictureData;

            c_USERS1.Visible = true;
            c_USERS1.BringToFront();

            C_BARBERS.Visible = false;
            c_CUSTOMERS1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            C_BARBERS.AFirstName = this.AfirstName;
            C_BARBERS.ALastName = this.AlastName;
            C_BARBERS.AProfilePictureData = this.AprofilePictureData;

            C_BARBERS.Visible = true;
            C_BARBERS.BringToFront();

            c_USERS1.Visible = false;
            c_CUSTOMERS1.Visible = false;
        }
        private void buttonCUSTOMERS_Click(object sender, EventArgs e)
        {
            c_CUSTOMERS1.Visible = true;
            c_CUSTOMERS1.BringToFront();

            c_USERS1.Visible = false;
            C_BARBERS.Visible = false;
        }
    }
}
