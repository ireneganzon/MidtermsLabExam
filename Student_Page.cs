using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MidtermsLabExam
{
    public partial class Student_Page : Form
    {
        public Student_Page()
        {
            InitializeComponent();
            LoadStudentRecords(); 
        }

        
        private void LoadStudentRecords()
        {
            try
            {
                using (MySqlConnection conn = GetDatabaseConnection())
                {
                    conn.Open();
                    string query = "SELECT studentId, CONCAT(firstName, ' ', lastName) AS fullName FROM StudentRecordTB";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int yOffset = 20; // Y-position for dynamic controls

                    while (reader.Read())
                    {
                        string studentName = reader.GetString("fullName");
                        int studentId = reader.GetInt32("studentId");

                        Label studentLabel = new Label
                        {
                            Text = studentName,
                            Left = 20,
                            Top = yOffset,
                            Width = 200
                        };
                        this.Controls.Add(studentLabel);

                        
                        Button viewButton = new Button
                        {
                            Text = "VIEW",
                            Left = 230,
                            Top = yOffset - 5, // Align with label
                            Width = 80,
                            Tag = new Tuple<string, int>(studentName, studentId) 
                        };

                        viewButton.Click += ViewButton_Click;
                        this.Controls.Add(viewButton);

                        yOffset += 40; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student records: " + ex.Message);
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            Button viewButton = sender as Button;
            var data = (Tuple<string, int>)viewButton.Tag;
            string studentName = data.Item1;
            int studentId = data.Item2;

            StudentPage_Individual individualPage = new StudentPage_Individual(studentName, studentId);
            individualPage.ShowDialog();
        }

        private MySqlConnection GetDatabaseConnection()
        {
            string connectionString = "Server=localhost;Database=StudentInfoDB;Uid=root;Pwd=GanzonGUI080123;";
            return new MySqlConnection(connectionString);
        }

        private void InitializeComponent()
        {
            this.Text = "Student Page";
            this.ClientSize = new System.Drawing.Size(400, 500);
        }
    }
}
