using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_CUSTOMERS : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";

        public C_CUSTOMERS()
        {
            InitializeComponent();
            panel2.Visible = false;
            PopulateListViewCustomers();
        }
        private void PopulateListViewCustomers()
        {
            listViewCUSTOMERS.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FIRSTNAME, LASTNAME, CUSTOMERPIC, SUGGESTIONS, STAR FROM [WALK-IN-CUSTOMER] " +
                               "WHERE DATE >= @StartDate AND DATE <= @EndDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", dateTimePickerBEFORE.Value.Date);
                    command.Parameters.AddWithValue("@EndDate", dateTimePickerAFTER.Value.Date);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["FIRSTNAME"].ToString());
                            item.SubItems.Add(reader["LASTNAME"].ToString());

                            byte[] imageData = (byte[])reader["CUSTOMERPIC"];
                            Image customerImage = Image.FromStream(new MemoryStream(imageData));
                            imageList1.Images.Add(customerImage);
                            item.ImageIndex = imageList1.Images.Count - 1;

                            item.SubItems.Add(reader["SUGGESTIONS"].ToString());
                            item.SubItems.Add(reader["STAR"].ToString());

                            listViewCUSTOMERS.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void listViewCUSTOMERS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCUSTOMERS.SelectedItems.Count > 0)
            {
                panel2.Visible = true;

                ListViewItem selectedItem = listViewCUSTOMERS.SelectedItems[0];

                string firstName = selectedItem.SubItems[0].Text;
                string lastName = selectedItem.SubItems[1].Text;
                string barberName = selectedItem.SubItems[3].Text; 

                textBoxFNAME.Text = firstName;
                textBoxLNAME.Text = lastName;

                textBoxBARBER.Text = barberName;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT CUSTOMERPIC FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        try
                        {
                            connection.Open();
                            object result = command.ExecuteScalar();
                            if (result != null)
                            {
                                byte[] imageData = (byte[])result;
                                Image customerImage = Image.FromStream(new MemoryStream(imageData));
                                pictureBoxPROFILE.Image = customerImage;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT STAR, SUGGESTIONS, BARBER FROM [WALK-IN-CUSTOMER] " +
                                   "WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                int starNumber = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                string suggestionsValue = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                string databaseBarberName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                                for (int i = 1; i <= 5; i++)
                                {
                                    PictureBox pictureBox = Controls.Find("pictureBox" + i, true).FirstOrDefault() as PictureBox;
                                    if (pictureBox != null)
                                    {
                                        pictureBox.Image = i <= starNumber ? Properties.Resources.filledstar : Properties.Resources.unfilledstar;
                                    }
                                }

                                richTextBoxSUGGESTIONS.Text = suggestionsValue;

                                textBoxBARBER.Text = databaseBarberName;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void dateTimePickerBEFORE_ValueChanged(object sender, EventArgs e)
        {
            PopulateListViewCustomers();
        }

        private void dateTimePickerAFTER_ValueChanged(object sender, EventArgs e)
        {
            PopulateListViewCustomers();
        }

        private void C_CUSTOMERS_Load(object sender, EventArgs e)
        {
            PopulateListViewCustomers();
        }

        private void richTextBoxSUGGESTIONS_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
