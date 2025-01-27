using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class FORGOTPASS : Form
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True"; public FORGOTPASS()
        {
            InitializeComponent();
        }

        private void FORGOTPASS_Load(object sender, EventArgs e)
        {
            panelFPASS.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 100, 0, 0);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to go back?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LOGIN lOGIN = new LOGIN();
                lOGIN.Show();
                this.Close();
            }
        }
        private bool ValidateUser(string username, string hint)
        {
            bool isValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM USERS WHERE USERNAME = @Username AND RECOVER = @Recover";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Recover", hint);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    isValid = count > 0;
                }
            }

            return isValid;
        }
        private bool UpdatePassword(string username, string newPassword)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string oldPasswordQuery = "SELECT PASSWORD FROM USERS WHERE USERNAME = @Username";

                    using (SqlCommand command = new SqlCommand(oldPasswordQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        connection.Open();
                        string oldPassword = command.ExecuteScalar()?.ToString();

                        if (oldPassword != null && oldPassword == newPassword)
                        {
                            return false;
                        }
                    }

                    string updateQuery = "UPDATE USERS SET PASSWORD = @NewPassword WHERE USERNAME = @Username";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", newPassword);
                        command.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        private void buttonFORGOTPASS_Click(object sender, EventArgs e)
        {
            string username = textBoxUNAME.Text.Trim();
            string hint = textBoxHINT.Text.Trim();
            string newPassword = textBoxNEWPASS.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(hint) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isValid = ValidateUser(username, hint);

            if (isValid)
            {
                bool success = UpdatePassword(username, newPassword);

                if (success)
                {
                    MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                    LOGIN loginForm = new LOGIN();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or hint. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxSHOWPASS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNEWPASS.UseSystemPasswordChar = !checkBoxSHOWPASS.Checked;
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

        private void textBoxNEWPASS_TextChanged(object sender, EventArgs e)
        {
            textBoxNEWPASS.TextChanged -= textBoxNEWPASS_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxNEWPASS.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxNEWPASS.Clear();
            }

            textBoxNEWPASS.TextChanged += textBoxNEWPASS_TextChanged; // Resubscribe
        }

        private void textBoxHINT_TextChanged(object sender, EventArgs e)
        {
            textBoxHINT.TextChanged -= textBoxHINT_TextChanged; // Unsubscribe

            // Get the current text in the text box
            string input = textBoxHINT.Text;

            // Check if the input is empty or contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                // Clear the text box
                textBoxHINT.Clear();
            }

            textBoxHINT.TextChanged += textBoxHINT_TextChanged; // Resubscribe
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
