using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class A_PRODUCTS : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public A_PRODUCTS(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            panel3.Visible = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                D_MANAGER manager = new D_MANAGER(AfirstName, AlastName, AprofilePictureData);
                manager.Show();
                this.Close();
            }
        }

        private void A_PRODUCTS_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 100, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
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

                    pictureBoxUPLOAD.Image = Image.FromFile(selectedImagePath);

                    panel3.Visible = true;
                }
            }
        }

        private void pictureBoxUPLOAD_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    pictureBoxUPLOAD.Image = Image.FromFile(selectedImagePath);

                    panel3.Visible = true;
                }
            }
        }
        private void dateTimePickerEXPIRATION_ValueChanged(object sender, EventArgs e)
        {
            UpdateLabelExpiration();
        }

        private void UpdateLabelExpiration()
        {
            DateTime selectedDate = dateTimePickerEXPIRATION.Value;
            TimeSpan validityLeft = selectedDate - DateTime.Now;

            if (validityLeft.TotalDays < 1)
            {
                labelEXPIRATION.Text = "Expired";
                labelEXPIRATION.ForeColor = Color.Red; 
            }
            else
            {
                labelEXPIRATION.Text = "Validity: " + validityLeft.Days + " days";
                labelEXPIRATION.ForeColor = Color.White;
            }
        }
        private void buttonAPRODUCT_Click(object sender, EventArgs e)
        {
            string productName = textBoxPNAME.Text;
            byte[] productImage = ImageToByteArray(pictureBoxUPLOAD.Image);

            if (!decimal.TryParse(textBoxQUANTITY.Text, out decimal quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPRICE.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime expirationDate = dateTimePickerEXPIRATION.Value;

            if (expirationDate < DateTime.Now)
            {
                MessageBox.Show("Expiration date cannot be in the past. Please enter a valid date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO PRODUCTS (PRODUCTNAME, PRODUCTIMAGE, QUANTITY, PRICE, VALIDITY, DEDUCTIONS, RESTOCKCOUNT, RESTOCKPRICE) VALUES (@productName, @productImage, @quantity, @price, @validity, 0, 0, 0)", connection);

                    command.Parameters.AddWithValue("@productName", productName);
                    command.Parameters.AddWithValue("@productImage", productImage);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@validity", expirationDate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D_MANAGER managerForm = new D_MANAGER(AfirstName, AlastName, AprofilePictureData);
                        managerForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No rows were affected. Product might not have been added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product to the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Check if the input contains only numbers and '.' (decimal point)
                if (!Regex.IsMatch(input, @"^[0-9.]+$"))
                {
                    MessageBox.Show("Please enter only numbers and '.' (decimal point).");
                    textBoxPRICE.Text = ""; // Clear the textbox
                }
            }

            textBoxPRICE.TextChanged += textBoxPRICE_TextChanged; // Resubscribe
        }

        private void textBoxQUANTITY_TextChanged(object sender, EventArgs e)
        {
            textBoxQUANTITY.TextChanged -= textBoxQUANTITY_TextChanged; 

            string input = textBoxQUANTITY.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxQUANTITY.Clear();
            }
            else
            {
                if (!Regex.IsMatch(input, @"^[0-9.]+$"))
                {
                    MessageBox.Show("Please enter only numbers and '.' (decimal point).");
                    textBoxQUANTITY.Text = ""; 
                }
            }

            textBoxQUANTITY.TextChanged += textBoxQUANTITY_TextChanged; 
        }
        private void textBoxPNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxPNAME.TextChanged -= textBoxPNAME_TextChanged;

            string input = textBoxPNAME.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxPNAME.Clear();
            }

            // Check if the input starts with a letter and allows letters and spaces thereafter
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed.");
                textBoxPNAME.Text = "";
            }

            textBoxPNAME.TextChanged += textBoxPNAME_TextChanged;
        }


    }
}
