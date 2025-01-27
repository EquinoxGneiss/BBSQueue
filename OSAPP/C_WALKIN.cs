using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace OSAPP
{
    public partial class C_WALKIN : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public C_WALKIN()
        {
            InitializeComponent();
            panel4.Visible = false;
            panelPOS2.Visible = false;
            panelPOS3.Visible = false;
            panel3.Visible = false;
            panelPOS7.Visible = false;

            PopulateAddOnsListView();
            PopulateServicesListView();
            PopulateBarbersListView();
        }
        private void PopulateAddOnsListView()
        {
            listViewADDONS.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SERVICENAME, SERVICEIMAGE FROM SERVICES WHERE SERVICETYPE = 'ADD-ONS'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string serviceName = reader.GetString(0);
                    byte[] imageData = (byte[])reader["SERVICEIMAGE"];

                    Image serviceImage = ByteArrayToImage(imageData);

                    ListViewItem item = new ListViewItem(serviceName);
                    item.ImageKey = serviceName;
                    listViewADDONS.LargeImageList.Images.Add(serviceName, serviceImage);
                    listViewADDONS.Items.Add(item);
                }
            }
        }
        private void PopulateBarbersListView()
        {
            listViewBARBERS.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FIRSTNAME, LASTNAME, PROFILEPICTURE FROM BARBERS";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string barberName = reader.GetString(0) + " " + reader.GetString(1);
                    byte[] imageData = (byte[])reader["PROFILEPICTURE"];

                    Image barberImage = ByteArrayToImage(imageData);

                    ListViewItem item = new ListViewItem(barberName);
                    item.ImageKey = barberName;
                    imageList1.Images.Add(barberName, barberImage);
                    listViewBARBERS.LargeImageList = imageList1;
                    listViewBARBERS.Items.Add(item);
                }
            }
        }

        private void PopulateServicesListView()
        {
            listViewSERVICES.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SERVICENAME, SERVICEIMAGE FROM SERVICES WHERE SERVICETYPE = 'MAIN'"; 
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string serviceName = reader.GetString(0);
                    byte[] imageData = (byte[])reader["SERVICEIMAGE"];

                    Image serviceImage = ByteArrayToImage(imageData);

                    ListViewItem item = new ListViewItem(serviceName);
                    item.ImageKey = serviceName;
                    listViewSERVICES.LargeImageList.Images.Add(serviceName, serviceImage);
                    listViewSERVICES.Items.Add(item);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber();
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
                        panel4.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxFNAME.TextChanged -= textBoxFNAME_TextChanged;

            string input = textBoxFNAME.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxFNAME.Clear();
            }
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters).");
                textBoxFNAME.Text = "";
            }
            else
            {
                GenerateAndDisplayTicketNumber();
            }

            textBoxFNAME.TextChanged += textBoxFNAME_TextChanged;
        }
        private void GenerateAndDisplayTicketNumber()
        {
            if (!string.IsNullOrWhiteSpace(textBoxFNAME.Text) &&
                !string.IsNullOrWhiteSpace(textBoxLNAME.Text) &&
                comboBoxGENDER.SelectedIndex != -1 &&
                dateTimePickerBDAY.Value <= DateTime.Today.AddYears(-5))
            {
                string ticketNumber = GenerateTicketNumber();
                labelTICKET.Text = "TICKET#: " + ticketNumber;
            }
        }

        private string GenerateTicketNumber()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE [TRANSACTIONNUMBER] IS NOT NULL AND CAST([DATE] AS DATE) = CAST(GETDATE() AS DATE)";
                SqlCommand command = new SqlCommand(query, connection);

                int count = (int)command.ExecuteScalar();

                string formattedCount = (count + 1).ToString().PadLeft(3, '0');
                string ticketNumber = $"{formattedCount}PRE_SHEARS{DateTime.Today.ToString("MM/dd/yyyy")}";

                return ticketNumber;
            }
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxLNAME.TextChanged -= textBoxLNAME_TextChanged;

            string input = textBoxLNAME.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxLNAME.Clear();
            }

            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters).");
                textBoxLNAME.Text = "";
            }
            else
            {
                GenerateAndDisplayTicketNumber();
            }

            textBoxLNAME.TextChanged += textBoxLNAME_TextChanged; 
        }


        private void comboBoxGENDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber();
            
        }
        private void dateTimePickerBDAY_ValueChanged(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber();
            DateTime birthday = dateTimePickerBDAY.Value;
            int age = CalculateAge(birthday);

            labelAGE.Text = "Age: " + age.ToString();
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
                age--;
            return age;
        }
        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFNAME.Text) || string.IsNullOrWhiteSpace(textBoxLNAME.Text))
            {
                MessageBox.Show("Please fill in both FIRSTNAME and LASTNAME fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsDuplicateRecord(textBoxFNAME.Text.Trim(), textBoxLNAME.Text.Trim()))
            {
                MessageBox.Show("A record with the same FIRSTNAME and LASTNAME already exists in the queue.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] customerPic = ImageToByteArray(pictureBoxPROFILE.Image);
            string transactionNumber = labelTICKET.Text.Substring(9);

            InsertNewCustomerRecord(textBoxFNAME.Text, textBoxLNAME.Text, comboBoxGENDER.SelectedItem.ToString(), customerPic, "", "", dateTimePickerBDAY.Value, 0, "ON QUE", transactionNumber);

            MessageBox.Show("Customer added to the queue.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            panelPOS1.Visible = false;
            panelPOS2.Visible = true;
            panelPOS3.Visible = false;
        }

        private bool IsDuplicateRecord(string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND STATUS = 'ON QUE'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void buttonNEXT2_Click(object sender, EventArgs e)
        {
            if (listViewSERVICES.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a service.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panel3.Visible = true;
            panelPOS3.Visible = false;

        }
        private void buttonQUE_Click(object sender, EventArgs e)
        {
            if (listViewSERVICES.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one service.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string firstName = textBoxFNAME.Text.Trim();
            string lastName = textBoxLNAME.Text.Trim();
            string gender = comboBoxGENDER.SelectedItem != null ? comboBoxGENDER.SelectedItem.ToString() : "";
            string mainServices = GetSelectedServices(listViewSERVICES);
            string addOns = GetSelectedAddOns();
            string services = mainServices + (string.IsNullOrWhiteSpace(addOns) ? "" : ", " + addOns);
            DateTime birthDate = dateTimePickerBDAY.Value;
            decimal price = CalculateTotalPrice();
            string status = "ON QUE";
            string transactionNumber = labelTICKET.Text.Substring(9);

            string selectedBarber = listViewBARBERS.SelectedItems.Count > 0 ? listViewBARBERS.SelectedItems[0].Text : "";

            string barber = GetBarberWithLeastCustomers(selectedBarber);

            if (string.IsNullOrEmpty(barber))
            {
                barber = GetBarberWithLeastCustomers("");
            }

            byte[] customerPic = null;

            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && comboBoxGENDER.SelectedIndex != -1 && dateTimePickerBDAY.Value <= DateTime.Today.AddYears(-5))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CUSTOMERPIC FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND GENDER = @Gender AND BIRTHDATE = @BirthDate";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        customerPic = (byte[])result;
                    }
                }
            }

            bool recordExists = CheckRecordExists(firstName, lastName, transactionNumber);

            if (recordExists)
            {
                UpdateCustomerRecord(firstName, lastName, gender, barber, services, birthDate, price, transactionNumber);
                MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                InsertNewCustomerRecord(firstName, lastName, gender, customerPic, barber, services, birthDate, price, status, transactionNumber);
                MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ClearInputFields();
        }

        private bool CheckRecordExists(string firstName, string lastName, string transactionNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
        private void UpdateCustomerRecord(string firstName, string lastName, string gender, string selectedBarber, string services, DateTime birthDate, decimal price, string transactionNumber)
        {
            // If no barber is selected, get the barber with the least customers
            string barber = selectedBarber;
            if (string.IsNullOrEmpty(barber))
            {
                barber = GetBarberWithLeastCustomers(null); // Pass null to indicate no selected barber
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE [WALK-IN-CUSTOMER] SET GENDER = @Gender, BARBER = @Barber, SERVICES = @Services, DATE = @Date, AGE = @Age, PRICE = @Price, BIRTHDATE = @BirthDate WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Barber", barber);
                command.Parameters.AddWithValue("@Services", services);
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                command.Parameters.AddWithValue("@Age", CalculateAge(birthDate));
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@BirthDate", birthDate);
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                command.ExecuteNonQuery();
            }
        }

        private void InsertNewCustomerRecord(string firstName, string lastName, string gender, byte[] customerPic, string barber, string services, DateTime birthDate, decimal price, string status, string transactionNumber)
        {
            if (string.IsNullOrEmpty(barber))
            {
                barber = GetBarberWithLeastCustomers(null); 
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [WALK-IN-CUSTOMER] (FIRSTNAME, LASTNAME, GENDER, CUSTOMERPIC, BARBER, SERVICES, DATE, AGE, PRICE, STATUS, TRANSACTIONPIC, TRANSACTIONNUMBER, BIRTHDATE) VALUES (@FirstName, @LastName, @Gender, @CustomerPic, @Barber, @Services, @Date, @Age, @Price, @Status, @TransactionPic, @TransactionNumber, @BirthDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@CustomerPic", customerPic);
                command.Parameters.AddWithValue("@Barber", barber);
                command.Parameters.AddWithValue("@Services", services);
                command.Parameters.AddWithValue("@Date", DateTime.Now);
                command.Parameters.AddWithValue("@Age", CalculateAge(birthDate));
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@TransactionPic", GenerateTransactionPic(transactionNumber));
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                command.Parameters.AddWithValue("@BirthDate", birthDate);

                command.ExecuteNonQuery();
            }
        }


        private string GetBarberWithLeastCustomers(string selectedBarber)
        {
            if (!string.IsNullOrEmpty(selectedBarber))
            {
                return selectedBarber;
            }

            string barber = "";

            string query = "SELECT TOP 1 BARBER FROM [WALK-IN-CUSTOMER] WHERE STATUS IN ('ON QUE', 'ON PROCESS') GROUP BY BARBER ORDER BY COUNT(*) ASC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    barber = reader["BARBER"].ToString();
                }
                else
                {
                    query = "SELECT TOP 1 FIRSTNAME, LASTNAME FROM BARBERS";
                    command = new SqlCommand(query, connection);
                    reader.Close();
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        barber = reader["FIRSTNAME"].ToString() + " " + reader["LASTNAME"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No barber found", "Debugging", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return barber;
        }

        private string GetSelectedServices(ListView listView)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return "";
            }

            string selectedServices = "";
            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (!string.IsNullOrEmpty(selectedServices))
                {
                    selectedServices += ", ";
                }
                selectedServices += item.Text;
            }

            return selectedServices;
        }

        private string GetSelectedAddOns()
        {
            if (listViewADDONS.CheckedItems.Count == 0)
            {
                return "";
            }

            string selectedAddOns = "";
            foreach (ListViewItem item in listViewADDONS.CheckedItems)
            {
                if (!string.IsNullOrEmpty(selectedAddOns))
                {
                    selectedAddOns += ", ";
                }
                selectedAddOns += item.Text;
            }

            return selectedAddOns;
        }

        public class TicketImageViewForm : Form
        {
            private PictureBox pictureBox;

            public TicketImageViewForm(Image ticketImage)
            {
                this.pictureBox = new PictureBox();
                this.pictureBox.Image = ticketImage;
                this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(this.pictureBox);
                this.Text = "Generated Ticket";
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (ListViewItem item in listViewSERVICES.SelectedItems)
            {
                string serviceName = item.Text;
                decimal servicePrice = GetServicePrice(serviceName);
                totalPrice += servicePrice;
            }

            foreach (ListViewItem item in listViewADDONS.Items)
            {
                if (item.Checked)
                {
                    string addonName = item.Text;
                    decimal addonPrice = GetServicePrice(addonName);
                    totalPrice += addonPrice;
                }
            }

            return totalPrice;
        }

        private decimal GetServicePrice(string serviceName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PRICE FROM SERVICES WHERE SERVICENAME = @ServiceName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceName", serviceName);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
                else
                {
                    return 0;
                }
            }
        }

        private byte[] GenerateTransactionPic(string ticketNumber)
        {
            Bitmap bitmap = new Bitmap(250, 100);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                graphics.DrawString(ticketNumber, new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
            }

            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void ClearInputFields()
        {
            textBoxFNAME.Clear();
            textBoxLNAME.Clear();
            comboBoxGENDER.SelectedIndex = -1;
            pictureBoxPROFILE.Image = null;
            listViewBARBERS.SelectedItems.Clear();
            listViewSERVICES.SelectedItems.Clear();
            labelTICKET.Text = "";
            panelPOS2.Visible = false;
            panelPOS3.Visible = false;
            panel3.Visible = false;
            panelPOS1.Visible = true;
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error converting image to byte array: " + ex.Message);
                    return null;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panelPOS3.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblClick_Click(object sender, EventArgs e)
        {
            panelPOS1.Visible = true;
            panelPOS7.Visible = true;
            panelPOS3.Visible = false;
            panelPOS2.Visible = false;
            picLogo.Visible = false;
        }
        private void AddCustomerToQueueWithUsualServiceAndBarber(string firstName, string lastName, string gender, byte[] customerPic, string services, string selectedBarber, DateTime birthDate, decimal price)
        {
            DateTime date = DateTime.Now;
            int age = CalculateAge(birthDate);
            string status = "ON QUE";
            byte[] transactionPic = GenerateTransactionPic(labelTICKET.Text.Substring(9));
            string transactionNumber = labelTICKET.Text.Substring(9);

            // If no barber is selected, get the barber with the least customers
            string barber = selectedBarber;
            if (string.IsNullOrEmpty(barber))
            {
                barber = GetBarberWithLeastCustomers(null); // Pass null to indicate no selected barber
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [WALK-IN-CUSTOMER] (FIRSTNAME, LASTNAME, GENDER, CUSTOMERPIC, BARBER, SERVICES, DATE, AGE, PRICE, STATUS, TRANSACTIONPIC, TRANSACTIONNUMBER, BIRTHDATE) VALUES (@FirstName, @LastName, @Gender, @CustomerPic, @Barber, @Services, @Date, @Age, @Price, @Status, @TransactionPic, @TransactionNumber, @BirthDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@CustomerPic", customerPic);
                command.Parameters.AddWithValue("@Barber", barber);
                command.Parameters.AddWithValue("@Services", services);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@TransactionPic", transactionPic);
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                command.Parameters.AddWithValue("@BirthDate", birthDate);

                command.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonSEARCH_Click_1(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFName.Text.Trim();
                string lastName = txtLName.Text.Trim();
                string formattedBirthday = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FIRSTNAME, LASTNAME, GENDER, BIRTHDATE, CUSTOMERPIC, SERVICES, BARBER, PRICE, STATUS FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND BIRTHDATE = @Birthdate";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Birthdate", formattedBirthday);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string existingStatus = reader["STATUS"].ToString();
                        if (existingStatus == "ON QUE")
                        {
                            MessageBox.Show("A record with the same FIRSTNAME and LASTNAME is already in the queue.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        textBoxFNAME.Text = reader["FIRSTNAME"].ToString();
                        textBoxLNAME.Text = reader["LASTNAME"].ToString();
                        comboBoxGENDER.SelectedItem = reader["GENDER"].ToString();
                        dateTimePickerBDAY.Value = Convert.ToDateTime(reader["BIRTHDATE"]);

                        byte[] imageData = reader["CUSTOMERPIC"] as byte[];
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBoxPROFILE.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBoxPROFILE.Image = null;
                        }

                        DialogResult result = MessageBox.Show("Would you like your usual service and barber?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string services = reader["SERVICES"].ToString();
                            string barber = reader["BARBER"].ToString();
                            decimal price = Convert.ToDecimal(reader["PRICE"]);

                            AddCustomerToQueueWithUsualServiceAndBarber(firstName, lastName, comboBoxGENDER.SelectedItem.ToString(), imageData, services, barber, dateTimePickerBDAY.Value, price);

                            MessageBox.Show("Customer added to the queue with their usual service and barber.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == DialogResult.No)
                        {
                            AddCustomerToQueueWithUsualServiceAndBarber(firstName, lastName, comboBoxGENDER.SelectedItem.ToString(), imageData, "", "", dateTimePickerBDAY.Value, 0);

                            MessageBox.Show("Customer added to the queue without their usual service and barber.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            panelPOS1.Visible = false;
                            panelPOS2.Visible = true;
                            buttonNEXT.Visible = true;
                            MessageBox.Show("Please select your services and barber.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        MessageBox.Show("Record found!", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ClearInputFields();
                        buttonNEXT.Visible = false;
                        MessageBox.Show("No record found for the specified criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
