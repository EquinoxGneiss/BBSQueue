using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class RatingForm : Form
    {
        private PictureBox[] starPictureBoxes;
        private int selectedStars = 0;
        private const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public RatingForm()
        {
            InitializeComponent();
            panel1.Visible = false;

            InitializeStarPictureBoxes();
            InitializeSecondRatingPictureBoxes();
            InitializeThirdRatingPictureBoxes();
            InitializeFourthRatingPictureBoxes();
        }

        private void InitializeStarPictureBoxes()
        {
            starPictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };

            for (int i = 0; i < starPictureBoxes.Length; i++)
            {
                PictureBox pictureBox = starPictureBoxes[i];
                pictureBox.Tag = i;
                pictureBox.MouseEnter += PictureBox_MouseEnter;
                pictureBox.MouseLeave += PictureBox_MouseLeave;
                pictureBox.Click += PictureBox_Click;
            }
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;

            for (int i = 0; i <= index; i++)
            {
                starPictureBoxes[i].Image = Properties.Resources.filledstar;
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (selectedStars == 0)
            {
                foreach (PictureBox pictureBox in starPictureBoxes)
                {
                    pictureBox.Image = Properties.Resources.unfilledstar;
                }
            }
            else
            {
                for (int i = 0; i < selectedStars; i++)
                {
                    starPictureBoxes[i].Image = Properties.Resources.filledstar;
                }
                for (int i = selectedStars; i < starPictureBoxes.Length; i++)
                {
                    starPictureBoxes[i].Image = Properties.Resources.unfilledstar;
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;
            selectedStars = index + 1;

            for (int i = 0; i <= index; i++)
            {
                starPictureBoxes[i].Image = Properties.Resources.filledstar;
            }

            for (int i = index + 1; i < starPictureBoxes.Length; i++)
            {
                starPictureBoxes[i].Image = Properties.Resources.unfilledstar;
            }

            Console.WriteLine("Selected Stars: " + selectedStars);
        }

        private void RatingForm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel5.BackColor = Color.FromArgb(100, 100, 0, 0);
        }
        private PictureBox[] secondRatingPictureBoxes;
        private int selectedSecondRatingStars = 0;

        private void InitializeSecondRatingPictureBoxes()
        {
            secondRatingPictureBoxes = new PictureBox[] { pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };

            for (int i = 0; i < secondRatingPictureBoxes.Length; i++)
            {
                PictureBox pictureBox = secondRatingPictureBoxes[i];
                pictureBox.Tag = i;
                pictureBox.MouseEnter += SecondRatingPictureBox_MouseEnter;
                pictureBox.MouseLeave += SecondRatingPictureBox_MouseLeave;
                pictureBox.Click += SecondRatingPictureBox_Click;
            }
        }

        private void SecondRatingPictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;

            for (int i = 0; i <= index; i++)
            {
                secondRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }
        }

        private void SecondRatingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (selectedSecondRatingStars == 0)
            {
                foreach (PictureBox pictureBox in secondRatingPictureBoxes)
                {
                    pictureBox.Image = Properties.Resources.unfilledstar;
                }
            }
            else
            {
                for (int i = 0; i < selectedSecondRatingStars; i++)
                {
                    secondRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
                }
                for (int i = selectedSecondRatingStars; i < secondRatingPictureBoxes.Length; i++)
                {
                    secondRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
                }
            }
        }

        private void SecondRatingPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;
            selectedSecondRatingStars = index + 1;

            for (int i = 0; i <= index; i++)
            {
                secondRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }

            for (int i = index + 1; i < secondRatingPictureBoxes.Length; i++)
            {
                secondRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
            }

            Console.WriteLine("Selected Second Rating Stars: " + selectedSecondRatingStars);
        }
        private PictureBox[] thirdRatingPictureBoxes;
        private int selectedThirdRatingStars = 0;

        private void InitializeThirdRatingPictureBoxes()
        {
            thirdRatingPictureBoxes = new PictureBox[] { pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15 };

            for (int i = 0; i < thirdRatingPictureBoxes.Length; i++)
            {
                PictureBox pictureBox = thirdRatingPictureBoxes[i];
                pictureBox.Tag = i;
                pictureBox.MouseEnter += ThirdRatingPictureBox_MouseEnter;
                pictureBox.MouseLeave += ThirdRatingPictureBox_MouseLeave;
                pictureBox.Click += ThirdRatingPictureBox_Click;
            }
        }

        private void ThirdRatingPictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;

            for (int i = 0; i <= index; i++)
            {
                thirdRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }
        }

        private void ThirdRatingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (selectedThirdRatingStars == 0)
            {
                foreach (PictureBox pictureBox in thirdRatingPictureBoxes)
                {
                    pictureBox.Image = Properties.Resources.unfilledstar;
                }
            }
            else
            {
                for (int i = 0; i < selectedThirdRatingStars; i++)
                {
                    thirdRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
                }
                for (int i = selectedThirdRatingStars; i < thirdRatingPictureBoxes.Length; i++)
                {
                    thirdRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
                }
            }
        }

        private void ThirdRatingPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;
            selectedThirdRatingStars = index + 1;

            for (int i = 0; i <= index; i++)
            {
                thirdRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }

            for (int i = index + 1; i < thirdRatingPictureBoxes.Length; i++)
            {
                thirdRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
            }

            Console.WriteLine("Selected Third Rating Stars: " + selectedThirdRatingStars);
        }
        private PictureBox[] fourthRatingPictureBoxes;
        private int selectedFourthRatingStars = 0;

        private void InitializeFourthRatingPictureBoxes()
        {
            fourthRatingPictureBoxes = new PictureBox[] { pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20 };

            for (int i = 0; i < fourthRatingPictureBoxes.Length; i++)
            {
                PictureBox pictureBox = fourthRatingPictureBoxes[i];
                pictureBox.Tag = i;
                pictureBox.MouseEnter += FourthRatingPictureBox_MouseEnter;
                pictureBox.MouseLeave += FourthRatingPictureBox_MouseLeave;
                pictureBox.Click += FourthRatingPictureBox_Click;
            }
        }

        private void FourthRatingPictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;

            for (int i = 0; i <= index; i++)
            {
                fourthRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }
        }

        private void FourthRatingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (selectedFourthRatingStars == 0)
            {
                foreach (PictureBox pictureBox in fourthRatingPictureBoxes)
                {
                    pictureBox.Image = Properties.Resources.unfilledstar;
                }
            }
            else
            {
                for (int i = 0; i < selectedFourthRatingStars; i++)
                {
                    fourthRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
                }
                for (int i = selectedFourthRatingStars; i < fourthRatingPictureBoxes.Length; i++)
                {
                    fourthRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
                }
            }
        }

        private void FourthRatingPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            int index = (int)pictureBox.Tag;
            selectedFourthRatingStars = index + 1;

            for (int i = 0; i <= index; i++)
            {
                fourthRatingPictureBoxes[i].Image = Properties.Resources.filledstar;
            }

            for (int i = index + 1; i < fourthRatingPictureBoxes.Length; i++)
            {
                fourthRatingPictureBoxes[i].Image = Properties.Resources.unfilledstar;
            }

            Console.WriteLine("Selected Fourth Rating Stars: " + selectedFourthRatingStars);
        }
        private void buttonSUBMIT_Click(object sender, EventArgs e)
        {
            // Get the values of firstName, lastName, and transactionNumber
            string firstName = textBoxFNAME.Text;
            string lastName = textBoxLNAME.Text;
            string transactionNumber = comboBoxTICKET.SelectedItem.ToString();

            // Proceed with the database update
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE [WALK-IN-CUSTOMER] SET SUGGESTIONS = @Suggestions, STAR = @Star WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName AND TRANSACTIONNUMBER = @TransactionNumber";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@TransactionNumber", transactionNumber);
                    command.Parameters.AddWithValue("@Suggestions", richTextBoxSUGGESTIONS.Text);

                    int totalStars = selectedStars + selectedSecondRatingStars + selectedThirdRatingStars + selectedFourthRatingStars;
                    int numberOfRatings = (selectedStars > 0 ? 1 : 0) + (selectedSecondRatingStars > 0 ? 1 : 0) + (selectedThirdRatingStars > 0 ? 1 : 0) + (selectedFourthRatingStars > 0 ? 1 : 0);
                    int starAverage = numberOfRatings > 0 ? totalStars / numberOfRatings : 0;
                    command.Parameters.AddWithValue("@Star", starAverage);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rating updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No records were updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating rating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void textBoxFNAME_TextChanged(object sender, EventArgs e)
        {
            PopulateTransactionNumbers(textBoxFNAME.Text, textBoxLNAME.Text);
        }
        private void textBoxLNAME_TextChanged(object sender, EventArgs e)
        {
            PopulateTransactionNumbers(textBoxFNAME.Text, textBoxLNAME.Text);
        }
        private void PopulateTransactionNumbers(string firstName, string lastName)
        {
            comboBoxTICKET.Items.Clear(); // Clear existing items

            // Query to fetch distinct TRANSACTIONNUMBER values for the given FIRSTNAME and LASTNAME
            string query = "SELECT DISTINCT TRANSACTIONNUMBER, SUGGESTIONS FROM [WALK-IN-CUSTOMER] WHERE FIRSTNAME = @FirstName AND LASTNAME = @LastName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string transactionNumber = reader["TRANSACTIONNUMBER"].ToString();
                            string suggestions = reader["SUGGESTIONS"].ToString();

                            comboBoxTICKET.Items.Add(transactionNumber); // Add each TRANSACTIONNUMBER to the combo box

                            if (!string.IsNullOrEmpty(suggestions))
                            {
                                richTextBoxSUGGESTIONS.Text = suggestions; // Display suggestions if they exist
                            }
                            else
                            {
                                richTextBoxSUGGESTIONS.Text = ""; // Clear the suggestions if not available
                            }
                        }

                        // Hide panel1 if first name or last name is modified
                        panel1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching transaction numbers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSELECT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFNAME.Text) && !string.IsNullOrEmpty(textBoxLNAME.Text) && comboBoxTICKET.SelectedItem != null)
            {
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Please fill in all fields before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBoxSUGGESTIONS_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
