using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace OSAPP
{
    public partial class LOADING : Form
    {
        private int tickCount = 0;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public LOADING()
        {
            InitializeComponent();

            labelLOADING.Visible = false;
            pictureBoxLOADING.Visible = false;

            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            if (tickCount == 15)
            {
                labelLOADING.Visible = true;
                labelLOADING.Text = "                         LOADING..."; //WAG DEDELETE UNG SPACE
                pictureBoxLOADING.Visible = true;
            }

            if (tickCount == 30)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM USERS WHERE ROLE = 'ADMIN'", connection);
                        int adminCount = (int)command.ExecuteScalar();

                        if (adminCount == 0)
                        {
                            labelLOADING.Visible = true;
                            labelLOADING.Text = "ADMIN NOT FOUND, GOING TO REGISTER";
                        }
                        else
                        {
                            labelLOADING.Visible = true;
                            labelLOADING.Text = "          ADMIN FOUND, GOING TO LOGIN";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else if (tickCount == 45)
            {
                if (labelLOADING.Text.Contains("ADMIN NOT FOUND")) 
                {
                    ADMIN_REGISTER registerForm = new ADMIN_REGISTER();
                    registerForm.Show();
                }
                else if (labelLOADING.Text.Contains("ADMIN FOUND")) 
                {
                    LOGIN loginForm = new LOGIN();
                    loginForm.Show();
                }

                this.Hide(); 
            }
        }

        private void LOADING_Load(object sender, EventArgs e)
        {

        }
    }
}
