using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;


namespace OSAPP
{
    public partial class C_SALES : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public C_SALES()
        {
            InitializeComponent();

            labelSELECTED.Visible = false;
            chartSALES.Visible = false;
            panel3.Visible = false;
            pictureBoxRECEIPT.Visible = false;
            buttonPRINT.Visible = false;
            buttonPRINT2.Visible = false;

            panelINVENTORYDATA.Visible = false;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            // Set DataGridView properties for better appearance
            dataGridViewPRODUCTS.BorderStyle = BorderStyle.None;
            dataGridViewPRODUCTS.BackgroundColor = Color.Black; // Set background color to black
            dataGridViewPRODUCTS.DefaultCellStyle.BackColor = Color.Black; // Set default cell background color to black
            dataGridViewPRODUCTS.DefaultCellStyle.ForeColor = Color.White; // Set default cell text color to white
            dataGridViewPRODUCTS.DefaultCellStyle.Font = new Font(dataGridViewPRODUCTS.DefaultCellStyle.Font, FontStyle.Bold); // Set default cell font to bold
            dataGridViewPRODUCTS.DefaultCellStyle.SelectionBackColor = Color.SandyBrown; // Light red
            dataGridViewPRODUCTS.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewPRODUCTS.RowHeadersVisible = false;

            // Set column headers style
            dataGridViewPRODUCTS.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 192); // Dark blue
            dataGridViewPRODUCTS.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPRODUCTS.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            dataGridViewPRODUCTS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center header text vertically

            // Set column auto size mode to fill available space equally
            dataGridViewPRODUCTS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set row height
            dataGridViewPRODUCTS.RowTemplate.Height = 30;

            // Set alternate row style
            dataGridViewPRODUCTS.AlternatingRowsDefaultCellStyle.BackColor = Color.Black; // Set alternate row background color to black
            dataGridViewPRODUCTS.AlternatingRowsDefaultCellStyle.ForeColor = Color.White; // Set alternate row text color to white
        }
        private void panelSALES_Click(object sender, EventArgs e)
        {
            activePanel = ActivePanel.Sales;
            chartSALES.Visible = true;
            labelSELECTED.Visible = true;
            panel3.Visible = false;
            labelSELECTED.Text = "SALES REPORT";
            chartSALES.Series.Clear();
            chartSALES.Titles.Clear();
            panelINVENTORYDATA.Visible = false;
            buttonPRINT2.Visible = false;

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Name = "Sales";

            string query = "SELECT DATE, PRICE FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'COMPLETED'";

            DateTime startDate = dateTimePickerBEFORE.Value;
            DateTime endDate = dateTimePickerAFTER.Value;

            query += $" AND DATE >= '{startDate.ToString("yyyy-MM-dd")}' AND DATE <= '{endDate.ToString("yyyy-MM-dd")}'";

            Dictionary<DateTime, decimal> salesData = new Dictionary<DateTime, decimal>();
            decimal totalSales = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(0);
                    decimal price = reader.GetDecimal(1);

                    if (salesData.ContainsKey(date))
                        salesData[date] += price;
                    else
                        salesData[date] = price;

                    totalSales += price;
                }

                reader.Close();
            } 

            foreach (var sale in salesData)
            {
                series.Points.AddXY(sale.Key, sale.Value);
            }

            chartSALES.Series.Add(series);
            chartSALES.Titles.Add("Sales Chart");
            labelTOTALSALES.Text = "Total Sales: P" + totalSales.ToString();
            buttonPRINT.Visible = true;
        }
        private void PopulateBarbersListView()
        {
            listViewBARBERS.Items.Clear();

            Image allImage = Properties.Resources.AllImage;
            if (!imageList2.Images.ContainsKey("allImageKey"))
            {
                imageList2.Images.Add("allImageKey", allImage);
            }
            ListViewItem allItem = new ListViewItem("ALL");
            allItem.ImageKey = "allImageKey";
            listViewBARBERS.Items.Add(allItem);
            listViewTRANSACTIONS.Visible = false;

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

                    Image profilePicture = ImageFromByteArray(profilePictureBytes);

                    ListViewItem item = new ListViewItem(new string[] { firstName, lastName });
                    item.ImageKey = firstName + lastName;

                    if (!imageList2.Images.ContainsKey(item.ImageKey))
                    {
                        imageList2.Images.Add(item.ImageKey, profilePicture);
                    }

                    item.ImageKey = item.ImageKey;

                    listViewBARBERS.Items.Add(item);
                }
            }
        }

        private Image ImageFromByteArray(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        private void PopulateTransactionsListView(DateTime startDate, DateTime endDate)
        {
            listViewTRANSACTIONS.Items.Clear();

            startDate = startDate.Date;

            endDate = endDate.Date.AddDays(1);

            string query = $"SELECT FIRSTNAME, LASTNAME, TRANSACTIONPIC, TRANSACTIONNUMBER FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'COMPLETED' AND DATE >= @StartDate AND DATE < @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string firstName = reader.GetString(reader.GetOrdinal("FIRSTNAME"));
                    string lastName = reader.GetString(reader.GetOrdinal("LASTNAME"));
                    string transactionNumber = reader.GetString(reader.GetOrdinal("TRANSACTIONNUMBER"));
                    byte[] transactionPicBytes = reader["TRANSACTIONPIC"] as byte[];

                    Image transactionImage = byteArrayToImage(transactionPicBytes);

                    string customerName = $"{firstName} {lastName} - {transactionNumber}";

                    if (transactionImage != null)
                    {
                        imageList1.Images.Add(transactionImage);
                        int imageIndex = imageList1.Images.Count - 1;
                        listViewTRANSACTIONS.LargeImageList = imageList1;
                        listViewTRANSACTIONS.Items.Add(new ListViewItem(customerName, imageIndex));
                    }
                    else
                    {
                        listViewTRANSACTIONS.Items.Add(new ListViewItem(customerName, -1));
                    }
                }

                reader.Close();
            }

            int totalOrders = 0;
            string countQuery = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'COMPLETED' AND DATE >= @StartDate AND DATE < @EndDate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(countQuery, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                connection.Open();
                totalOrders = (int)command.ExecuteScalar();
            }

            labelTOTALORDERS.Text = "Total Orders: " + totalOrders.ToString();
        }

        private void panelORDERS_Click(object sender, EventArgs e)
        {
            activePanel = ActivePanel.Orders;
            chartSALES.Visible = false;
            labelSELECTED.Text = "ORDER REPORTS";
            panel3.Visible = true;
            panelINVENTORYDATA.Visible = false;
            PopulateBarbersListView();
            buttonPRINT.Visible = false;

            listViewTRANSACTIONS.Visible = false;
        }
        private void listViewBARBERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBARBERS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewBARBERS.SelectedItems[0];

                if (selectedItem.Text == "ALL")
                {

                    listViewTRANSACTIONS.Visible = true;
                    listViewTRANSACTIONS.Items.Clear();
                    PopulateTransactionsListView(dateTimePickerBEFORE.Value, dateTimePickerAFTER.Value);
                    return; 
                }

                string firstName = selectedItem.SubItems[0].Text;
                string lastName = selectedItem.SubItems[1].Text;
                string barberFullName = $"{firstName} {lastName}";


                listViewTRANSACTIONS.Visible = true;
                listViewTRANSACTIONS.Items.Clear();
                DateTime startDate = dateTimePickerBEFORE.Value;
                DateTime endDate = dateTimePickerAFTER.Value;

                PopulateTransactionsListViewByBarber(barberFullName, startDate, endDate);
            }
        }private void PopulateTransactionsListViewByBarber(string barberName, DateTime startDate, DateTime endDate)
{
    listViewTRANSACTIONS.Items.Clear();

    // Adjust the start date to include the entire day
    startDate = startDate.Date;

    string query = $"SELECT FIRSTNAME, LASTNAME, TRANSACTIONPIC, TRANSACTIONNUMBER FROM [WALK-IN-CUSTOMER] WHERE BARBER = @BarberName AND STATUS = 'COMPLETED' AND DATE >= @StartDate AND DATE < DATEADD(day, 1, @EndDate)";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@BarberName", barberName);
        command.Parameters.AddWithValue("@StartDate", startDate);
        command.Parameters.AddWithValue("@EndDate", endDate.Date);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string firstName = reader.GetString(reader.GetOrdinal("FIRSTNAME"));
            string lastName = reader.GetString(reader.GetOrdinal("LASTNAME"));
            string transactionNumber = reader.GetString(reader.GetOrdinal("TRANSACTIONNUMBER"));
            byte[] transactionPicBytes = reader["TRANSACTIONPIC"] as byte[];
            Image transactionImage = byteArrayToImage(transactionPicBytes);
            string customerName = $"{firstName} {lastName} - {transactionNumber}";

            if (transactionImage != null)
            {
                imageList1.Images.Add(transactionImage);
                int imageIndex = imageList1.Images.Count - 1;
                listViewTRANSACTIONS.LargeImageList = imageList1;
                listViewTRANSACTIONS.Items.Add(new ListViewItem(customerName, imageIndex));
            }
            else
            {
                listViewTRANSACTIONS.Items.Add(new ListViewItem(customerName, -1));
            }
        }

        reader.Close();
    }

    int totalOrders = 0;
    string countQuery = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE BARBER = @BarberName AND STATUS = 'COMPLETED' AND DATE >= @StartDate AND DATE < DATEADD(day, 1, @EndDate)";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(countQuery, connection);
        command.Parameters.AddWithValue("@BarberName", barberName);
        command.Parameters.AddWithValue("@StartDate", startDate);
        command.Parameters.AddWithValue("@EndDate", endDate.Date); // Ensure endDate is only the date part
        connection.Open();
        totalOrders = (int)command.ExecuteScalar();
    }

    labelTOTALORDERS.Text = "Total Orders: " + totalOrders.ToString();
}

        private enum ActivePanel
        {
            Sales,
            Orders,
            Inventory
        }
        private ActivePanel activePanel = ActivePanel.Sales;
        private void dateTimePickerBEFORE_ValueChanged(object sender, EventArgs e)
        {
            if (activePanel == ActivePanel.Sales)
            {
                panelSALES_Click(sender, e);
            }
            else if (activePanel == ActivePanel.Orders)
            {
                panelORDERS_Click(sender, e);
            }
        }

        private void dateTimePickerAFTER_ValueChanged(object sender, EventArgs e)
        {
            if (activePanel == ActivePanel.Sales)
            {
                panelSALES_Click(sender, e);
            }
            else if (activePanel == ActivePanel.Orders)
            {
                panelORDERS_Click(sender, e);
            }
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        private void listViewTRANSACTIONS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTRANSACTIONS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewTRANSACTIONS.SelectedItems[0];

                string customerName = selectedItem.Text;
                byte[] receiptPicBytes = null;

                string[] nameParts = customerName.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                string fullName = nameParts[0];
                string transactionNumber = nameParts[1];

                string[] fullNameParts = fullName.Split(' ');
                string firstName = fullNameParts[0];
                string lastName = fullNameParts.Length > 1 ? fullNameParts[1] : "";


                string query = "SELECT RECEIPTPIC FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);

                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            receiptPicBytes = (byte[])result;

                            Image receiptImage = byteArrayToImage(receiptPicBytes);
                            if (receiptImage != null)
                            {
                                pictureBoxRECEIPT.Image = receiptImage;
                                pictureBoxRECEIPT.Visible = true;
                            }
                            else
                            {
                                pictureBoxRECEIPT.Visible = false;
                            }
                        }
                        else
                        {
                            pictureBoxRECEIPT.Visible = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions (e.g., database connection error)
                    MessageBox.Show("Error retrieving receipt image: " + ex.Message);
                }
            }
        }

        private void pictureBoxRECEIPT_Click(object sender, EventArgs e)
        {
            if (pictureBoxRECEIPT.Image != null)
            {
                Form receiptImageForm = new Form();
                receiptImageForm.Text = "Receipt Image";

                PictureBox pbReceiptImage = new PictureBox();
                pbReceiptImage.Dock = DockStyle.Fill;
                pbReceiptImage.SizeMode = PictureBoxSizeMode.Zoom;
                pbReceiptImage.Image = pictureBoxRECEIPT.Image;

                receiptImageForm.Controls.Add(pbReceiptImage);

                receiptImageForm.ClientSize = pictureBoxRECEIPT.Image.Size;

                receiptImageForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No receipt image available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonPRINT_Click(object sender, EventArgs e)
        {
            Bitmap receiptBitmap = GenerateReceiptBitmap();

            ShowReceiptImage(receiptBitmap);
        }
        private void ShowReceiptImage(Bitmap receiptBitmap)
        {
            Form receiptImageForm = new Form();
            receiptImageForm.Text = "Receipt Image";
            receiptImageForm.WindowState = FormWindowState.Maximized; 

            PictureBox pbReceiptImage = new PictureBox();
            pbReceiptImage.Dock = DockStyle.Fill;
            pbReceiptImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbReceiptImage.Image = receiptBitmap;

            receiptImageForm.Controls.Add(pbReceiptImage);

            receiptImageForm.ShowDialog();
        }

        private Bitmap GenerateReceiptBitmap()
        {
            int width = 500;
            int height = 1000;

            Bitmap receiptBitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(receiptBitmap))
            {
                graphics.Clear(Color.White); 
                Font titleFont = new Font("Bahnschrift SemiCondensed", 20, FontStyle.Bold);
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

                string datePrinted = $"Date Printed: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";
                float datePrintedWidth = graphics.MeasureString(datePrinted, infoFont).Width;
                float datePrintedX = (width - datePrintedWidth) / 2;
                graphics.DrawString(datePrinted, infoFont, brush, new PointF(datePrintedX, 60));

                string query = $"SELECT DATE, SERVICES, PRICE FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'COMPLETED' AND DATE <= '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'";

                List<string[]> salesData = new List<string[]>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string date = reader.GetDateTime(0).ToString("yyyy-MM-dd");
                        string services = reader.GetString(1);
                        decimal price = reader.GetDecimal(2);

                        salesData.Add(new string[] { date, services, price.ToString() });
                    }

                    reader.Close();
                }

                int y = 90;

                string title = "Sales Report";
                graphics.DrawString(title, titleFont, brush, new PointF((width - graphics.MeasureString(title, titleFont).Width) / 2, y));
                y += (int)titleFont.GetHeight() + 10;

                float priceColumnWidth = salesData.Max(item => graphics.MeasureString(item[2], infoFont).Width); // Maximum width needed for the price column


                foreach (var data in salesData)
                {
                    string date = data[0];
                    string services = data[1];
                    string price = data[2];

                    float priceX = width - priceColumnWidth - 20;
                    graphics.DrawString(price, infoFont, brush, new PointF(priceX, y));

                    float dateX = 20;
                    float servicesX = dateX + 150;
                    graphics.DrawString(date, infoFont, brush, new PointF(dateX, y));
                    graphics.DrawString(services, infoFont, brush, new PointF(servicesX, y));

                    y += (int)infoFont.GetHeight();
                }

                y += 20;
                graphics.DrawString("Comparison Data:", titleFont, brush, new PointF(20, y));
                y += (int)titleFont.GetHeight() + 10;

                decimal totalSalesPreviousMonth = 0;
                decimal totalSalesThisMonth = 0;
                decimal totalSalesPreviousWeek = 0;
                decimal totalSalesThisWeek = 0;
                decimal totalSalesPreviousDay = 0;
                decimal totalSalesToday = 0;

                foreach (var data in salesData)
                {
                    DateTime saleDate = DateTime.Parse(data[0]);
                    decimal salePrice = decimal.Parse(data[2]);

                    if (saleDate.Month == DateTime.Now.Month - 1)
                        totalSalesPreviousMonth += salePrice;
                    else if (saleDate.Month == DateTime.Now.Month)
                        totalSalesThisMonth += salePrice;

                    if (saleDate >= DateTime.Now.AddDays(-7))
                        totalSalesThisWeek += salePrice;
                    if (saleDate >= DateTime.Now.AddDays(-14) && saleDate < DateTime.Now.AddDays(-7))
                        totalSalesPreviousWeek += salePrice;

                    if (saleDate.Date == DateTime.Now.Date.AddDays(-1))
                        totalSalesPreviousDay += salePrice;
                    if (saleDate.Date == DateTime.Now.Date)
                        totalSalesToday += salePrice;
                }
                graphics.DrawString("Month", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"Last Month: {totalSalesPreviousMonth}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"This Month: {totalSalesThisMonth}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight() + 10;

                graphics.DrawString("Week", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"Last Week: {totalSalesPreviousWeek}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"This Week: {totalSalesThisWeek}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight() + 10;

                graphics.DrawString("Day", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"Yesterday: {totalSalesPreviousDay}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight();
                graphics.DrawString($"Today: {totalSalesToday}", infoFont, brush, new PointF(40, y));
                y += (int)infoFont.GetHeight() + 10;

                y += 20;
                graphics.DrawString("Key Data:", titleFont, brush, new PointF(20, y));
                y += (int)titleFont.GetHeight() + 10;

                string mostPopularService = "";
                int maxServiceCount = 0;
                Dictionary<string, int> serviceCounts = new Dictionary<string, int>();

                foreach (var data in salesData)
                {
                    string[] services = data[1].Split(',');
                    foreach (string service in services)
                    {
                        if (!serviceCounts.ContainsKey(service))
                            serviceCounts[service] = 0;
                        serviceCounts[service]++;
                        if (serviceCounts[service] > maxServiceCount)
                        {
                            maxServiceCount = serviceCounts[service];
                            mostPopularService = service;
                        }
                    }
                }

                graphics.DrawString($"Most Popular Service: {mostPopularService}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();
                decimal totalSales = 0;
                foreach (var data in salesData)
                {
                    totalSales += decimal.Parse(data[2]);
                }
                graphics.DrawString($"Total Sales: ₱ {totalSales.ToString("0.00")}", infoFont, brush, new PointF(20, y));
                y += (int)titleFont.GetHeight() + 10;

                graphics.DrawString("End Of Report", titleFont, brush, new PointF(20, y));
            }

            return receiptBitmap;
        }
        private void panelINVENTORY_Click(object sender, EventArgs e)
        {
            activePanel = ActivePanel.Inventory;
            chartSALES.Visible = false;
            labelSELECTED.Text = "INVENTORY REPORT";
            pictureBoxRECEIPT.Visible = false;
            buttonPRINT.Visible = false;
            panelINVENTORYDATA.Visible = true;
            panel3.Visible = false;

            PopulateDataGridView();
            PopulateChartProducts();

            buttonPRINT2.Visible = true;
        }
        private void PopulateChartProducts()
        {
            string query = "SELECT PRODUCTNAME, DEDUCTIONS FROM PRODUCTS";

            List<string> productNames = new List<string>();
            List<decimal> deductions = new List<decimal>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productName = reader.GetString(0);
                    decimal deduction = reader.GetDecimal(1);

                    productNames.Add(productName);
                    deductions.Add(deduction);
                }

                reader.Close();
            }

            chartPRODUCTS.Series.Clear();

            Series series = new Series();
            series.ChartType = SeriesChartType.Bar;
            series.Name = "Product Usages";

            for (int i = 0; i < productNames.Count; i++)
            {
                series.Points.AddXY(productNames[i], deductions[i]);
            }

            chartPRODUCTS.Series.Add(series);

            chartPRODUCTS.Titles.Clear();
            chartPRODUCTS.Titles.Add("Product Usage");
        }

        private void PopulateDataGridView()
        {
            string query = "SELECT PRODUCTNAME, QUANTITY, PRICE, DEDUCTIONS, RESTOCKCOUNT, RESTOCKPRICE FROM PRODUCTS";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                dataGridViewPRODUCTS.DataSource = dataTable;
            }
        }
        private void buttonPRINT2_Click(object sender, EventArgs e)
        {
            Bitmap inventoryBitmap = GenerateInventoryBitmap();
            ShowInventoryImage(inventoryBitmap);
        }
        private Bitmap GenerateInventoryBitmap()
        {
            int width = 600;
            int height = 500;

            Bitmap inventoryBitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(inventoryBitmap))
            {
                graphics.Clear(Color.White); // Set background color to black
                Font titleFont = new Font("Bahnschrift SemiCondensed", 20, FontStyle.Bold);
                Font infoFont = new Font("Bahnschrift SemiCondensed", 12);
                Brush brush = Brushes.Black; 

                string shopName = "---------- PRECISION SHEARS -----------";
                string motto = "YOUR HAIR, YOUR RULES, OUR EXPERTISE.";
                string datePrinted = $"Date Printed: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}";

                float shopNameWidth = graphics.MeasureString(shopName, titleFont).Width;
                float shopNameX = (width - shopNameWidth) / 2;
                graphics.DrawString(shopName, titleFont, brush, new PointF(shopNameX, 20));

                float mottoWidth = graphics.MeasureString(motto, infoFont).Width;
                float mottoX = (width - mottoWidth) / 2;
                graphics.DrawString(motto, infoFont, brush, new PointF(mottoX, 40));

                float datePrintedWidth = graphics.MeasureString(datePrinted, infoFont).Width;
                float datePrintedX = (width - datePrintedWidth) / 2;
                graphics.DrawString(datePrinted, infoFont, brush, new PointF(datePrintedX, 60));

                string query = "SELECT PRODUCTNAME, QUANTITY, PRICE, DEDUCTIONS, RESTOCKCOUNT, RESTOCKPRICE FROM PRODUCTS";

                int y;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Initialize y
                    y = 90;
                    float maxQuantityWidth = 0;
                    float maxValueWidth = 0;
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        string quantity = reader.GetDecimal(1).ToString();
                        string value = (reader.GetDecimal(2) * reader.GetDecimal(1)).ToString(); // Calculate the total value
                        float quantityWidth = graphics.MeasureString(quantity, infoFont).Width;
                        float valueWidth = graphics.MeasureString(value, infoFont).Width;
                        if (quantityWidth > maxQuantityWidth)
                            maxQuantityWidth = quantityWidth;
                        if (valueWidth > maxValueWidth)
                            maxValueWidth = valueWidth;
                    }
                    reader.Close();
                }



                string title = "Inventory Overview";
                graphics.DrawString(title, titleFont, brush, new PointF((width - graphics.MeasureString(title, titleFont).Width) / 2, y));
                y += (int)titleFont.GetHeight() + 10;

                string overview = GenerateInventoryOverview();
                graphics.DrawString(overview, infoFont, brush, new PointF(20, y));

                y += (int)infoFont.GetHeight() * (overview.Split('\n').Length + 2);

                decimal totalInventoryValue = CalculateTotalInventoryValue();
                decimal totalDeductions = CalculateTotalDeductions();
                int totalRestockEvents = CalculateTotalRestockEvents();
                int currentInventoryLevel = CalculateCurrentInventoryLevel();
                decimal totalRestockingCost = CalculateTotalRestockingCost();

                graphics.DrawString($"Total Inventory Value: {totalInventoryValue}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();

                graphics.DrawString($"Total Usages: {totalDeductions}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();

                graphics.DrawString($"Total Restock Events: {totalRestockEvents}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();

                graphics.DrawString($"Current Inventory Level: {currentInventoryLevel}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();

                graphics.DrawString($"Total Restocking Cost: {totalRestockingCost}", infoFont, brush, new PointF(20, y));
                y += (int)infoFont.GetHeight();

                y += 20;
                string endOfReport = "End Of Report";
                graphics.DrawString(endOfReport, titleFont, brush, new PointF(20, y));
            }

            return inventoryBitmap;
        }


        private void ShowInventoryImage(Bitmap inventoryBitmap)
        {
            Form inventoryImageForm = new Form();
            inventoryImageForm.Text = "Inventory Report";
            inventoryImageForm.StartPosition = FormStartPosition.CenterScreen;

            PictureBox pbInventoryImage = new PictureBox();
            pbInventoryImage.Dock = DockStyle.Fill;
            pbInventoryImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbInventoryImage.Image = inventoryBitmap;

            inventoryImageForm.Controls.Add(pbInventoryImage);

            inventoryImageForm.ClientSize = inventoryBitmap.Size;

            inventoryImageForm.ShowDialog();
        }
        private decimal CalculateTotalInventoryValue()
        {
            decimal totalValue = 0;

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                decimal quantity = Convert.ToDecimal(row.Cells["QUANTITY"].Value);
                decimal price = Convert.ToDecimal(row.Cells["PRICE"].Value);

                totalValue += quantity * price;
            }

            return totalValue;
        }

        private decimal CalculateTotalDeductions()
        {
            decimal totalDeductions = 0;

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                decimal deductions = Convert.ToDecimal(row.Cells["DEDUCTIONS"].Value);
                totalDeductions += deductions;
            }

            return totalDeductions;
        }
        private int CalculateTotalRestockEvents()
        {
            int totalRestockEvents = 0;

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                if (row.Cells["RESTOCKCOUNT"].Value != DBNull.Value)
                {
                    int restockCount = Convert.ToInt32(row.Cells["RESTOCKCOUNT"].Value);
                    totalRestockEvents += restockCount;
                }
            }

            return totalRestockEvents;
        }

        private int CalculateCurrentInventoryLevel()
        {
            int currentInventoryLevel = 0;

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                int quantity = Convert.ToInt32(row.Cells["QUANTITY"].Value);
                currentInventoryLevel += quantity;
            }

            return currentInventoryLevel;
        }
        private decimal CalculateTotalRestockingCost()
        {
            decimal totalRestockingCost = 0;

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                object restockPriceObj = row.Cells["RESTOCKPRICE"].Value;

                if (restockPriceObj != DBNull.Value)
                {
                    decimal restockPrice = Convert.ToDecimal(restockPriceObj);
                    totalRestockingCost += restockPrice;
                }
            }

            return totalRestockingCost;
        }
        private string GenerateInventoryOverview()
        {
            StringBuilder overview = new StringBuilder();

            int productNameWidth = 40;
            int quantityWidth = 10;
            int valueWidth = 15;

            overview.AppendLine("+------------------------------------------+------------+---------------+");
            overview.AppendLine($"|{"Product Name".PadRight(productNameWidth)}|{"Quantity".PadLeft(quantityWidth)}|{"Value".PadLeft(valueWidth)}|");
            overview.AppendLine("+------------------------------------------+------------+---------------+");

            foreach (DataGridViewRow row in dataGridViewPRODUCTS.Rows)
            {
                if (!row.IsNewRow)
                {
                    string productName = Convert.ToString(row.Cells["PRODUCTNAME"].Value);
                    decimal quantity = Convert.ToDecimal(row.Cells["QUANTITY"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["PRICE"].Value);
                    decimal value = quantity * price;

                    string formattedRow = $"|{TruncateString(productName, productNameWidth).PadRight(productNameWidth)}|" +
                                          $"{quantity.ToString("N2").PadLeft(quantityWidth)}|" +
                                          $"{value.ToString("N2").PadLeft(valueWidth)}|";
                    overview.AppendLine(formattedRow);
                }
            }

            overview.AppendLine("+------------------------------------------+------------+---------------+");

            return overview.ToString();
        }

        private string TruncateString(string value, int maxLength)
        {
            if (value.Length <= maxLength)
                return value;
            else
                return value.Substring(0, maxLength);
        }
    }
}
