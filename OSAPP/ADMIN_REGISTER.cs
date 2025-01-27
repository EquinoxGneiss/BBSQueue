using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace OSAPP
{
    public partial class ADMIN_REGISTER : Form
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public ADMIN_REGISTER()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        private void buttonNEXT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxUNAME.Text) &&
                !string.IsNullOrEmpty(textBoxPASS.Text) &&
                !string.IsNullOrEmpty(textBoxRECOVER.Text))
            {
                panel2.Visible = true;

                textBoxUNAME.Enabled = false;
                textBoxPASS.Enabled = false;
                textBoxRECOVER.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonNEXT2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFNAME.Text) &&
                !string.IsNullOrEmpty(textBoxLNAME.Text))
            {
                panel3.Visible = true;

                textBoxFNAME.Enabled = false;
                textBoxLNAME.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonUPLOAD_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;

                    pictureBoxPROFILE.Image = Image.FromFile(selectedImagePath);

                    panel4.Visible = true;
                }
            }
        }
        private void buttonREGISTER_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO USERS (USERNAME, PASSWORD, RECOVER, FIRSTNAME, LASTNAME, ROLE, PROFILEPICTURE) VALUES (@Username, @Password, @Recover, @FirstName, @LastName, @Role, @ProfilePicture)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", textBoxUNAME.Text);
                command.Parameters.AddWithValue("@Password", textBoxPASS.Text);
                command.Parameters.AddWithValue("@Recover", textBoxRECOVER.Text);
                command.Parameters.AddWithValue("@FirstName", textBoxFNAME.Text);
                command.Parameters.AddWithValue("@LastName", textBoxLNAME.Text);
                command.Parameters.AddWithValue("@Role", "ADMIN"); 
                command.Parameters.AddWithValue("@ProfilePicture", ImageToByteArray(pictureBoxPROFILE.Image));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LOGIN login = new LOGIN();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to register user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private void checkBoxSHOWPASS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPASS.UseSystemPasswordChar = !checkBoxSHOWPASS.Checked;
        }

        private void REGISTER_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel5_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBoxUNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxUNAME.TextChanged -= textBoxUNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxUNAME.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxUNAME.Clear();
            }

            textBoxUNAME.TextChanged += textBoxUNAME_TextChanged; // Resubscribe
        }

        private void textBoxPASS_TextChanged(object sender, EventArgs e)
        {
            textBoxPASS.TextChanged -= textBoxPASS_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxPASS.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxPASS.Clear();
            }

            textBoxPASS.TextChanged += textBoxPASS_TextChanged; // Resubscribe
        }

        private void textBoxRECOVER_TextChanged(object sender, EventArgs e)
        {
            textBoxRECOVER.TextChanged -= textBoxRECOVER_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxRECOVER.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxRECOVER.Clear();
            }

            textBoxRECOVER.TextChanged += textBoxRECOVER_TextChanged; // Resubscribe
        }
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxFNAME.TextChanged -= textBoxFNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxFNAME.Text.Trim();

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxFNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxFNAME.Text = ""; // Clear the textbox
            }

            textBoxFNAME.TextChanged += textBoxFNAME_TextChanged; // Resubscribe
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxLNAME.TextChanged -= textBoxLNAME_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxLNAME.Text.Trim();

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxLNAME.Clear();
            }

            // Check if the input contains any numbers or symbols at the beginning
            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed at the beginning.");
                textBoxLNAME.Text = ""; // Clear the textbox
            }

            textBoxLNAME.TextChanged += textBoxLNAME_TextChanged; // Resubscribe
        }
    }
}
