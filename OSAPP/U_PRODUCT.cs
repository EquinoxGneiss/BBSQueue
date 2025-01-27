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
    public partial class U_PRODUCT : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        private string ProductDisplayName;

        private Image ProductImage;
        private decimal ProductPrice;
        private DateTime ProductValidity;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";

        public U_PRODUCT(string AFirstName, string ALastName, byte[] AProfilePictureData, string productName, Image productImage, decimal productPrice, DateTime productValidity)
        {
            InitializeComponent();
            this.AfirstName = AFirstName;
            this.AlastName = ALastName;
            this.AprofilePictureData = AProfilePictureData;
            this.ProductDisplayName = productName;
            this.ProductImage = productImage;
            this.ProductPrice = productPrice;
            this.ProductValidity = productValidity;
        }

        private void U_PRODUCT_Load(object sender, EventArgs e)
        {

            textBoxPNAME.Text = ProductDisplayName;
            pictureBoxUPLOAD.Image = ProductImage;
            textBoxPRICE.Text = ProductPrice.ToString();
            dateTimePickerEXPIRATION.Text = ProductValidity.ToString();

            panel1.BackColor = Color.FromArgb(100, 100, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
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
        private void pictureBoxUPLOAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxUPLOAD.Image = Image.FromFile(openFileDialog.FileName);

                    panel3.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxUPLOAD.Image = Image.FromFile(openFileDialog.FileName);

                    panel3.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
        private void buttonUPRODUCT_Click(object sender, EventArgs e)
        {

            string newProductName = textBoxPNAME.Text;
            string oldProductName = ProductDisplayName;
            byte[] productImageBytes = ImageToByteArray(pictureBoxUPLOAD.Image);
            decimal productPrice;
            decimal productQuantity;
            decimal restockPrice = 0;
            decimal restockCount = 0;
            DateTime productValidity = dateTimePickerEXPIRATION.Value;

            if (!decimal.TryParse(textBoxQUANTITY.Text, out productQuantity))
            {
                MessageBox.Show("Quantity must be a valid decimal number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productQuantity < 0)
            {
                MessageBox.Show("Quantity cannot be less than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPRICE.Text, out productPrice))
            {
                MessageBox.Show("Price must be a valid decimal number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productPrice <= 0)
            {
                MessageBox.Show("Price must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productQuantity > 0)
            {
                restockPrice = productPrice * productQuantity;
                restockCount = productQuantity;
            }

            if (productValidity < DateTime.Now)
            {
                MessageBox.Show("Validity date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        if (newProductName != oldProductName)
                        {
                            SqlCommand updateNameCommand = new SqlCommand("UPDATE PRODUCTS SET PRODUCTNAME = @newProductName WHERE PRODUCTNAME = @oldProductName", connection, transaction);
                            updateNameCommand.Parameters.AddWithValue("@newProductName", newProductName);
                            updateNameCommand.Parameters.AddWithValue("@oldProductName", oldProductName);
                            updateNameCommand.ExecuteNonQuery();
                        }

                        SqlCommand retrieveCommand = new SqlCommand("SELECT QUANTITY FROM PRODUCTS WHERE PRODUCTNAME = @productName", connection, transaction);
                        retrieveCommand.Parameters.AddWithValue("@productName", newProductName);
                        var existingQuantity = retrieveCommand.ExecuteScalar();
                        decimal existingRestockPrice = 0;

                        // Retrieve existing RESTOCKPRICE separately
                        SqlCommand retrieveRestockPriceCommand = new SqlCommand("SELECT RESTOCKPRICE FROM PRODUCTS WHERE PRODUCTNAME = @productName", connection, transaction);
                        retrieveRestockPriceCommand.Parameters.AddWithValue("@productName", newProductName);
                        var existingRestockPriceObj = retrieveRestockPriceCommand.ExecuteScalar();
                        if (existingRestockPriceObj != null && existingRestockPriceObj != DBNull.Value)
                        {
                            existingRestockPrice = Convert.ToDecimal(existingRestockPriceObj);
                        }

                        decimal newQuantity = (existingQuantity != null && existingQuantity != DBNull.Value) ? Convert.ToDecimal(existingQuantity) + productQuantity : productQuantity;
                        decimal newRestockPrice = existingRestockPrice + restockPrice;

                        SqlCommand command = new SqlCommand("UPDATE PRODUCTS SET PRODUCTIMAGE = @productImage, QUANTITY = @quantity, PRICE = @price, VALIDITY = @validity, RESTOCKPRICE = @restockPrice, RESTOCKCOUNT = @restockCount WHERE PRODUCTNAME = @productName", connection, transaction);
                        command.Parameters.AddWithValue("@productName", newProductName);
                        command.Parameters.AddWithValue("@productImage", productImageBytes);
                        command.Parameters.AddWithValue("@quantity", newQuantity);
                        command.Parameters.AddWithValue("@price", productPrice);
                        command.Parameters.AddWithValue("@validity", productValidity);
                        command.Parameters.AddWithValue("@restockPrice", newRestockPrice);
                        command.Parameters.AddWithValue("@restockCount", restockCount);

                        int rowsAffected = command.ExecuteNonQuery();


                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            D_MANAGER manager = new D_MANAGER(AfirstName, AlastName, AprofilePictureData);
                            manager.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBoxPNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxPNAME.TextChanged -= textBoxPNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxPNAME.Text.Trim(); // Trim to remove leading and trailing spaces

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxPNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxPNAME.Text = ""; // Clear the textbox
            }

            textBoxPNAME.TextChanged += textBoxPNAME_TextChanged; // Resubscribe
        }
    }
}
