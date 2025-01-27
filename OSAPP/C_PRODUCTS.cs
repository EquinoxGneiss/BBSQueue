using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_PRODUCTS : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }

        public C_PRODUCTS()
        {
            InitializeComponent();
            panel3.Visible = false;

            PopulateProductsListView();
        }
        private void PopulateProductsListView()
        {
            listViewPRODUCTS.Items.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT PRODUCTNAME, PRODUCTIMAGE FROM PRODUCTS", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string productName = reader["PRODUCTNAME"].ToString();
                        byte[] productImageData = (byte[])reader["PRODUCTIMAGE"];

                        Image productImage = Image.FromStream(new System.IO.MemoryStream(productImageData));

                        imageList1.Images.Add(productName, productImage);

                        listViewPRODUCTS.Items.Add(productName, productName); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAPRODUCT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add a product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                A_PRODUCTS product = new A_PRODUCTS(AFirstName, ALastName, AProfilePictureData);
                product.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }
        private void listViewPRODUCTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPRODUCTS.SelectedItems.Count > 0)
            {
                panel3.Visible = true;
                ListViewItem selectedItem = listViewPRODUCTS.SelectedItems[0];

                string productName = selectedItem.Text;
                Image productImage = imageList1.Images[productName];
                textBoxPNAME.Text = productName;
                pictureBoxPROFILE.Image = productImage;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT QUANTITY, PRICE, VALIDITY FROM PRODUCTS WHERE PRODUCTNAME = @productName", connection);
                        command.Parameters.AddWithValue("@productName", productName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            decimal quantity = Convert.ToDecimal(reader["QUANTITY"]); // Change the data type to decimal
                            decimal price = Convert.ToDecimal(reader["PRICE"]);
                            DateTime validityDate = Convert.ToDateTime(reader["VALIDITY"]);

                            int validityDays = (validityDate < DateTime.Now) ? 1 : (int)(validityDate - DateTime.Now).TotalDays;

                            textBoxPRICE.Text = price.ToString();
                            progressBarQUANTITY.Value = Math.Min((int)quantity, 100); // Cast to int for setting ProgressBar value
                            progressBarVALIDITY.Value = Math.Min(validityDays * 5, 100);

                            labelQUANTITY.Text = "Remaining Quantity: " + quantity.ToString();
                            labelVALIDITY.Text = (validityDays < 1) ? "Expired" : "Remaining Validity: " + validityDays + " days";

                            labelQUANTITY.ForeColor = (quantity <= 20) ? Color.Red : Color.White; // Change to white
                            labelVALIDITY.ForeColor = (validityDays <= 30) ? Color.Red : Color.White; // Change to white
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void buttonRESTOCK_Click(object sender, EventArgs e)
        {
            if (listViewPRODUCTS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewPRODUCTS.SelectedItems[0];
                string productName = selectedItem.Text;
                Image productImage = imageList1.Images[productName];
                decimal productPrice = 0; // Declare outside try block
                DateTime productValidity = DateTime.MinValue; // Declare outside try block

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT PRICE, VALIDITY FROM PRODUCTS WHERE PRODUCTNAME = @productName", connection);
                        command.Parameters.AddWithValue("@productName", productName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            productPrice = Convert.ToDecimal(reader["PRICE"]);

                            productValidity = Convert.ToDateTime(reader["VALIDITY"]);
                        }
                    }


                    R_PRODUCT product = new R_PRODUCT(AFirstName, ALastName, AProfilePictureData, productName, productImage, productPrice, productValidity);
                    product.Show();

                    Form parentForm = this.ParentForm;
                    if (parentForm != null)
                    {
                        parentForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to restock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void C_PRODUCTS_Load(object sender, EventArgs e)
        {
            PopulateProductsListView();
        }

        private void buttonEDIT_Click(object sender, EventArgs e)
        {

            if (listViewPRODUCTS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewPRODUCTS.SelectedItems[0];
                string productName = selectedItem.Text;
                Image productImage = imageList1.Images[productName];
                decimal productPrice = 0; // Declare outside try block
                DateTime productValidity = DateTime.MinValue; // Declare outside try block

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT PRICE, VALIDITY FROM PRODUCTS WHERE PRODUCTNAME = @productName", connection);
                        command.Parameters.AddWithValue("@productName", productName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            productPrice = Convert.ToDecimal(reader["PRICE"]);

                            productValidity = Convert.ToDateTime(reader["VALIDITY"]);
                        }
                    }


                    U_PRODUCT product = new U_PRODUCT(AFirstName, ALastName, AProfilePictureData, productName, productImage, productPrice, productValidity);
                    product.Show();

                    Form parentForm = this.ParentForm;
                    if (parentForm != null)
                    {
                        parentForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to restock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
