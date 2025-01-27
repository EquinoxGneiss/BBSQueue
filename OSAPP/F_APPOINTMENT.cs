using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class F_APPOINTMENT : Form
    {
        private DateTime selectedDateTime;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public F_APPOINTMENT(DateTime selectedDateTime)
        {
            this.selectedDateTime = selectedDateTime;
            InitializeComponent();
            panel4.Visible = false;
            panelPOS2.Visible = false;
            panelPOS3.Visible = false;
            panel3.Visible = false;
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
                    string firstName = reader.GetString(0);
                    string lastName = reader.GetString(1);
                    string barberName = $"{firstName} {lastName}"; 

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
        private void APPOINTMENT_Load(object sender, EventArgs e)
        {
            panelPOS1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelPOS2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelPOS3.BackColor = Color.FromArgb(100, 0, 0, 0);
            MessageBox.Show($"Selected Date and Time: {selectedDateTime.ToString("MMMM dd, yyyy hh:mm tt")}");
        }
        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber(selectedDateTime);
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
            string input = textBoxFNAME.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (!Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxFNAME.Text = "";
            }
            else
            {
                GenerateAndDisplayTicketNumber(selectedDateTime);
            }
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxLNAME.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            if (!Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxLNAME.Text = "";
            }
            else
            {
                GenerateAndDisplayTicketNumber(selectedDateTime); 
            }
        }

        private void comboBoxGENDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber(selectedDateTime);
        }
        private int CalculateAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age))
                age--;
            return age;
        }
        private void dateTimePickerBDAY_ValueChanged(object sender, EventArgs e)
        {
            GenerateAndDisplayTicketNumber(selectedDateTime); 
            DateTime birthday = dateTimePickerBDAY.Value;
            int age = CalculateAge(birthday);

            labelAGE.Text = "Age: " + age.ToString();
        }
        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFNAME.Text) ||
                string.IsNullOrWhiteSpace(textBoxLNAME.Text) ||
                comboBoxGENDER.SelectedIndex == -1 ||
                dateTimePickerBDAY.Value > DateTime.Today.AddYears(-5))
            {
                MessageBox.Show("Please fill in all required fields and ensure age is greater than 5.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panelPOS1.Visible = false;
            panelPOS2.Visible = true;

            panelPOS3.Visible = false;
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
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

        private void button2_Click(object sender, EventArgs e)
        {
            panelPOS3.Visible = true;
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
            string gender = comboBoxGENDER.SelectedItem.ToString();
            byte[] customerPic = ImageToByteArray(pictureBoxPROFILE.Image);
            string barber = listViewBARBERS.SelectedItems.Count > 0 ? listViewBARBERS.SelectedItems[0].Text : "RANDOM";
            string mainServices = GetSelectedServices(listViewSERVICES);
            string addOns = GetSelectedAddOns();
            string services = mainServices + (string.IsNullOrWhiteSpace(addOns) ? "" : ", " + addOns);
            DateTime date = selectedDateTime; // Changed to selectedDateTime
            int age = CalculateAge(dateTimePickerBDAY.Value);
            decimal price = CalculateTotalPrice();
            string status = "APPOINTED";
            byte[] transactionPic = GenerateTransactionPic(labelTICKET.Text.Substring(9));
            string transactionNumber = labelTICKET.Text.Substring(9);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [WALK-IN-CUSTOMER] (FIRSTNAME, LASTNAME, GENDER, CUSTOMERPIC, BARBER, SERVICES, DATE, AGE, PRICE, STATUS, TRANSACTIONPIC, TRANSACTIONNUMBER) VALUES (@FirstName, @LastName, @Gender, @CustomerPic, @Barber, @Services, @Date, @Age, @Price, @Status, @TransactionPic, @TransactionNumber)";
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

                command.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void panel7_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private string GenerateTicketNumber(DateTime selectedDateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE [TRANSACTIONNUMBER] IS NOT NULL AND [DATE] = @SelectedDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SelectedDate", selectedDateTime.Date);

                int count = (int)command.ExecuteScalar();

                string formattedCount = (count + 1).ToString().PadLeft(3, '0');
                string ticketNumber = $"{formattedCount}PRE_SHEARS{selectedDateTime.Date.ToString("MM/dd/yyyy")}";

                return ticketNumber;
            }
        }

        private void GenerateAndDisplayTicketNumber(DateTime selectedDateTime)
        {
            if (!string.IsNullOrWhiteSpace(textBoxFNAME.Text) &&
                !string.IsNullOrWhiteSpace(textBoxLNAME.Text) &&
                comboBoxGENDER.SelectedIndex != -1 &&
                dateTimePickerBDAY.Value <= DateTime.Today.AddYears(-5))
            {
                string ticketNumber = GenerateTicketNumber(selectedDateTime);
                labelTICKET.Text = "TICKET#: " + ticketNumber;
            }
        }
    }
}
