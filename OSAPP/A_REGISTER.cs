using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class A_REGISTER : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public A_REGISTER(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private void REGISTER_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
        }

        private void checkBoxSHOWPASS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPASS.UseSystemPasswordChar = !checkBoxSHOWPASS.Checked;
        }

        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxUNAME.Text) &&
                !string.IsNullOrEmpty(textBoxPASS.Text) &&
                !string.IsNullOrEmpty(textBoxRECOVER.Text))
            {
                panel2.Visible = true;

                textBoxUNAME.Enabled = false;
                textBoxPASS.Enabled = false;
                textBoxRECOVER.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonNEXT2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFNAME.Text) &&
                !string.IsNullOrEmpty(textBoxLNAME.Text) &&
                comboBoxROLE.SelectedItem != null) 
            {
                panel3.Visible = true;

                comboBoxROLE.Enabled = false; 
                textBoxFNAME.Enabled = false;
                textBoxLNAME.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    pictureBoxPROFILE.Image = Image.FromFile(selectedImagePath);

                    panel4.Visible = true;
                }
            }
        }
        private void buttonREGISTER_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO USERS (USERNAME, PASSWORD, RECOVER, FIRSTNAME, LASTNAME, ROLE, PROFILEPICTURE) VALUES (@Username, @Password, @Recover, @FirstName, @LastName, @Role, @ProfilePicture)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", textBoxUNAME.Text);
                command.Parameters.AddWithValue("@Password", textBoxPASS.Text);
                command.Parameters.AddWithValue("@Recover", textBoxRECOVER.Text);
                command.Parameters.AddWithValue("@FirstName", textBoxFNAME.Text);
                command.Parameters.AddWithValue("@LastName", textBoxLNAME.Text);
                command.Parameters.AddWithValue("@Role", comboBoxROLE.SelectedItem.ToString()); // Use the selected item from comboBoxROLE
                command.Parameters.AddWithValue("@ProfilePicture", ImageToByteArray(pictureBoxPROFILE.Image));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePictureData);
                        adminForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePictureData);
                adminForm.Show();
                this.Close();
            }
        }

        private void pictureBoxPROFILE_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    pictureBoxPROFILE.Image = Image.FromFile(selectedImagePath);

                    panel4.Visible = true;
                }
            }
        }
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxFNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty after trimming
            if (string.IsNullOrEmpty(input))
            {
                // If it's empty, clear the textbox and return
                textBoxFNAME.Text = "";
                return;
            }

            // Check if the input starts with a letter and allows letters and spaces thereafter
            if (!Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters).");
                textBoxFNAME.Text = ""; // Clear the textbox
            }
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxLNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty after trimming
            if (string.IsNullOrEmpty(input))
            {
                // If it's empty, clear the textbox and return
                textBoxLNAME.Text = "";
                return;
            }

            // Check if the input starts with a letter and allows letters and spaces thereafter
            if (!Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters).");
                textBoxLNAME.Text = ""; // Clear the textbox
            }
        }

        private void textBoxUNAME_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUNAME.Text))
            {
                textBoxUNAME.Clear();
            }
        }

        
    }
}
