using System;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OSAPP
{
    public partial class C_SERVICES : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }
        public C_SERVICES()
        {
            InitializeComponent();
            PopulateServicesListView();
            pictureBoxPROFILE.Visible = false;
            buttonUPDATEPIC.Visible = false;
            labelSNAME.Visible = false;
            textBoxSNAME.Visible = false;
            labelSPRICE.Visible = false;
            textBoxSPRICE.Visible = false;
            buttonUPDATE.Visible = false;
        }
        private void PopulateServicesListView()
        {
            listViewSERVICES.Items.Clear();

            string selectedServiceType = radioButtonMAIN.Checked ? "MAIN" : "ADD-ONS";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT SERVICENAME, SERVICEIMAGE FROM SERVICES WHERE SERVICETYPE = @serviceType", connection);
                    command.Parameters.AddWithValue("@serviceType", selectedServiceType);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string serviceName = reader["SERVICENAME"].ToString();
                        byte[] serviceImageData = (byte[])reader["SERVICEIMAGE"];
                        Image serviceImage = Image.FromStream(new MemoryStream(serviceImageData));

                        imageList1.Images.Add(serviceName, serviceImage);
                        listViewSERVICES.Items.Add(serviceName, serviceName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonASERVICES_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to add a service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                A_SERVICES services = new A_SERVICES(AFirstName, ALastName, AProfilePictureData);
                services.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }
        private void listViewSERVICES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSERVICES.SelectedItems.Count > 0)
            {
                pictureBoxPROFILE.Visible = true;
                buttonUPDATEPIC.Visible = true;
                labelSNAME.Visible = true;
                textBoxSNAME.Visible = true;
                labelSPRICE.Visible = true;
                textBoxSPRICE.Visible = true;
                buttonUPDATE.Visible = true;

                string selectedServiceName = listViewSERVICES.SelectedItems[0].Text;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT SERVICENAME, SERVICEIMAGE, PRICE FROM SERVICES WHERE SERVICENAME = @serviceName", connection);
                        command.Parameters.AddWithValue("@serviceName", selectedServiceName);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            byte[] serviceImageData = (byte[])reader["SERVICEIMAGE"];
                            Image serviceImage = Image.FromStream(new MemoryStream(serviceImageData));
                            pictureBoxPROFILE.Image = serviceImage;

                            textBoxSNAME.Text = reader["SERVICENAME"].ToString();
                            textBoxSPRICE.Text = reader["PRICE"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving service details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                pictureBoxPROFILE.Visible = false;
                buttonUPDATEPIC.Visible = false;
                labelSNAME.Visible = false;
                textBoxSNAME.Visible = false;
                labelSPRICE.Visible = false;
                textBoxSPRICE.Visible = false;
                buttonUPDATE.Visible = false;
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

                    try
                    {
                        pictureBoxPROFILE.Image = Image.FromFile(selectedImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void buttonUPDATEPIC_Click(object sender, EventArgs e)
        {
            if (pictureBoxPROFILE.Image != null)
            {
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxPROFILE.Image.Save(ms, pictureBoxPROFILE.Image.RawFormat);
                    imageData = ms.ToArray();
                }

                string selectedServiceName = textBoxSNAME.Text;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("UPDATE SERVICES SET SERVICEIMAGE = @serviceImage WHERE SERVICENAME = @serviceName", connection);
                        command.Parameters.AddWithValue("@serviceImage", imageData);
                        command.Parameters.AddWithValue("@serviceName", selectedServiceName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Image updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            PopulateServicesListView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an image first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonUPDATE_Click(object sender, EventArgs e)
        {
            if (listViewSERVICES.SelectedItems.Count > 0)
            {
                string selectedServiceName = listViewSERVICES.SelectedItems[0].Text;

                string updatedServiceName = textBoxSNAME.Text.Trim();
                string updatedPriceText = textBoxSPRICE.Text.Trim();

                if (string.IsNullOrEmpty(updatedServiceName) || string.IsNullOrEmpty(updatedPriceText))
                {
                    MessageBox.Show("Please provide both service name and price.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!decimal.TryParse(updatedPriceText, out decimal updatedPrice))
                {
                    MessageBox.Show("Invalid price format. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM SERVICES WHERE SERVICENAME = @updatedServiceName AND PRICE = @updatedPrice", connection);
                        checkCommand.Parameters.AddWithValue("@updatedServiceName", updatedServiceName);
                        checkCommand.Parameters.AddWithValue("@updatedPrice", updatedPrice);

                        int duplicateCount = (int)checkCommand.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            MessageBox.Show("No changes detected. The service details remain the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        SqlCommand updateCommand = new SqlCommand("UPDATE SERVICES SET SERVICENAME = @updatedServiceName, PRICE = @updatedPrice WHERE SERVICENAME = @selectedServiceName", connection);
                        updateCommand.Parameters.AddWithValue("@updatedServiceName", updatedServiceName);
                        updateCommand.Parameters.AddWithValue("@updatedPrice", updatedPrice);
                        updateCommand.Parameters.AddWithValue("@selectedServiceName", selectedServiceName);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Service details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            PopulateServicesListView();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update service details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating service details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a service to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radioButtonMAIN_CheckedChanged(object sender, EventArgs e)
        {
            PopulateServicesListView();
        }

        private void radioButtonADDONS_CheckedChanged(object sender, EventArgs e)
        {
            PopulateServicesListView();
        }
        private void textBoxSNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxSNAME.TextChanged -= textBoxSNAME_TextChanged; 

            string input = textBoxSNAME.Text.Trim(); 

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxSNAME.Clear();
            }

            textBoxSNAME.TextChanged += textBoxSNAME_TextChanged;
        }

        private void textBoxSPRICE_TextChanged(object sender, EventArgs e)
        {
            textBoxSPRICE.TextChanged -= textBoxSPRICE_TextChanged; 

            string input = textBoxSPRICE.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxSPRICE.Clear();
            }
            else
            {
                if (!Regex.IsMatch(input, @"^[0-9.]*$"))
                {
                    MessageBox.Show("Please enter only numbers and '.' (decimal point).");
                    textBoxSPRICE.Clear();
                }
            }

            textBoxSPRICE.TextChanged += textBoxSPRICE_TextChanged;

        }

        private void C_SERVICES_Load(object sender, EventArgs e)
        {
            PopulateServicesListView();
        }
    }
}
