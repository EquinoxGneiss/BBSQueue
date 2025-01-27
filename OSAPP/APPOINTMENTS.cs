using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class APPOINTMENTS : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public APPOINTMENTS(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            PopulateBarbersListView();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;
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
        private void APPOINTMENTS_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
        }

        private void panel5_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                D_RECEPTIONIST receptionist = new D_RECEPTIONIST(AfirstName, AlastName, AprofilePictureData);
                receptionist.Show();
                this.Close();
            }
        }
        private void listViewBARBERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBARBERS.SelectedItems.Count > 0)
            {
                string selectedBarberFirstName = listViewBARBERS.SelectedItems[0].Text;

                listViewAPPOINTMENTS.Items.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query;
                    SqlCommand command;
                    if (selectedBarberFirstName == "ALL")
                    {
                        query = "SELECT BARBER, TRANSACTIONPIC, DATE FROM [WALK-IN-CUSTOMER] WHERE STATUS = 'APPOINTED' ORDER BY DATE ASC ";
                        command = new SqlCommand(query, connection);
                        labelAPPOINTMENTS.Text = "ALL APPOINTMENTS";
                    }
                    else
                    {
                        query = "SELECT TRANSACTIONPIC, DATE FROM [WALK-IN-CUSTOMER] WHERE BARBER = @BarberFirstName AND STATUS = 'APPOINTED' ORDER BY DATE ASC ";
                        command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@BarberFirstName", selectedBarberFirstName);
                        labelAPPOINTMENTS.Text = selectedBarberFirstName + " APPOINTMENTS";
                    }

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] transactionPicBytes = (byte[])reader["TRANSACTIONPIC"];
                        DateTime date = (DateTime)reader["DATE"];

                        Image transactionPic = ByteArrayToImage(transactionPicBytes);

                        ListViewItem item;
                        if (selectedBarberFirstName == "ALL")
                        {
                            item = new ListViewItem(new string[] {date.ToString() });
                        }
                        else
                        {
                            item = new ListViewItem(date.ToString());
                        }

                        item.ImageIndex = listViewAPPOINTMENTS.SmallImageList.Images.Count;
                        listViewAPPOINTMENTS.SmallImageList.Images.Add(transactionPic);
                        listViewAPPOINTMENTS.Items.Add(item);
                    }
                }
            }
        }
        private void listViewAPPOINTMENTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAPPOINTMENTS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewAPPOINTMENTS.SelectedItems[0];
                DateTime selectedDate = DateTime.Parse(selectedItem.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT CUSTOMERPIC, FIRSTNAME, LASTNAME, GENDER, SERVICES, PRICE FROM [WALK-IN-CUSTOMER] WHERE DATE = @SelectedDate";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] customerPicBytes = (byte[])reader["CUSTOMERPIC"];
                        string firstName = reader["FIRSTNAME"].ToString();
                        string lastName = reader["LASTNAME"].ToString();
                        string gender = reader["GENDER"].ToString();
                        string services = reader["SERVICES"].ToString();
                        decimal price = (decimal)reader["PRICE"];

                        pictureBoxCPIC.Image = ByteArrayToImage(customerPicBytes);

                        labelNAME.Text = $"{firstName} {lastName}";

                        labelGENDER.Text = gender;

                        listBoxSERVICES.Items.Clear();
                        string[] serviceArray = services.Split(',');
                        foreach (string service in serviceArray)
                        {
                            listBoxSERVICES.Items.Add(service.Trim());
                        }

                        labelPRICE.Text = $"Price: {price.ToString("C")}";
                    }
                }
            }
        }
    }
}
