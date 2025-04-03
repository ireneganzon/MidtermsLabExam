using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

class Program
{
    [STAThread] // Required for Windows Forms applications
    static void Main()
    {
        // Debug message to confirm execution
        Console.WriteLine("Launching Student_Page...");

        // Ensure the application runs in a Windows Forms environment
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Open the Student_Page form
        Application.Run(new MidtermsLabExam.Student_Page());
    }
}
