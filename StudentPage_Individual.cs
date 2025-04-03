using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MidtermsLabExam
{
    public partial class StudentPage_Individual : Form
    {
        private int studentId;

        public StudentPage_Individual(string studentName, int studentId)
        {
            InitializeComponent();

            // Store student ID for further queries if needed
            this.studentId = studentId;

            // Display student info
            studentNameLabel.Text = "Student Name: " + studentName;
            studentIdLabel.Text = "Student ID: " + studentId.ToString();

            // Load additional student details from the database
            LoadStudentDetails(studentId);
        }

        private void LoadStudentDetails(int studentId)
        {
            try
            {
                using (MySqlConnection conn = GetDatabaseConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT firstName, lastName, middleName, houseNo, brgyName, municipality, 
                               province, region, country, birthdate, age, studContactNo, emailAddress, 
                               guardianFirstName, guardianLastName, hobbies, nickname, 
                               c.courseName, y.yearLvl
                        FROM StudentRecordTB s
                        JOIN CourseTB c ON s.courseId = c.courseId
                        JOIN YearTB y ON s.yearId = y.yearId
                        WHERE s.studentId = @studentId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        studentNameLabel.Text = $"Student Name: {reader["firstName"]} {reader["middleName"]} {reader["lastName"]}";
                        studentIdLabel.Text = $"Student ID: {studentId}";
                        studentEmailLabel.Text = $"Email: {reader["emailAddress"]}";
                        studentPhoneLabel.Text = $"Phone: {reader["studContactNo"]}";
                        studentAddressLabel.Text = $"Address: {reader["houseNo"]} {reader["brgyName"]}, {reader["municipality"]}, {reader["province"]}, {reader["region"]}, {reader["country"]}";
                        studentCourseLabel.Text = $"Course: {reader["courseName"]}";
                        studentYearLabel.Text = $"Year: {reader["yearLvl"]}";
                        studentGuardianLabel.Text = $"Guardian: {reader["guardianFirstName"]} {reader["guardianLastName"]}";
                        studentHobbiesLabel.Text = $"Hobbies: {reader["hobbies"]}";
                        studentNicknameLabel.Text = $"Nickname: {reader["nickname"]}";

                    }
                    else
                    {
                        MessageBox.Show("No student found with ID: " + studentId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student details: " + ex.Message);
            }
        }

        private MySqlConnection GetDatabaseConnection()
        {
            string connectionString = "Server=localhost;Database=StudentInfoDB;Uid=root;Pwd=GanzonGUI080123;"; 
            return new MySqlConnection(connectionString);
        }

        private void InitializeComponent()
        {
            this.studentNameLabel = new Label();
            this.studentIdLabel = new Label();
            this.studentEmailLabel = new Label();
            this.studentPhoneLabel = new Label();
            this.studentAddressLabel = new Label();
            this.studentCourseLabel = new Label();
            this.studentYearLabel = new Label();
            this.studentGuardianLabel = new Label();
            this.studentHobbiesLabel = new Label();
            this.studentNicknameLabel = new Label();

            this.SuspendLayout();

            // Student Name Label
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.Location = new System.Drawing.Point(30, 30);
            this.studentNameLabel.Text = "Student Name: ";

            // Student ID Label
            this.studentIdLabel.AutoSize = true;
            this.studentIdLabel.Location = new System.Drawing.Point(30, 60);
            this.studentIdLabel.Text = "Student ID: ";

            // Email Label
            this.studentEmailLabel.AutoSize = true;
            this.studentEmailLabel.Location = new System.Drawing.Point(30, 90);
            this.studentEmailLabel.Text = "Email: ";

            // Phone Label
            this.studentPhoneLabel.AutoSize = true;
            this.studentPhoneLabel.Location = new System.Drawing.Point(30, 120);
            this.studentPhoneLabel.Text = "Phone: ";

            // Address Label
            this.studentAddressLabel.AutoSize = true;
            this.studentAddressLabel.Location = new System.Drawing.Point(30, 150);
            this.studentAddressLabel.Text = "Address: ";

            // Course Label
            this.studentCourseLabel.AutoSize = true;
            this.studentCourseLabel.Location = new System.Drawing.Point(30, 180);
            this.studentCourseLabel.Text = "Course: ";

            // Year Label
            this.studentYearLabel.AutoSize = true;
            this.studentYearLabel.Location = new System.Drawing.Point(30, 210);
            this.studentYearLabel.Text = "Year: ";

            // Guardian Label
            this.studentGuardianLabel.AutoSize = true;
            this.studentGuardianLabel.Location = new System.Drawing.Point(30, 240);
            this.studentGuardianLabel.Text = "Guardian: ";

            // Hobbies Label
            this.studentHobbiesLabel.AutoSize = true;
            this.studentHobbiesLabel.Location = new System.Drawing.Point(30, 270);
            this.studentHobbiesLabel.Text = "Hobbies: ";

            // Nickname Label
            this.studentNicknameLabel.AutoSize = true;
            this.studentNicknameLabel.Location = new System.Drawing.Point(30, 300);
            this.studentNicknameLabel.Text = "Nickname: ";

            // Form Properties
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.studentNicknameLabel);
            this.Controls.Add(this.studentHobbiesLabel);
            this.Controls.Add(this.studentGuardianLabel);
            this.Controls.Add(this.studentYearLabel);
            this.Controls.Add(this.studentCourseLabel);
            this.Controls.Add(this.studentAddressLabel);
            this.Controls.Add(this.studentPhoneLabel);
            this.Controls.Add(this.studentEmailLabel);
            this.Controls.Add(this.studentIdLabel);
            this.Controls.Add(this.studentNameLabel);
            this.Name = "StudentPage_Individual";
            this.Text = "Student Info";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label studentNameLabel;
        private Label studentIdLabel;
        private Label studentEmailLabel;
        private Label studentPhoneLabel;
        private Label studentAddressLabel;
        private Label studentCourseLabel;
        private Label studentYearLabel;
        private Label studentGuardianLabel;
        private Label studentHobbiesLabel;
        private Label studentNicknameLabel;
    }
}
