using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
namespace OSAPP
{
    public partial class C_PROMO : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }

        public C_PROMO()
        {
            InitializeComponent();
            PopulateImageListPromos();

            PROMONAME.Visible = false;
            labelPROMOVALUE.Visible = false;
            richTextBoxPROMO.Visible = false;
            pictureBoxPROMO.Visible=false;
            labelSTATUS.Visible = false;
            buttonACTIVATE.Visible = false;
        }

        private void buttonABARBER_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add a promo?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                A_PROMO promo = new A_PROMO(AFirstName, ALastName, AProfilePictureData);
                promo.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }
        private void PopulateImageListPromos()
        {
            imageList1.Images.Clear();
            listViewPROMOS.Items.Clear();

            // Hardcoded promos
            imageList1.Images.Add("ANNIVERSARY", Properties.Resources.ANNIVERSARY_IMAGE);
            imageList1.Images.Add("FIRST TIME CUSTOMER", Properties.Resources.FIRST_TIME_CUSTOMER_IMAGE);
            imageList1.Images.Add("BIRTHDAY", Properties.Resources.BIRTHDAY_IMAGE);

            listViewPROMOS.Items.Add("Anniversary Promo", "Anniversary Promo", "ANNIVERSARY"); // Use "ANNIVERSARY" as the image key
            listViewPROMOS.Items.Add("First Time Customer Promo", "First Time Customer Promo", "FIRST TIME CUSTOMER"); // Use "FIRST TIME CUSTOMER" as the image key
            listViewPROMOS.Items.Add("Birthday Promo", "Birthday Promo", "BIRTHDAY"); // Use "BIRTHDAY" as the image key

            // Database promos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PROMONAME, PROMOPICTURE FROM PROMOS";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int imageIndex = 3; // Start index for database promos
                while (reader.Read())
                {
                    string promoName = reader["PROMONAME"].ToString();
                    byte[] promoPictureData = (byte[])reader["PROMOPICTURE"];

                    imageList1.Images.Add(promoName, Image.FromStream(new System.IO.MemoryStream(promoPictureData)));
                    listViewPROMOS.Items.Add(promoName, promoName, imageIndex++); // Use promoName as the image key
                }

                reader.Close();
            }
        }
        private void DisplayHardcodedPromo(string promoName)
        {
            switch (promoName)
            {
                case "Anniversary Promo":
                    pictureBoxPROMO.Image = Properties.Resources.ANNIVERSARY_IMAGE;
                    PROMONAME.Text = "Anniversary Promo";
                    labelPROMOVALUE.Text = "30% DISCOUNT"; 
                    richTextBoxPROMO.Text = "Celebrate your special day with us and enjoy a 30% discount on your Services!";
                    buttonACTIVATE.Visible = false;
                    break;
                case "First Time Customer Promo":
                    pictureBoxPROMO.Image = Properties.Resources.FIRST_TIME_CUSTOMER_IMAGE;
                    PROMONAME.Text = "First Time Customer Promo";
                    labelPROMOVALUE.Text = "10% DISCOUNT"; 
                    richTextBoxPROMO.Text = "Welcome to our Shop! As a first-time customer, you'll get a 10% discount on your first Services.";
                    buttonACTIVATE.Visible = false;
                    break;
                case "Birthday Promo":
                    pictureBoxPROMO.Image = Properties.Resources.BIRTHDAY_IMAGE;
                    PROMONAME.Text = "Birthday Promo";
                    labelPROMOVALUE.Text = "20% DISCOUNT"; 
                    richTextBoxPROMO.Text = "Happy Birthday! Enjoy a 20% discount as our gift to you on your special day.";
                    buttonACTIVATE.Visible = false;
                    break;
                default:
                    buttonACTIVATE.Visible = true;
                    break;
            }
        }
        private void listViewPROMOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPROMOS.SelectedItems.Count > 0)
            {
                string selectedPromo = listViewPROMOS.SelectedItems[0].Text;

                // Check if the selected promo is a hardcoded promo
                if (selectedPromo == "Anniversary Promo" || selectedPromo == "First Time Customer Promo" || selectedPromo == "Birthday Promo")
                {
                    DisplayHardcodedPromo(selectedPromo);
                    buttonACTIVATE.Visible = false;
                }
                else
                {
                    buttonACTIVATE.Visible = true;
                    // Handle database promos
                    string promoName = selectedPromo;
                    byte[] promoPictureData;
                    string promoStatus;

                    // Query database to get promo details including status
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT PROMOVALUE, PROMODESCRIPTION, PROMOPICTURE, STATUS FROM PROMOS WHERE PROMONAME = @PromoName";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@PromoName", promoName);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            labelPROMOVALUE.Text = reader["PROMOVALUE"].ToString(); // Promo value from database
                            richTextBoxPROMO.Text = reader["PROMODESCRIPTION"].ToString(); // Promo description from database
                            promoPictureData = (byte[])reader["PROMOPICTURE"]; // Promo picture data from database
                            promoStatus = reader["STATUS"].ToString(); // Promo status from database

                            pictureBoxPROMO.Image = Image.FromStream(new System.IO.MemoryStream(promoPictureData));
                            PROMONAME.Text = promoName;
                            labelSTATUS.Text = "STATUS: " + promoStatus; // Set labelSTATUS text with format STATUS: [STATUS IN DATABASE]
                        }

                        reader.Close();
                    }
                }

                PROMONAME.Visible = true;
                labelPROMOVALUE.Visible = true;
                richTextBoxPROMO.Visible = true;
                pictureBoxPROMO.Visible = true;
                labelSTATUS.Visible = true;

            }
            else
            {
                PROMONAME.Visible = false;
                labelPROMOVALUE.Visible = false;
                richTextBoxPROMO.Visible = false;
                pictureBoxPROMO.Visible = false;
                labelSTATUS.Visible = false;
                buttonACTIVATE.Visible = false;
            }
        }
        private void buttonACTIVATE_Click(object sender, EventArgs e)
        {
            if (listViewPROMOS.SelectedItems.Count > 0)
            {
                string selectedPromo = listViewPROMOS.SelectedItems[0].Text;

                // Handle database promos
                string promoName = selectedPromo;

                // Query database to get promo details including status
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT STATUS FROM PROMOS WHERE PROMONAME = @PromoName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PromoName", promoName);

                    connection.Open();
                    object statusResult = command.ExecuteScalar();

                    if (statusResult != null && statusResult != DBNull.Value)
                    {
                        string promoStatus = statusResult.ToString();

                        // Toggle the status
                        string newStatus = (promoStatus == "ACTIVE") ? "INACTIVE" : "ACTIVE";

                        // Update the status
                        string updateQuery = "UPDATE PROMOS SET STATUS = @NewStatus WHERE PROMONAME = @PromoName";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@NewStatus", newStatus);
                        updateCommand.Parameters.AddWithValue("@PromoName", promoName);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Promotion {newStatus.ToLower()}d successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            buttonACTIVATE.Text = (newStatus == "ACTIVE") ? "DEACTIVATE" : "ACTIVATE";
                        }
                        else
                        {
                            MessageBox.Show($"Failed to {newStatus.ToLower()} promotion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve promotion status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a promotion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
