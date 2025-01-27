using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class A_BARBER : Form
    {
        private string AfirstName;
        private string AlastName;
        private byte[] AprofilePictureData;
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SOREN\\Documents\\OSAPP\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public A_BARBER(string AfirstName, string AlastName, byte[] AprofilePictureData)
        {
            InitializeComponent();
            this.AfirstName = AfirstName;
            this.AlastName = AlastName;
            this.AprofilePictureData = AprofilePictureData;

            panel3.Visible = false;
            panel4.Visible = false;
        }


        private void A_BARBER_Load(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel4.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePictureData);
                adminForm.Show();
                this.Close();
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
        private void buttonREGISTER_Click(object sender, EventArgs e)
        {

            string query = "INSERT INTO BARBERS (FIRSTNAME, LASTNAME, PROFILEPICTURE) VALUES (@FirstName, @LastName,@ProfilePicture)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", textBoxFNAME.Text);
                command.Parameters.AddWithValue("@LastName", textBoxLNAME.Text);
                command.Parameters.AddWithValue("@ProfilePicture", ImageToByteArray(pictureBoxPROFILE.Image));

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barber added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        D_ADMIN adminForm = new D_ADMIN(AfirstName, AlastName, AprofilePictureData);
                        adminForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add barber.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBoxPROFILE_Click(object sender, EventArgs e)
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
        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxFNAME.TextChanged -= textBoxFNAME_TextChanged;

            string input = textBoxFNAME.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxFNAME.Clear();
            }

            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed.");
                textBoxFNAME.Text = ""; 
            }

            textBoxFNAME.TextChanged += textBoxFNAME_TextChanged;
        }

        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            textBoxLNAME.TextChanged -= textBoxLNAME_TextChanged; 

            string input = textBoxLNAME.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                textBoxLNAME.Clear();
            }

            if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"^[a-zA-Z][a-zA-Z\s]*$"))
            {
                MessageBox.Show("Please enter only letters (alphabetic characters). Numbers and symbols are not allowed.");
                textBoxLNAME.Text = ""; 
            }

            textBoxLNAME.TextChanged += textBoxLNAME_TextChanged; 
        }

    }
}
