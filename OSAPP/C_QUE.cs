using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_QUE : UserControl
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";

        public C_QUE()
        {
            InitializeComponent();

            PopulateBarbersListView();
            PopulateCustomerListView("ALL");
            PopulateCheckedListBoxProducts();

            panelINFO.Visible = false;
            panelOPTIONS.Visible = false;

            buttonSTART.Enabled = false;
            buttonDONE.Enabled = false;
        }
        private void PopulateCustomerListView(string selectedBarber)
        {
            listViewQUES.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query;
                if (selectedBarber == "ALL")
                {
                    query = "SELECT FIRSTNAME, LASTNAME, BARBER, SERVICES, PRICE, STATUS, TRANSACTIONPIC, DATE, TRANSACTIONNUMBER FROM [WALK-IN-CUSTOMER] WHERE (STATUS != 'COMPLETED' AND STATUS != 'PENDING') OR (STATUS = 'APPOINTED' AND (CONVERT(DATE, DATE) <= CONVERT(DATE, GETDATE())))";
                }
                else
                {
                    query = "SELECT FIRSTNAME, LASTNAME, BARBER, SERVICES, PRICE, STATUS, TRANSACTIONPIC, DATE, TRANSACTIONNUMBER FROM [WALK-IN-CUSTOMER] WHERE (BARBER = @Barber AND STATUS != 'COMPLETED' AND STATUS != 'PENDING') OR (BARBER = @Barber AND STATUS = 'APPOINTED' AND (CONVERT(DATE, DATE) <= CONVERT(DATE, GETDATE())))";
                }

                SqlCommand command = new SqlCommand(query, connection);
                if (selectedBarber != "ALL")
                {
                    command.Parameters.AddWithValue("@Barber", selectedBarber);
                }

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["FIRSTNAME"].ToString();
                    string lastName = reader["LASTNAME"].ToString();
                    string barber = reader["BARBER"].ToString();
                    string services = reader["SERVICES"].ToString();
                    decimal price = (decimal)reader["PRICE"];
                    string status = reader["STATUS"].ToString();
                    byte[] transactionPicBytes = reader["TRANSACTIONPIC"] as byte[];
                    DateTime ticketDate = (DateTime)reader["DATE"];
                    string transactionNumber = reader["TRANSACTIONNUMBER"].ToString();

                    if (status == "APPOINTED" && ticketDate.Date > DateTime.Today)
                    {
                        continue;
                    }

                    Image transactionPic = ByteArrayToImage(transactionPicBytes);

                    imageList2.Images.Add(firstName + lastName, transactionPic);

                    ListViewItem item = new ListViewItem(new string[] { firstName, lastName, barber, services, price.ToString(), status, transactionNumber });
                    item.ImageKey = firstName + lastName;

                    listViewQUES.Items.Add(item);
                }
            }
        }

        private void PopulateBarbersListView()
        {
            listViewBARBERS.Items.Clear(); 

            Image allImage = Properties.Resources.AllImage; 
            if (!imageList1.Images.ContainsKey("allImageKey"))
            {
                imageList1.Images.Add("allImageKey", allImage);
            }
            ListViewItem allItem = new ListViewItem("ALL");
            allItem.ImageKey = "allImageKey";
            listViewBARBERS.Items.Add(allItem);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FIRSTNAME, LASTNAME, PROFILEPICTURE FROM BARBERS";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["FIRSTNAME"].ToString();
                    string lastName = reader["LASTNAME"].ToString();
                    byte[] profilePictureBytes = (byte[])reader["PROFILEPICTURE"]; 

                    Image profilePicture = ByteArrayToImage(profilePictureBytes);

                    ListViewItem item = new ListViewItem(new string[] { firstName, lastName });
                    item.ImageKey = firstName + lastName; 

                    if (!imageList1.Images.ContainsKey(item.ImageKey))
                    {
                        imageList1.Images.Add(item.ImageKey, profilePicture);
                    }

                    item.ImageKey = item.ImageKey;

                    listViewBARBERS.Items.Add(item);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            return Image.FromStream(memoryStream);
        }
        private void listViewBARBERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBARBERS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewBARBERS.SelectedItems[0];

                string selectedBarber;

                if (selectedItem.Text == "ALL")
                {
                    selectedBarber = "ALL";
                }
                else
                {
                    selectedBarber = selectedItem.SubItems[0].Text + " " + selectedItem.SubItems[1].Text;
                }


                if (selectedBarber == "ALL")
                {
                    labelQUE.Text = "GENERAL QUE:";
                    listViewQUES.Enabled = true;
                }
                else
                {
                    labelQUE.Text = selectedBarber + " QUES:";
                    listViewQUES.Enabled = false;
                }

                PopulateCustomerListView(selectedBarber); 
            }
        }

        private void listViewQUES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewQUES.SelectedItems.Count > 0)
            {
                string selectedFirstName = listViewQUES.SelectedItems[0].SubItems[0].Text;
                string selectedLastName = listViewQUES.SelectedItems[0].SubItems[1].Text;
                string selectedBarber = listViewQUES.SelectedItems[0].SubItems[2].Text;
                string status = listViewQUES.SelectedItems[0].SubItems[5].Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT FIRSTNAME, LASTNAME, SERVICES, PRICE, STATUS FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND BARBER = @Barber AND STATUS = @Status"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", selectedFirstName);
                    command.Parameters.AddWithValue("@LastName", selectedLastName);
                    command.Parameters.AddWithValue("@Barber", selectedBarber);
                    command.Parameters.AddWithValue("@Status", status);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string firstName = reader["FIRSTNAME"].ToString();
                        string lastName = reader["LASTNAME"].ToString();
                        string servicesString = reader["SERVICES"].ToString();
                        decimal price = (decimal)reader["PRICE"];
                        status = reader["STATUS"].ToString();

                        textBoxFNAME.Text = firstName;
                        textBoxLNAME.Text = lastName;
                        textBoxPRICE.Text = price.ToString();
                        labelSTATUS.Text = "STATUS: " + status;

                        string[] services = servicesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                        listBoxSERVICES.Items.Clear();

                        foreach (string service in services)
                        {
                            listBoxSERVICES.Items.Add(service);
                        }

                        panelINFO.Visible = true;
                        panelOPTIONS.Visible = true;


                        buttonSTART.Enabled = (selectedBarber != "RANDOM" && (status == "APPOINTED" || status == "ON QUE"));

                        buttonDONE.Enabled = (status == "ON PROCESS");
                    }
                }
            }
            else
            {
                panelINFO.Visible = false;
                panelOPTIONS.Visible = false;

                buttonSTART.Enabled = false;
                buttonDONE.Enabled = false;
            }
        }
        private void buttonSTART_Click(object sender, EventArgs e)
        {
            if (listViewQUES.SelectedItems.Count > 0)
            {
                string status = listViewQUES.SelectedItems[0].SubItems[5].Text;

                if (status == "APPOINTED" || status == "ON QUE")
                {
                    string selectedFirstName = listViewQUES.SelectedItems[0].SubItems[0].Text;
                    string selectedLastName = listViewQUES.SelectedItems[0].SubItems[1].Text;
                    string selectedBarber = listViewQUES.SelectedItems[0].SubItems[2].Text;
                    string selectedTransactionNumber = listViewQUES.SelectedItems[0].SubItems[6].Text;

                    if (!IsCustomerInProgress(selectedFirstName, selectedLastName, selectedBarber, selectedTransactionNumber))
                    {
                        if (!IsBarberBusy(selectedBarber))
                        {
                            checkedListBoxPRODUCTS.Enabled = true;

                            if (checkedListBoxPRODUCTS.CheckedItems.Count > 0)
                            {
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    using (SqlTransaction transaction = connection.BeginTransaction())
                                    {
                                        try
                                        {
                                            string query = "UPDATE [WALK-IN-CUSTOMER] SET STATUS = 'ON PROCESS' WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND BARBER = @Barber AND TRANSACTIONNUMBER = @TransactionNumber";
                                            SqlCommand command = new SqlCommand(query, connection, transaction);
                                            command.Parameters.AddWithValue("@FirstName", selectedFirstName);
                                            command.Parameters.AddWithValue("@LastName", selectedLastName);
                                            command.Parameters.AddWithValue("@Barber", selectedBarber);
                                            command.Parameters.AddWithValue("@TransactionNumber", selectedTransactionNumber);
                                            command.ExecuteNonQuery();

                                            transaction.Commit();

                                            PopulateCustomerListView("ALL");

                                            buttonSTART.Enabled = false;
                                            buttonDONE.Enabled = true;

                                            MessageBox.Show("Customer started processing successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        {
                                            transaction.Rollback();
                                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select at least one product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                checkedListBoxPRODUCTS.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The selected barber is currently busy. Please wait.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("This customer is already in progress.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This appointment cannot be started.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool IsBarberBusy(string selectedBarber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE BARBER = @Barber AND STATUS = 'ON PROCESS'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Barber", selectedBarber);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private bool IsCustomerInProgress(string firstName, string lastName, string barber, string transactionNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND BARBER = @Barber AND TRANSACTIONNUMBER = @TransactionNumber AND STATUS = 'ON PROCESS'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Barber", barber);
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        private void buttonDONE_Click(object sender, EventArgs e)
        {
            if (listViewQUES.SelectedItems.Count > 0)
            {
                string selectedFirstName = listViewQUES.SelectedItems[0].SubItems[0].Text;
                string selectedLastName = listViewQUES.SelectedItems[0].SubItems[1].Text;
                string transactionNumber = listViewQUES.SelectedItems[0].SubItems[6].Text;

               // MessageBox.Show($"Selected: First Name: {selectedFirstName}, Last Name: {selectedLastName}, Transaction Number: {transactionNumber}");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = "UPDATE [WALK-IN-CUSTOMER] SET STATUS = 'PENDING' WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber AND STATUS = 'ON PROCESS'";
                            SqlCommand command = new SqlCommand(query, connection, transaction);
                            command.Parameters.AddWithValue("@FirstName", selectedFirstName);
                            command.Parameters.AddWithValue("@LastName", selectedLastName);
                            command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                foreach (string selectedProduct in checkedListBoxPRODUCTS.CheckedItems)
                                {
                                    Random random = new Random();
                                    decimal subtractionValue = (decimal)(random.NextDouble() * (0.5 - 0.1) + 0.1);

                                    string updateQuery = "UPDATE PRODUCTS SET QUANTITY = QUANTITY - @SubtractionValue, DEDUCTIONS = ISNULL(DEDUCTIONS, 0) + @SubtractionValue WHERE PRODUCTNAME = @ProductName";
                                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                                    updateCommand.Parameters.AddWithValue("@SubtractionValue", subtractionValue);
                                    updateCommand.Parameters.AddWithValue("@ProductName", selectedProduct);
                                    updateCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();

                                textBoxFNAME.Text = "";
                                textBoxLNAME.Text = "";
                                listBoxSERVICES.Items.Clear();
                                textBoxPRICE.Text = "";
                                checkedListBoxPRODUCTS.Items.Clear();

                                PopulateCheckedListBoxProducts();

                                string selectedBarber = listViewQUES.SelectedItems[0].SubItems[2].Text;
                                PopulateCustomerListView("ALL");

                                buttonSTART.Enabled = false;
                                buttonDONE.Enabled = false;

                                MessageBox.Show("Customer status changed to PENDING successfully. Quantities updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No customer with the specified name, transaction number, and status 'ON PROCESS' found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void PopulateCheckedListBoxProducts()
        {
            checkedListBoxPRODUCTS.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PRODUCTNAME, QUANTITY, VALIDITY FROM PRODUCTS WHERE QUANTITY > 0 AND VALIDITY > GETDATE()";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productName = reader["PRODUCTNAME"].ToString();
                    checkedListBoxPRODUCTS.Items.Add(productName);
                }
            }
        }

        private void C_QUE_Load(object sender, EventArgs e)
        {
            PopulateBarbersListView();
        }
    }
}
