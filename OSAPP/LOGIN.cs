using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;


namespace OSAPP
{
    public partial class LOGIN : Form
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        private int tickCount = 0;
        public LOGIN()
        {
            InitializeComponent();
            PictureBox pictureBox3 = c_APPOINTMENT1.Controls.Find("pictureBox3", true).FirstOrDefault() as PictureBox;
            if (pictureBox3 != null)
            {
                pictureBox3.Visible = false;
            }

            pictureBoxLOADING.Visible = false;

            c_APPOINTMENT1.Visible = false;
            panel4.Visible = false;
        }
        private void checkBoxSHOWPASS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPASS.UseSystemPasswordChar = !checkBoxSHOWPASS.Checked;
        }
        private void textBoxPASS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tickCount = 0; 
                timer.Start();
                pictureBoxLOADING.Visible = true;
                buttonLOGIN.Visible = false;
                button1.Visible = false;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tickCount++; 

            if (tickCount == 15)
            {
                timer.Stop(); 
                Login(); 
            }
        }


        private void Login()
        {
            string username = textBoxUNAME.Text;
            string password = textBoxPASS.Text;

            string query = "SELECT COUNT(*), ROLE, FIRSTNAME, LASTNAME, PROFILEPICTURE FROM USERS WHERE USERNAME = @Username AND PASSWORD = @Password GROUP BY ROLE, FIRSTNAME, LASTNAME, PROFILEPICTURE";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int count = reader.GetInt32(0);
                        string role = reader.GetString(1);
                        string AfirstName = reader.GetString(2);
                        string AlastName = reader.GetString(3);

                        byte[] AprofilePicture = reader["PROFILEPICTURE"] as byte[];

                        if (count > 0)
                        {
                            MessageBox.Show("Login successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pictureBoxLOADING.Visible = false;
                            buttonLOGIN.Visible = true;

                            switch (role)
                            {
                                case "ADMIN":
                                    D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePicture);
                                    adminForm.Show();
                                    break;
                                case "MANAGER":
                                    D_MANAGER managerForm = new D_MANAGER(AfirstName, AlastName, AprofilePicture);
                                    managerForm.Show();
                                    break;
                                case "RECEPTIONIST":
                                    D_RECEPTIONIST receptionistForm = new D_RECEPTIONIST(AfirstName, AlastName, AprofilePicture);
                                    receptionistForm.Show();
                                    break;
                                default:
                                    MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }

                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pictureBoxLOADING.Visible = false;
                            buttonLOGIN.Visible = true;
                            button1.Visible = true;
                            textBoxUNAME.Clear();
                            textBoxPASS.Clear();
                            textBoxUNAME.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBoxLOADING.Visible = false;
                        buttonLOGIN.Visible = true;
                        button1.Visible = true;
                        textBoxUNAME.Clear();
                        textBoxPASS.Clear();
                        textBoxUNAME.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LOGIN_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0,0,0); 
            panel3.BackColor = Color.FromArgb(100, 100, 0, 0);
            c_APPOINTMENT1.BackColor = Color.FromArgb(100, 0, 0, 0); 
        }
        private void buttonLOGIN_Click(object sender, EventArgs e)
        {
            tickCount = 0;
            timer.Start();
            pictureBoxLOADING.Visible = true;
            buttonLOGIN.Visible = false;
            button1.Visible = false;
            pictureBoxRATE.Visible = false;
        }
        private void panel3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void labelFPASS_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Recover Password?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FORGOTPASS fORGOTPASS = new FORGOTPASS();
                fORGOTPASS.Show();
                this.Close();
            }
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            c_APPOINTMENT1.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            c_APPOINTMENT1.Visible = true;
            panel3.Visible = false;
            panel4.Visible = true;
            panel1.Visible = false;
        }

        private void textBoxUNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tickCount = 0;
                timer.Start();
                pictureBoxLOADING.Visible = true;
                buttonLOGIN.Visible = false;
                button1.Visible = false;
            }
        }
        private void pictureBoxRATE_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to open the Ratings form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RatingForm ratingsForm = new RatingForm();
                ratingsForm.Show();
                this.Hide();
            }
        }

    }
}
