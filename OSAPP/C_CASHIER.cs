using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_CASHIER : UserControl
    {
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        private void PopulateActiveDatabasePromos()
        {
            listBoxPROMOS.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PROMONAME FROM PROMOS WHERE STATUS = 'ACTIVE'";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string promoName = reader["PROMONAME"].ToString();
                    listBoxPROMOS.Items.Add(promoName);
                }

                reader.Close();
            }
        }
        public C_CASHIER()
        {
            InitializeComponent();
            PopulateListViewQUES();

            panelINFO.Visible = false;
            panelPAYMENT.Visible = false;
            panel3.Visible = false;

            comboBoxDISCOUNTS.SelectedIndex = comboBoxDISCOUNTS.Items.IndexOf("NONE");
            PopulateActiveDatabasePromos();
            if (DateTime.Today.Month == 5 && DateTime.Today.Day == 12)
            {
                listBoxPROMOS.Items.Add("ANNIVERSARY PROMO");
            }
            
        }
        private void PopulateListViewQUES()
        {
            listViewQUES.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FIRSTNAME, LASTNAME, SERVICES, PRICE, TRANSACTIONPIC, DATE, TRANSACTIONNUMBER FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'PENDING'";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader["FIRSTNAME"].ToString();
                    string lastName = reader["LASTNAME"].ToString();
                    string services = reader["SERVICES"].ToString();
                    decimal price = (decimal)reader["PRICE"];
                    byte[] transactionPicBytes = reader["TRANSACTIONPIC"] as byte[];
                    DateTime date = (DateTime)reader["DATE"];
                    string transactionNumber = reader["TRANSACTIONNUMBER"].ToString();
                    Image transactionPic = ByteArrayToImage(transactionPicBytes);

                    imageList1.Images.Add(firstName + lastName, transactionPic);

                    ListViewItem item = new ListViewItem(new string[] { firstName, lastName, services, price.ToString(), date.ToShortDateString(), transactionNumber });
                    item.ImageKey = firstName + lastName;

                    listViewQUES.Items.Add(item);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            return Image.FromStream(memoryStream);
            }
            private void listViewQUES_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (listViewQUES.SelectedItems.Count > 0)
                {
                    string selectedFirstName = listViewQUES.SelectedItems[0].SubItems[0].Text;
                    string selectedLastName = listViewQUES.SelectedItems[0].SubItems[1].Text;
                    string selectedTransactionNumber = listViewQUES.SelectedItems[0].SubItems[5].Text;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT FIRSTNAME, LASTNAME, BARBER, SERVICES, PRICE, STATUS, AGE, DATE, TRANSACTIONNUMBER, BIRTHDATE FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FirstName", selectedFirstName);
                        command.Parameters.AddWithValue("@LastName", selectedLastName);
                        command.Parameters.AddWithValue("@TransactionNumber", selectedTransactionNumber);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string firstName = reader["FIRSTNAME"].ToString();
                            string lastName = reader["LASTNAME"].ToString();
                            string barber = reader["BARBER"].ToString();
                            string servicesString = reader["SERVICES"].ToString();
                            decimal price = (decimal)reader["PRICE"];
                            string status = reader["STATUS"].ToString();
                            int age = (int)reader["AGE"];
                            DateTime date = (DateTime)reader["DATE"];
                            string transactionNumber = reader["TRANSACTIONNUMBER"].ToString();
                            textBoxFNAME.Text = firstName;
                            textBoxLNAME.Text = lastName;
                            textBoxBARBER.Text = barber;
                            textBoxPRICE.Text = price.ToString();
                            labelSTATUS.Text = "STATUS: " + status;

                            string[] services = servicesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                            listBoxSERVICES.Items.Clear();

                            foreach (string service in services)
                            {
                                listBoxSERVICES.Items.Add(service);
                            }

                            panelINFO.Visible = true;
                            panelPAYMENT.Visible = true;
                            panel3.Visible = true;

                            comboBoxDISCOUNTS.Items.Clear();

                            comboBoxDISCOUNTS.Items.Add("REGULAR");
                            if (age >= 60)
                            {
                                comboBoxDISCOUNTS.Items.Add("SENIOR CITIZEN");
                            }

                            comboBoxDISCOUNTS.Items.Add("PWD");
                            comboBoxDISCOUNTS.Items.Add("STUDENT");

                            comboBoxDISCOUNTS.SelectedIndex = comboBoxDISCOUNTS.Items.IndexOf("REGULAR");

                            textBoxTOTAL.Text = textBoxPRICE.Text;
                            DateTime birthDate = (DateTime)reader["BIRTHDATE"];

                        if (IsNewCustomer(selectedFirstName, selectedLastName))
                        {
                            listBoxPROMOS.Items.Add("FIRST TIME CUSTOMER PROMO");
                        }
                        else
                        {
                            if (birthDate.Month == DateTime.Today.Month && birthDate.Day == DateTime.Today.Day)
                            {
                                listBoxPROMOS.Items.Add("BIRTHDAY PROMO");
                            }
                        }

                    }
                }
                }
                else
                {
                    panelINFO.Visible = false;
                    panelPAYMENT.Visible = false;
                    panel3.Visible = false;
                }
            }
        private void comboBoxDISCOUNTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDISCOUNTS.SelectedIndex != -1)
            {
                string selectedDiscount = comboBoxDISCOUNTS.SelectedItem.ToString();

                if (decimal.TryParse(textBoxPRICE.Text, out decimal totalPrice))
                {
                    decimal discountedPrice = totalPrice;

                    if (selectedDiscount == "SENIOR CITIZEN" || selectedDiscount == "PWD" || selectedDiscount == "STUDENT")
                    {
                        if (selectedDiscount == "SENIOR CITIZEN")
                        {
                            discountedPrice *= 0.68m;
                            labelTAX.Text = "SENIOR ID:";
                            textBoxTAX.ReadOnly = false;
                            textBoxTAX.MaxLength = 4;
                        }
                        else
                        {
                            discountedPrice *= 0.8m;
                            labelTAX.Text = "TAX:";
                            textBoxTAX.ReadOnly = true;
                            textBoxTAX.Clear();
                        }
                    }

                    decimal promoDiscount = 0m;

                    // Apply hardcoded promos
                    foreach (string promo in listBoxPROMOS.Items)
                    {
                        switch (promo)
                        {
                            case "FIRST TIME CUSTOMER PROMO":
                                promoDiscount += 0.1m * totalPrice; // 10% discount for first-time customers
                                break;
                            case "ANNIVERSARY PROMO":
                                promoDiscount += 0.3m * totalPrice; // 30% discount for anniversary promo
                                break;
                            case "BIRTHDAY PROMO":
                                promoDiscount += 0.2m * totalPrice; // 20% discount for birthday promo
                                break;
                            default:
                                break;
                        }
                    }

                    // Apply active database promos
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT PROMOVALUE FROM PROMOS WHERE STATUS = 'ACTIVE'";
                        SqlCommand command = new SqlCommand(query, connection);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            decimal promoValue = Convert.ToDecimal(reader["PROMOVALUE"]);
                            promoDiscount += (promoValue / 100) * totalPrice; // Apply percentage discount
                        }

                        reader.Close();
                    }

                    discountedPrice -= promoDiscount; // Deduct promo discount from total price

                    // Update the UI with the discounted price
                    decimal tax = discountedPrice * 0.12m;
                    textBoxTAX.Text = tax.ToString("0.00");

                    decimal finalTotal = discountedPrice + tax;
                    textBoxTOTAL.Text = finalTotal.ToString("0.00");
                }
            }
            else
            {
                textBoxTOTAL.Text = textBoxPRICE.Text;
            }

            CalculateChange();
        }

        private void textBoxPRICE_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxPRICE.Text, out decimal price))
            {
                decimal tax = price * 0.12m;
                textBoxTAX.Text = tax.ToString("0.00");
            }
        }
        private void textBoxMONEY_TextChanged(object sender, EventArgs e)
        {
            textBoxMONEY.TextChanged -= textBoxMONEY_TextChanged; 

            string input = textBoxMONEY.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxMONEY.Clear();
            }
            else
            {
                if (!Regex.IsMatch(input, @"^[0-9.]*$"))
                {
                    MessageBox.Show("Please enter only numbers and '.' (decimal point).");
                    textBoxMONEY.Clear();
                }
            }

            textBoxMONEY.TextChanged += textBoxMONEY_TextChanged;

            CalculateChange();
        }


        private void CalculateChange()
        {
            if (decimal.TryParse(textBoxMONEY.Text, out decimal money) && decimal.TryParse(textBoxTOTAL.Text, out decimal total))
            {
                decimal change = money - total;
                if (change >= 0)
                {
                    labelCHANGE.Text = change.ToString("0.00");

                }
                else
                {
                    labelCHANGE.Text = "Insufficient Funds";
                }
            }
            else
            {
                labelCHANGE.Text = "CHANGE:";
            }
        }
        private string[] GetSelectedServices()
        {
            List<string> services = new List<string>();
            foreach (var item in listBoxSERVICES.Items)
            {
                services.Add(item.ToString());
            }
            return services.ToArray();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
        private void buttonPAY_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxTAX.Text))
            {
                if (labelCHANGE.Text != "Insufficient Funds")
                {
                    DateTime currentDate = DateTime.Now.Date;

                    if (decimal.TryParse(textBoxTOTAL.Text, out decimal totalPrice))
                    {
                        if (!string.IsNullOrWhiteSpace(textBoxMONEY.Text) && decimal.TryParse(textBoxMONEY.Text, out decimal money))
                        {
                            if (listViewQUES.SelectedItems.Count > 0)
                            {
                                string transactionNumber = listViewQUES.SelectedItems[0].SubItems[5].Text;
                                string firstName = listViewQUES.SelectedItems[0].SubItems[0].Text;
                                string lastName = listViewQUES.SelectedItems[0].SubItems[1].Text;

                                Image receiptImage = ShowReceiptForm(currentDate, transactionNumber, totalPrice);

                                byte[] receiptImageBytes = ImageToByteArray(receiptImage);

                                InsertReceiptImageIntoDatabase(receiptImageBytes, firstName, lastName, transactionNumber);
                                DateTime transactionDate = DateTime.Now;

                                UpdateDatabase(totalPrice, transactionNumber, transactionDate);

                                MessageBox.Show("Payment completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearForm();
                            }
                            else
                            {
                                MessageBox.Show("Please select a customer from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the amount of money.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid total price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Insufficient funds. Please enter the correct amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input Senior ID to proceed with the payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ShowReceiptForm(DateTime date, string transactionNumber, decimal totalPrice)
        {
            Image receiptImage = GenerateReceiptImage(date, textBoxFNAME.Text, textBoxLNAME.Text, textBoxBARBER.Text, transactionNumber, GetSelectedServices(), textBoxPRICE.Text, comboBoxDISCOUNTS.SelectedItem.ToString(), decimal.Parse(textBoxTAX.Text), decimal.Parse(textBoxTOTAL.Text), decimal.Parse(textBoxMONEY.Text), decimal.Parse(labelCHANGE.Text), listBoxPROMOS);

            Form receiptForm = new Form();
            receiptForm.Text = "Receipt";
            receiptForm.Size = new Size(receiptImage.Width, receiptImage.Height);
            receiptForm.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = receiptImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            receiptForm.Controls.Add(pictureBox);

            receiptForm.ShowDialog();

            return receiptImage; 
        }
        private void InsertReceiptImageIntoDatabase(byte[] receiptImageBytes, string firstName, string lastName, string transactionNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE [WALK-IN-CUSTOMER] SET RECEIPTPIC = @ReceiptPic " +
                                     "WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@ReceiptPic", receiptImageBytes);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Database updated successfully
                    }
                    else
                    {
                        MessageBox.Show("Failed to update database with receipt image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating database with receipt image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateDatabase(decimal totalPrice, string transactionNumber, DateTime transactionDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@FirstName", textBoxFNAME.Text);
                checkCommand.Parameters.AddWithValue("@LastName", textBoxLNAME.Text);
                checkCommand.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                try
                {
                    connection.Open();
                    int existingRecordsCount = (int)checkCommand.ExecuteScalar();

                    if (existingRecordsCount == 1)
                    {
                        string updateQuery = "UPDATE [WALK-IN-CUSTOMER] SET PRICE = @Price, STATUS = 'COMPLETED', DATE = @TransactionDate " +
                                             "WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                        SqlCommand command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@Price", totalPrice);
                        command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                        command.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        command.Parameters.AddWithValue("@FirstName", textBoxFNAME.Text);
                        command.Parameters.AddWithValue("@LastName", textBoxLNAME.Text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Database updated successfully
                        }
                        else
                        {
                            MessageBox.Show("Failed to update database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (existingRecordsCount == 0)
                    {
                        MessageBox.Show("No record found with the specified combination of values. Update aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Multiple records found with the specified combination of values. Update aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            textBoxFNAME.Clear();
            textBoxLNAME.Clear();
            textBoxBARBER.Clear();
            textBoxPRICE.Clear();
            textBoxTAX.Clear();
            textBoxTOTAL.Clear();
            textBoxMONEY.Clear();
            labelSTATUS.Text = "";
            labelCHANGE.Text = "";


            PopulateListViewQUES();

            panelINFO.Visible = false;
            panelPAYMENT.Visible = false;
            panel3.Visible = false;

        }
        private Image GenerateReceiptImage(DateTime date, string firstName, string lastName, string barberName, string transactionNumber, string[] services, string price, string discountType, decimal tax, decimal grandTotal, decimal money, decimal change, ListBox listBoxPromos)
        {
            int width = 500;
            int height = 800;
            Bitmap receiptBitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(receiptBitmap))
            {
                graphics.Clear(Color.White);
                Font titleFont = new Font("Bahnschrift SemiCondensed", 16, FontStyle.Bold);
                Font infoFont = new Font("Bahnschrift SemiCondensed", 12);
                Brush brush = Brushes.Black;

                string shopName = "---------- PRECISION SHEARS -----------";
                string motto = "YOUR HAIR, YOUR RULES, OUR EXPERTISE.";

                float shopNameWidth = graphics.MeasureString(shopName, titleFont).Width;
                float shopNameX = (width - shopNameWidth) / 2;
                graphics.DrawString(shopName, titleFont, brush, new PointF(shopNameX, 20));

                float mottoWidth = graphics.MeasureString(motto, infoFont).Width;
                float mottoX = (width - mottoWidth) / 2;
                graphics.DrawString(motto, infoFont, brush, new PointF(mottoX, 40));

                float y = 90;

                DrawHorizontalLine(graphics, width, infoFont, brush, ref y);
                graphics.DrawString("Date:\t\t\t" + date.ToString("yyyy-MM-dd HH:mm"), infoFont, brush, new PointF(20, y += 20));
                graphics.DrawString("Customer Name:\t\t" + firstName + " " + lastName, infoFont, brush, new PointF(20, y += 20));
                graphics.DrawString("Barber:\t\t\t" + barberName, infoFont, brush, new PointF(20, y += 20));
                graphics.DrawString("Transaction ID:\t\t" + transactionNumber, infoFont, brush, new PointF(20, y += 20));
                y += 10;
                DrawHorizontalLine(graphics, width, infoFont, brush, ref y);
                graphics.DrawString("Services:", infoFont, brush, new PointF(20, y += 20));
                DrawHorizontalLine(graphics, width, infoFont, brush, ref y);
                foreach (string service in services)
                {
                    graphics.DrawString("- " + service, infoFont, brush, new PointF(40, y += 20));
                }
                y += 10;
                DrawHorizontalLine(graphics, width, infoFont, brush, ref y);
                decimal subtotal = decimal.Parse(price); // Use the price as the subtotal
                decimal discountValue = subtotal - grandTotal;
                graphics.DrawString("Subtotal:\t\t\t₱ " + subtotal.ToString("0.00"), infoFont, brush, new PointF(20, y += 20));
                foreach (string promo in listBoxPromos.Items)
                {
                    graphics.DrawString("Applied Promo:\t\t" + promo, infoFont, brush, new PointF(20, y += 20));
                }
                graphics.DrawString("Discount type:\t\t" + discountType, infoFont, brush, new PointF(20, y += 20));
                if (discountType != "SENIOR CITIZEN") // Only show tax if not a senior citizen
                {
                    graphics.DrawString("Tax:\t\t\t₱ " + tax.ToString("0.00"), infoFont, brush, new PointF(20, y += 20));
                }
                graphics.DrawString("Grand Total:\t\t₱ " + grandTotal.ToString("0.00"), infoFont, brush, new PointF(20, y += 20));
                graphics.DrawString("Money:\t\t\t₱ " + money.ToString("0.00"), infoFont, brush, new PointF(20, y += 20));
                graphics.DrawString("Change:\t\t\t₱ " + change.ToString("0.00"), infoFont, brush, new PointF(20, y += 20));
                DrawHorizontalLine(graphics, width, infoFont, brush, ref y);
            }

            return receiptBitmap;
        }


        private void DrawHorizontalLine(Graphics graphics, int width, Font infoFont, Brush brush, ref float y)
        {
            graphics.DrawString(new string('-', width), infoFont, brush, new PointF(20, y += 10));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PopulateListViewQUES();
        }
        private bool IsNewCustomer(string firstName, string lastName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count == 1;
            }
        }

        private void listBoxPROMOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
