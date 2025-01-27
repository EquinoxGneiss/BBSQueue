using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class A_SERVICES : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";

        public A_SERVICES(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                D_MANAGER manager = new D_MANAGER(AfirstName, AlastName, AprofilePictureData);
                manager.Show();
                this.Close();
            }
        }

        private void A_SERVICES_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
        }
        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSNAME.Text) && !string.IsNullOrEmpty(textBoxPRICE.Text) && comboBoxADDONS.SelectedIndex != -1)
            {
                if (decimal.TryParse(textBoxPRICE.Text, out decimal price))
                {
                    panel3.Visible = true;
                    textBoxSNAME.Enabled = false;
                    textBoxPRICE.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxPROFILE_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void UploadImage()
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
        private void buttonASERVICE_Click(object sender, EventArgs e)
        {
            string serviceName = textBoxSNAME.Text.Trim();
            byte[] serviceImage = ImageToByteArray(pictureBoxPROFILE.Image);
            string serviceType = comboBoxADDONS.SelectedItem?.ToString(); // Fetch the selected value from comboBoxADDONS

            if (string.IsNullOrEmpty(serviceType))
            {
                MessageBox.Show("Please select a service type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPRICE.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Price must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO SERVICES (SERVICENAME, SERVICEIMAGE, PRICE, SERVICETYPE) VALUES (@serviceName, @serviceImage, @price, @serviceType)", connection);

                    command.Parameters.AddWithValue("@serviceName", serviceName);
                    command.Parameters.AddWithValue("@serviceImage", serviceImage);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@serviceType", serviceType); // Add parameter for serviceType

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D_MANAGER manager = new D_MANAGER(AfirstName, AlastName, AprofilePictureData);
                        manager.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. Service might not have been added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding service to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBoxPRICE_TextChanged(object sender, EventArgs e)
        {
            textBoxPRICE.TextChanged -= textBoxPRICE_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxPRICE.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxPRICE.Clear();
            }
            else
            {
                // Remove non-numeric characters from the input
                string cleanedInput = Regex.Replace(input, @"[^0-9.]", "");

                // Check if the cleaned input is not empty
                if (!string.IsNullOrEmpty(cleanedInput))
                {
                    // Set the cleaned input to the text box
                    textBoxPRICE.Text = cleanedInput;

                    // Set the cursor position to the end of the text
                    textBoxPRICE.SelectionStart = textBoxPRICE.Text.Length;
                }
            }

            textBoxPRICE.TextChanged += textBoxPRICE_TextChanged; // Resubscribe
        }
        private void textBoxSNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxSNAME.TextChanged -= textBoxSNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxSNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty after trimming
            if (string.IsNullOrEmpty(input))
            {
                // If it's empty, clear the textbox and return
                textBoxSNAME.Clear();
                textBoxSNAME.TextChanged += textBoxSNAME_TextChanged; // Resubscribe
                return;
            }

            // Check if the input starts with a letter and allows letters and spaces thereafter
            if (!Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters).");
                textBoxSNAME.Text = ""; // Clear the textbox
            }

            textBoxSNAME.TextChanged += textBoxSNAME_TextChanged; // Resubscribe
        }

    }
}
