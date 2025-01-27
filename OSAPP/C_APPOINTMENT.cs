using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OSAPP
{
    public partial class C_APPOINTMENT : UserControl
    {
        public const string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\JJ\\source\\repos\\EquinoxGneiss\\BBSQueue\\OSAPP\\SHOP.mdf;Integrated Security=True";
        public string AFirstName { get; set; }
        public string ALastName { get; set; }
        public byte[] AProfilePictureData { get; set; }

        private DateTime currentMonth;

        public C_APPOINTMENT()
        {
            InitializeComponent();
            currentMonth = DateTime.Now;
            PopulateCalendar();
        }
        private void PopulateCalendar()
        {
            flowLayoutPanel1.Controls.Clear();

            int numCols = 8;
            int cellWidth = flowLayoutPanel1.ClientSize.Width / numCols;
            int cellHeight = 70;

            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);

            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);

            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            startDayOfWeek = (startDayOfWeek == 0) ? 7 : startDayOfWeek;

            int totalCells = (numCols * (daysInMonth + startDayOfWeek - 1));

            int numRows = (int)Math.Ceiling((double)totalCells / numCols);

            Label monthLabel = new Label();
            monthLabel.Text = currentMonth.ToString("MMMM yyyy");
            monthLabel.TextAlign = ContentAlignment.MiddleCenter;
            monthLabel.Font = new Font("Bahnschrift SemiCondensed", 22, FontStyle.Bold);
            monthLabel.Width = cellWidth * numCols;
            monthLabel.Height = cellHeight / 2;
            flowLayoutPanel1.Controls.Add(monthLabel);

            string[] dayNames = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
            foreach (string dayName in dayNames)
            {
                Label dayOfWeekLabel = new Label();
                dayOfWeekLabel.Text = dayName;
                dayOfWeekLabel.TextAlign = ContentAlignment.MiddleCenter;
                dayOfWeekLabel.Font = new Font("Bahnschrift SemiCondensed", 14, FontStyle.Bold);
                dayOfWeekLabel.Width = cellWidth;
                dayOfWeekLabel.Height = cellHeight / 2;
                dayOfWeekLabel.AutoSize = false;
                dayOfWeekLabel.ForeColor = Color.Blue;
                dayOfWeekLabel.BackColor = Color.LightBlue;
                flowLayoutPanel1.Controls.Add(dayOfWeekLabel);
            }

            for (int i = 1; i < startDayOfWeek; i++)
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "";
                emptyLabel.Width = cellWidth;
                emptyLabel.Height = cellHeight;
                emptyLabel.AutoSize = false;
                flowLayoutPanel1.Controls.Add(emptyLabel);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                Label dayLabel = new Label();
                dayLabel.Text = i.ToString();
                dayLabel.TextAlign = ContentAlignment.MiddleCenter;
                dayLabel.BorderStyle = BorderStyle.Fixed3D;
                dayLabel.Width = cellWidth;
                dayLabel.Height = cellHeight;
                dayLabel.AutoSize = false;

                dayLabel.MouseEnter += DayLabel_MouseEnter;
                dayLabel.MouseLeave += DayLabel_MouseLeave;
                dayLabel.Click += DayLabel_Click;

                DateTime currentDate = new DateTime(currentMonth.Year, currentMonth.Month, i);
                if (currentDate <= DateTime.Today) // Change here to include today's date
                {
                    dayLabel.Enabled = false;
                    dayLabel.BackColor = Color.LightGray;
                }

                flowLayoutPanel1.Controls.Add(dayLabel);
            }

            flowLayoutPanel1.Width = cellWidth * numCols;
            flowLayoutPanel1.Height = cellHeight * numRows;
        }


        private void DayLabel_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Blue; 
                label.ForeColor = Color.White; 
            }
        }

        private void DayLabel_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Empty; 
                label.ForeColor = Color.Empty; 
            }
        }
        private void DayLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                int day = int.Parse(clickedLabel.Text);
                DateTime selectedDate = new DateTime(currentMonth.Year, currentMonth.Month, day);

                if (selectedDate < DateTime.Today)
                {
                    return;
                }

                MessageBox.Show("Selected Date: " + selectedDate.ToString("MMMM dd, yyyy"));

                PopulateTimeSlots(selectedDate);
            }
        }

        private void PopulateTimeSlots(DateTime selectedDate)
        {
            flowLayoutPanel2.Controls.Clear();

            Label dateLabel = new Label();
            dateLabel.Text = selectedDate.ToString("MMMM dd, yyyy");
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;
            dateLabel.Font = new Font("Bahnschrift SemiCondensed", 28, FontStyle.Bold);
            dateLabel.Width = flowLayoutPanel2.ClientSize.Width;
            dateLabel.Height = 50;
            flowLayoutPanel2.Controls.Add(dateLabel);

            int columnWidth = flowLayoutPanel2.ClientSize.Width / 3;

            Label amLabel = new Label();
            amLabel.Text = "AM";
            amLabel.TextAlign = ContentAlignment.MiddleCenter;
            amLabel.Font = new Font("Bahnschrift SemiCondensed", 26, FontStyle.Bold);
            amLabel.Width = columnWidth;
            amLabel.Height = 50;
            amLabel.AutoSize = false;
            flowLayoutPanel2.Controls.Add(amLabel);

            Label emptyLabel1 = new Label();
            emptyLabel1.Text = "";
            emptyLabel1.TextAlign = ContentAlignment.MiddleCenter;
            emptyLabel1.Width = columnWidth;
            emptyLabel1.Height = 50;
            emptyLabel1.AutoSize = false;
            flowLayoutPanel2.Controls.Add(emptyLabel1);

            for (int hour = 8; hour <= 12; hour++)
            {
                Label timeLabel = new Label();
                timeLabel.Text = $"{hour}:00";
                timeLabel.TextAlign = ContentAlignment.MiddleCenter;
                timeLabel.BorderStyle = BorderStyle.FixedSingle;
                timeLabel.Width = columnWidth;
                timeLabel.Height = 50;
                timeLabel.Font = new Font("Bahnschrift SemiCondensed", 26, FontStyle.Regular);
                timeLabel.AutoSize = false;

                timeLabel.MouseEnter += TimeLabel_MouseEnter;
                timeLabel.MouseLeave += TimeLabel_MouseLeave;

                timeLabel.BorderStyle = BorderStyle.Fixed3D;

                DateTime timeSlot = selectedDate.AddHours(hour);
                if (!IsDateTimeAvailable(timeSlot))
                {
                    timeLabel.Enabled = false;
                    timeLabel.BackColor = Color.LightGray;
                }

                flowLayoutPanel2.Controls.Add(timeLabel);

                timeLabel.Click += TimeLabel_Click;
            }
            Label emptyLabel3 = new Label();
            emptyLabel3.Text = "";
            emptyLabel3.TextAlign = ContentAlignment.MiddleCenter;
            emptyLabel3.Width = columnWidth;
            emptyLabel3.Height = 50;
            emptyLabel3.AutoSize = false;
            flowLayoutPanel2.Controls.Add(emptyLabel3);

            Label pmLabel = new Label();
            pmLabel.Name = "pmLabel";
            pmLabel.Text = "PM";
            pmLabel.TextAlign = ContentAlignment.MiddleCenter;
            pmLabel.Font = new Font("Bahnschrift SemiCondensed", 26, FontStyle.Bold);
            pmLabel.Width = columnWidth;
            pmLabel.Height = 50;
            pmLabel.AutoSize = false;
            flowLayoutPanel2.Controls.Add(pmLabel);

            Label emptyLabel2 = new Label();
            emptyLabel2.Text = "";
            emptyLabel2.TextAlign = ContentAlignment.MiddleCenter;
            emptyLabel2.Width = columnWidth;
            emptyLabel2.Height = 50;
            emptyLabel2.AutoSize = false;
            flowLayoutPanel2.Controls.Add(emptyLabel2);

            for (int hour = 1; hour <= 5; hour++)
            {
                Label timeLabel = new Label();
                timeLabel.Text = $"{hour}:00";
                timeLabel.TextAlign = ContentAlignment.MiddleCenter;
                timeLabel.BorderStyle = BorderStyle.FixedSingle;
                timeLabel.Width = columnWidth;
                timeLabel.Height = 50;
                timeLabel.Font = new Font("Bahnschrift SemiCondensed", 26, FontStyle.Regular);
                timeLabel.AutoSize = false;

                timeLabel.MouseEnter += TimeLabel_MouseEnter;
                timeLabel.MouseLeave += TimeLabel_MouseLeave;

                timeLabel.BorderStyle = BorderStyle.Fixed3D;

                DateTime timeSlot = selectedDate.AddHours(hour + 12); 
                if (!IsDateTimeAvailable(timeSlot))
                {
                    timeLabel.Enabled = false;
                    timeLabel.BackColor = Color.LightGray;
                }

                flowLayoutPanel2.Controls.Add(timeLabel);

                timeLabel.Click += TimeLabel_Click;
            }
        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                Label dateLabel = flowLayoutPanel2.Controls[0] as Label;
                Label pmLabel = flowLayoutPanel2.Controls.Find("pmLabel", true).FirstOrDefault() as Label;

                if (dateLabel != null && pmLabel != null)
                {
                    DateTime selectedDate;
                    if (DateTime.TryParse(dateLabel.Text, out selectedDate))
                    {
                        string selectedTime = clickedLabel.Text;
                        int hour = int.Parse(selectedTime.Split(':')[0]);

                        // Check if the clicked label is in the PM section
                        if (clickedLabel.Location.Y > pmLabel.Location.Y)
                        {
                            // Adjust hour for PM times
                            if (hour < 12) // If it's not noon
                            {
                                hour += 12; // Add 12 hours to convert to PM time
                            }
                        }

                        DateTime selectedDateTime = selectedDate.Date.AddHours(hour);

                        if (IsDateTimeAvailable(selectedDateTime))
                        {
                            F_APPOINTMENT appointmentForm = new F_APPOINTMENT(selectedDateTime);
                            appointmentForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("This time slot is already taken. Please select another one.", "Appointment Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Invalid date format.");
                    }
                }
            }
        }

        private bool IsDateTimeAvailable(DateTime selectedDateTime)
        {
            bool available = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM [WALK-IN-CUSTOMER] WHERE [DATE] = @DateTime";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DateTime", selectedDateTime);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    available = false;
                }
            }

            return available;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            PopulateCalendar();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            PopulateCalendar();
        }
        private void TimeLabel_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Blue;
                label.ForeColor = Color.White;
            }
        }

        private void TimeLabel_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Empty;
                label.ForeColor = Color.Empty;
            }
        }

        private void buttonAPPOINTMENTS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to see the appointments?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                APPOINTMENTS appointments = new APPOINTMENTS(AFirstName, ALastName, AProfilePictureData);
                appointments.Show();

                Form parentForm = this.ParentForm;
                if (parentForm != null)
                {
                    parentForm.Close();
                }
            }
        }
    }

}
