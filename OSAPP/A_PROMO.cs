using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class A_PROMO : Form

    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdff;Integrated Security=True";
        public A_PROMO(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            panel3.Visible = false;
            panel4.Visible = false;
        }
        private void textBoxDVALUE_TextChanged(object sender, EventArgs e)
        {
            textBoxDVALUE.TextChanged -= textBoxDVALUE_TextChanged;

            string input = textBoxDVALUE.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxDVALUE.Clear();
            }
            else
            {
                if (decimal.TryParse(input, out decimal value) && value >= 0 && value <= 100)
                {
                    // Valid input
                }
                else
                {
                    MessageBox.Show("Please enter a decimal number between 0 and 100.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxDVALUE.Clear();
                }
            }

            textBoxDVALUE.TextChanged += textBoxDVALUE_TextChanged;
        }
        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPNAME.Text) &&
                !string.IsNullOrEmpty(textBoxDVALUE.Text) &&
                !string.IsNullOrEmpty(richTextBoxPROMO.Text)) 
            {
                panel3.Visible = true;

                textBoxPNAME.Enabled = false;
                textBoxDVALUE.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAPROMO_Click(object sender, EventArgs e)
        {
            // Ensure both promotion name, value, and description are provided
            if (!string.IsNullOrEmpty(textBoxPNAME.Text) &&
                !string.IsNullOrEmpty(textBoxDVALUE.Text) &&
                !string.IsNullOrEmpty(richTextBoxPROMO.Text)) // Check if richTextBoxPROMO is filled
            {
                // Get the promotion name, value, description, and image
                string promoName = textBoxPNAME.Text;
                decimal promoValue = decimal.Parse(textBoxDVALUE.Text); // Assuming the value is in decimal format
                string promoDescription = richTextBoxPROMO.Text;

                if (pictureBoxPROFILE.Image != null)
                {
                    // Convert the image to bytes
                    byte[] promoImageBytes = ImageToByteArray(pictureBoxPROFILE.Image);

                    // Insert the data into the database
                    InsertPromotionIntoDatabase(promoName, promoValue, promoDescription, promoImageBytes);

                    // Show a success message
                    MessageBox.Show("Promotion added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the input fields
                    textBoxPNAME.Clear();
                    textBoxDVALUE.Clear();
                    richTextBoxPROMO.Clear();
                    pictureBoxPROFILE.Image = null;
                }
                else
                {
                    MessageBox.Show("Please select an image for the promotion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
        private void InsertPromotionIntoDatabase(string promoName, decimal promoValue, string promoDescription, byte[] promoImageBytes)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO PROMOS (PROMONAME, PROMOVALUE, PROMODESCRIPTION, PROMOPICTURE, STATUS) VALUES (@PromoName, @PromoValue, @PromoDescription, @PromoImage, 'INACTIVE')";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@PromoName", promoName);
                command.Parameters.AddWithValue("@PromoValue", promoValue);
                command.Parameters.AddWithValue("@PromoDescription", promoDescription); // Add parameter for promo description
                command.Parameters.AddWithValue("@PromoImage", promoImageBytes);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Successfully inserted the promotion into the database
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert promotion into the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting promotion into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    panel4.Visible = true;
                }
            }
        }
        private void A_PROMO_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
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
    }
}
