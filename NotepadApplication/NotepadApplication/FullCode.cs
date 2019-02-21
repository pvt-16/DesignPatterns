//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//using System.Windows.Forms;
//using System.Drawing;
//using System.IO;
//using System;


//// Define an Abstraction to hide various State Implementations behind it.
//// This will help us to change the states at runtime.
//abstract class State
//{
//    protected MainForm mainForm;

//    protected State(MainForm mainForm)
//    {
//        this.mainForm = mainForm;
//    }

//    // Implement Close functionality that is common to all the states 
//    // Making call to the OnClose() in one step that is handled by the Sub-Class
//    public bool Close()
//    {
//        // If new text is typed in TextBox
//        if (mainForm.HasTextChanged)
//        {
//            // Show the prompt
//            DialogResult messageBoxResult = MessageBox.Show("Do you want to Save?", "Notepad", MessageBoxButtons.YesNoCancel);

//            // Implement Cancel, No, and Yes clicks in the prompt
//            if (messageBoxResult == DialogResult.Cancel)
//            {
//                return true; // Do not close Notepad
//            }
//            else if (messageBoxResult == DialogResult.No)
//            {
//                return false; // Close Notepad
//            }
//            else // if (messageBoxResult == DialogResult.Yes)
//            {
//                // Delegating the call to the Sub-Class or Derived Class
//                return this.OnClose();
//            }
//        }
//        else // If new text is not typed in TextBox
//        {
//            return false; // Close the Notepad 
//        }
//    }

//    public abstract bool OnClose();
//}

//// Create the New File State Implementation
//class NewFileState : State
//{
//    public NewFileState(MainForm mainForm) : base(mainForm)
//    {

//    }

//    public override bool OnClose()
//    {
//        SaveFileDialog saveFileDialog = new SaveFileDialog();
//        DialogResult dialogResult = saveFileDialog.ShowDialog();

//        // Implement Cancel, and Save clicks in the file dialog
//        if (dialogResult == DialogResult.Cancel)
//        {
//            return true; // Do not close Notepad
//        }
//        else // if (dialogResult == DialogResult.OK)
//        {
//            // overwrite the existing file with the new text
//            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
//            {
//                string text = mainForm.GetText(); // Obtain the TextBox text
//                writer.WriteLine(text); // Write the text to the file
//            } // close the file

//            mainForm.SetExistingFileState(saveFileDialog.FileName);

//            return false;
//        }
//    }
//}


//// Create the Existing File State Implementation
//class ExistingFileState : State
//{
//    public ExistingFileState(MainForm mainForm) : base(mainForm)
//    {

//    }

//    public override bool OnClose()
//    {
//        // overwrite the existing file with the new text
//        using (StreamWriter writer = new StreamWriter(mainForm.FilePath))
//        {
//            string text = mainForm.GetText(); // Obtain the TextBox text
//            writer.WriteLine(text); // Write the text to the file
//        } // close the file

//        return false;
//    }
//}

//// -------------------------------------------------------------------------------------------------

//class MainForm : Form
//{
//    private TextBox inputTxt; // reference variable to refer to the TextBox object

//    // All State Class Reference Variables
//    private NewFileState newFileState;
//    private ExistingFileState existingFileState;
//    private State state;

//    public string FilePath { get; set; }

//    // Constructor
//    public MainForm()
//    {
//        // All State Class Objects
//        this.newFileState = new NewFileState(this);
//        this.existingFileState = new ExistingFileState(this);

//        // Make the New File State as the Initial State
//        this.SetNewFileState();

//        // Set the title of the form
//        this.Text = "Notepad";

//        // Set the size of the form
//        this.Size = new Size(600, 400);

//        this.inputTxt = new TextBox();

//        // Positioning the TextBox
//        this.inputTxt.Location = new Point(10, 10);

//        // Make the TextBox cover the full window
//        this.inputTxt.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 20);

//        // Allow user to hit enter and go to next line 
//        this.inputTxt.Multiline = true;

//        // Facilitate the TextBox to resize when window is resized
//        this.inputTxt.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

//        // Make the textbox child of the window
//        this.Controls.Add(this.inputTxt);

//        HasTextChanged = false;

//        // Register Event Handler to know when new text is typed in TextBox
//        this.inputTxt.TextChanged += InputTxt_TextChanged;
//    }

//    public void SetExistingFileState(string filepath)
//    {
//        this.FilePath = filepath;

//        SetFormTitle(this.FilePath);

//        this.state = existingFileState;
//    }

//    public void SetNewFileState()
//    {
//        this.state = newFileState;
//    }

//    // Property to keep track whether new text is typed in TextBox
//    public bool HasTextChanged { get; set; }

//    // Event Handler called when new text is typed in TextBox
//    private void InputTxt_TextChanged(object sender, System.EventArgs e)
//    {
//        HasTextChanged = true;
//    }

//    // Helper method to obtain text typed in TextBox
//    public string GetText()
//    {
//        return this.inputTxt.Text;
//    }

//    // Helper method to set the Window Title
//    public void SetFormTitle(string text)
//    {
//        this.Text = text;
//    }

//    // This method is called when user clicks the close button
//    protected override void OnFormClosing(FormClosingEventArgs e)
//    {
//        e.Cancel = state.Close();
//    }
//}

////class Program
////{
////    // C# compiler marks the Main as the entry point 
////    // When EXE is executed CLR calls Main as the first function
////    [STAThread]
////    public static void Main()
////    {
////        MainForm mainForm = new MainForm();
////        mainForm.ShowDialog();
////    }
////}

