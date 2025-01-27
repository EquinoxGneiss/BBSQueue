using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OSAPP
{
    public partial class E_USER : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        private string username;
        private string firstname;
        private string lastname;
        private string role;
        private byte[] profilepicture;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public E_USER(string AfirstName, string AlastName, byte[] AprofilePictureData, string username, string firstName, string lastName, string role, byte[] profilepicture)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;
            this.username = username;
            this.firstname = firstName;
            this.lastname = lastName;
            this.role = role;
            this.profilepicture = profilepicture;

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
        private void E_USER_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);

            textBoxUSERNAME.Text = username;
            textBoxFNAME.Text = firstname;
            textBoxLNAME.Text = lastname;
            comboBoxROLE.SelectedItem = role;

            if (profilepicture != null)
            {
                using (MemoryStream ms = new MemoryStream(profilepicture))
                {
                    pictureBoxPROFILE.Image = Image.FromStream(ms);
                }
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
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxFNAME.TextChanged -= textBoxFNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxFNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxFNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxFNAME.Text = ""; // Clear the textbox
            }

            textBoxFNAME.TextChanged += textBoxFNAME_TextChanged; // Resubscribe
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxLNAME.TextChanged -= textBoxLNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxLNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxLNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxLNAME.Text = ""; // Clear the textbox
            }

            textBoxLNAME.TextChanged += textBoxLNAME_TextChanged; // Resubscribe
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

                }
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

                }
            }
        }
        private void buttonEDITUSER_Click(object sender, EventArgs e)
        {
            string newUsername = textBoxUSERNAME.Text.Trim();
            string newFirstName = textBoxFNAME.Text.Trim();
            string newLastName = textBoxLNAME.Text.Trim();
            string newRole = comboBoxROLE.SelectedItem?.ToString();
            byte[] newProfilePictureData = ImageToByteArray(pictureBoxPROFILE.Image);

            if (newUsername == username && newFirstName == firstname && newLastName == lastname && newRole == role && CompareByteArrays(newProfilePictureData, profilepicture))
            {
                MessageBox.Show("No changes were made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newFirstName) || string.IsNullOrEmpty(newLastName) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE USERS SET USERNAME = @Username, FIRSTNAME = @FirstName, LASTNAME = @LastName, ROLE = @Role, PROFILEPICTURE = @ProfilePicture WHERE USERNAME = @OldUsername";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", newUsername);
                command.Parameters.AddWithValue("@FirstName", newFirstName);
                command.Parameters.AddWithValue("@LastName", newLastName);
                command.Parameters.AddWithValue("@Role", newRole);
                command.Parameters.AddWithValue("@ProfilePicture", newProfilePictureData);
                command.Parameters.AddWithValue("@OldUsername", username);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePictureData);
                        adminForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1 == null && array2 == null)
                return true;

            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }

        private void textBoxUSERNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxUSERNAME.TextChanged -= textBoxUSERNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxUSERNAME.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxUSERNAME.Clear();
            }

            textBoxUSERNAME.TextChanged += textBoxUSERNAME_TextChanged; // Resubscribe
        }

    }
}
