using System;
using System.Drawing;
using System.Windows.Forms;

class Program
{
    // C# compiler marks the Main as the entry point 
    // When EXE is executed CLR calls Main as the first function
    [STAThread] // This is required to display FileSave Dialog
    public static void Main()
    {
        // Create new Form object to create a window
        MainForm mainForm = new MainForm();

        //mainForm.Text = "Notepad";
        //mainForm.Size = new Size(600, 400);

        // Start the message loop to handle user input 
        mainForm.ShowDialog();
    }
}
