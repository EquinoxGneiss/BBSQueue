using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_USERS : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }
        public C_USERS()
        {
            InitializeComponent();
            buttonEDITUSER.Enabled = false;
        }
        private void buttonREGISTER_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add a new user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                A_REGISTER register = new A_REGISTER(AFirstName, ALastName, AProfilePictureData);
                register.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }

        private void buttonMANAGER_Click(object sender, EventArgs e)
        {
            PopulateListView("Manager");
        }

        private void buttonRECEPTIONIST_Click(object sender, EventArgs e)
        {
            PopulateListView("Receptionist");
        }
        private void PopulateListView(string role)
        {
            listViewUSERS.Items.Clear();

            string query = "SELECT FIRSTNAME, LASTNAME, PROFILEPICTURE FROM USERS WHERE ROLE = @Role";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Role", role);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string firstName = reader["FIRSTNAME"].ToString();
                        string lastName = reader["LASTNAME"].ToString();
                        byte[] profilePictureData = (byte[])reader["PROFILEPICTURE"];

                        Image profileImage = Image.FromStream(new System.IO.MemoryStream(profilePictureData));

                        listViewUSERS.LargeImageList = imageList1;
                        int imageIndex = imageList1.Images.Add(profileImage, Color.Transparent);
                        ListViewItem item = new ListViewItem(new string[] { firstName, lastName }, imageIndex);
                        listViewUSERS.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void buttonEDITUSER_Click(object sender, EventArgs e)
        {
            if (listViewUSERS.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewUSERS.SelectedItems[0];
                string firstName = selectedItem.SubItems[0].Text;
                string lastName = selectedItem.SubItems[1].Text;

                // Fetch user data from the database based on selected first name and last name
                string username = "";
                string role = "";
                byte[] profilepicture = null;

                string query = "SELECT USERNAME, ROLE, PROFILEPICTURE FROM USERS WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            username = reader["USERNAME"].ToString();
                            role = reader["ROLE"].ToString();
                            profilepicture = (byte[])reader["PROFILEPICTURE"];
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving user details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DialogResult result = MessageBox.Show("Are you sure you want to edit this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    E_USER edituser = new E_USER(AFirstName, ALastName, AProfilePictureData, username, firstName, lastName, role, profilepicture);
                    edituser.Show();

                    Form parentForm = this.ParentForm;
                    if (parentForm != null)
                    {
                        parentForm.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listViewUSERS_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewUSERS.SelectedItems.Count > 0)
            {
                buttonEDITUSER.Enabled = true;
            }
            else
            {
                buttonEDITUSER.Enabled = false;
            }
        }
    }
}
