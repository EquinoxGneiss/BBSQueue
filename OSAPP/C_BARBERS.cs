using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_BARBERS : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }
        public C_BARBERS()
        {
            InitializeComponent();
            PopulateListView();
            buttonUPDATEPIC.Enabled = false;
        }

        private void buttonABARBER_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add a barber?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                A_BARBER barber = new A_BARBER(AFirstName, ALastName, AProfilePictureData);
                barber.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }
        private void PopulateListView()
        {
            listViewBARBERS.Items.Clear();

            string query = "SELECT FIRSTNAME, LASTNAME, PROFILEPICTURE FROM BARBERS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string firstName = reader["FIRSTNAME"].ToString();
                        string lastName = reader["LASTNAME"].ToString();
                        byte[] profilePictureData = (byte[])reader["PROFILEPICTURE"];

                        Image profileImage = Image.FromStream(new System.IO.MemoryStream(profilePictureData));

                        listViewBARBERS.LargeImageList = imageList1;
                        int imageIndex = imageList1.Images.Add(profileImage, Color.Transparent);
                        ListViewItem item = new ListViewItem(new string[] { firstName, lastName }, imageIndex);
                        listViewBARBERS.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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

                    buttonUPDATEPIC.Enabled = true;
                }
            }
        }
        private void buttonUPDATEPIC_Click(object sender, EventArgs e)
        {
            if (listViewBARBERS.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a barber from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string firstName = listViewBARBERS.SelectedItems[0].SubItems[0].Text;
            string lastName = listViewBARBERS.SelectedItems[0].SubItems[1].Text;

            Image profileImage = pictureBoxPROFILE.Image;

            byte[] profilePictureData = ImageToByteArray(profileImage);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE BARBERS SET PROFILEPICTURE = @profilePictureData WHERE FIRSTNAME = @firstName AND LASTNAME = @lastName", connection);
                  
                    command.Parameters.AddWithValue("@profilePictureData", profilePictureData);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile picture updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonUPDATEPIC.Enabled = false;
                        RefreshControls();
                        PopulateListView();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. Profile picture might not have been updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void listViewBARBERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBARBERS.SelectedItems.Count == 0)
                return;

            string firstName = listViewBARBERS.SelectedItems[0].SubItems[0].Text;
            string lastName = listViewBARBERS.SelectedItems[0].SubItems[1].Text;

            textBoxFNAME.Text = firstName;
            textBoxLNAME.Text = lastName;

            byte[] profilePictureData = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT PROFILEPICTURE FROM BARBERS WHERE FIRSTNAME = @firstName AND LASTNAME = @lastName", connection);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        profilePictureData = (byte[])reader["PROFILEPICTURE"];
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (profilePictureData != null && profilePictureData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(profilePictureData))
                {
                    pictureBoxPROFILE.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxPROFILE.Image = null;
            }
        }
        private void buttonUPDATE_Click(object sender, EventArgs e)
        {
            // Ensure that a barber is selected
            if (listViewBARBERS.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a barber from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected barber's current first name and last name
            string currentFirstName = listViewBARBERS.SelectedItems[0].SubItems[0].Text;
            string currentLastName = listViewBARBERS.SelectedItems[0].SubItems[1].Text;

            // Get the new first name and last name from the text boxes
            string newFirstName = textBoxFNAME.Text.Trim();
            string newLastName = textBoxLNAME.Text.Trim();

            // Validate the new first name and last name
            if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName))
            {
                MessageBox.Show("Please enter valid first name and last name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if any changes were made
            if (currentFirstName == newFirstName && currentLastName == newLastName)
            {
                MessageBox.Show("No changes were made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update the first name and last name in the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE BARBERS SET FIRSTNAME = @newFirstName, LASTNAME = @newLastName WHERE FIRSTNAME = @currentFirstName AND LASTNAME = @currentLastName", connection);
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@newFirstName", newFirstName);
                    command.Parameters.AddWithValue("@newLastName", newLastName);
                    command.Parameters.AddWithValue("@currentFirstName", currentFirstName);
                    command.Parameters.AddWithValue("@currentLastName", currentLastName);

                    // Execute the command
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("First name and last name updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh the ListView to reflect the updated first name and last name
                        RefreshControls();
                        PopulateListView();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. First name and last name might not have been updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating first name and last name: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshControls()
        {
            // Clear pictureBoxPROFILE
            pictureBoxPROFILE.Image = null;
            // Clear textBoxFNAME and textBoxLNAME
            textBoxFNAME.Text = "";
            textBoxLNAME.Text = "";
        }
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxFNAME.TextChanged -= textBoxFNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxFNAME.Text.Trim();

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxFNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxFNAME.Text = ""; // Clear the textbox
            }

            textBoxFNAME.TextChanged += textBoxFNAME_TextChanged; 
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxLNAME.TextChanged -= textBoxLNAME_TextChanged; 

            string input = textBoxLNAME.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxLNAME.Clear();
            }

            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxLNAME.Text = ""; 
            }

            textBoxLNAME.TextChanged += textBoxLNAME_TextChanged;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            PopulateListView();
        }
    }
}
