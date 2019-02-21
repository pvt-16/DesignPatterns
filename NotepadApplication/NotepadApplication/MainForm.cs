using System.Windows.Forms;
using System.Drawing;
using System.IO;

class MainForm : Form
{
    private TextBox inputTxt;
    private OpenFileDialog ofd;
    private Button btn;
    public bool HasTextChanged { get; set; }

    // All State Class Reference Variables
    private NewFileState newFileState;
    private ExistingFileState existingFileState;
    private State state;

    public string FilePath { get; set; }
    public MainForm()
    {
        // All State Class Objects
        this.newFileState = new NewFileState(this);
        this.existingFileState = new ExistingFileState(this);

        // Make the New File State as the Initial State
        this.SetNewFileState();

        this.Text = "Notepad";
        this.Size = new Size(600, 400);
        this.inputTxt = new TextBox();
        this.inputTxt.Location = new Point(10, 50);
        this.inputTxt.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 60);

        btn = new Button();
        btn.Location = new Point(10, 10);
        btn.Text = "Open";

        // Allow user to hit enter and go to next line 
        this.inputTxt.Multiline = true;

        // Facilitate the TextBox to resize when window is resized
        this.inputTxt.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

        // Make the textbox child of the window
        this.Controls.Add(this.inputTxt);
        this.Controls.Add(this.btn);

        HasTextChanged = false;
        this.inputTxt.TextChanged += InputTxt_TextChanged;
        this.btn.Click += btnOpen_Click;
    }

    public void SetExistingFileState(string filepath)
    {
        this.FilePath = filepath;
        SetFormTitle(this.FilePath);
        this.state = existingFileState;
    }

    public void SetNewFileState()
    {
        this.state = newFileState;
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        e.Cancel = state.Close();
        //if (HasTextChanged) // If new text is typed in TextBox
        //{
        //    // Show the prompt
        //    DialogResult messageBoxResult = MessageBox.Show("Do you want to Save?", "Notepad", MessageBoxButtons.YesNoCancel);

        //    // Implement Cancel, No, and Yes clicks in the prompt
        //    if (messageBoxResult == DialogResult.Cancel)
        //    {
        //        e.Cancel = true; // Do not close Notepad
        //    }
        //    else if (messageBoxResult == DialogResult.No)
        //    {
        //        e.Cancel = false; // Close Notepad
        //    }
        //    else if (messageBoxResult == DialogResult.Yes)
        //    {
        //        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //        DialogResult dialogResult = saveFileDialog.ShowDialog();

        //        // Implement Cancel, and Save clicks in the file dialog
        //        if (dialogResult == DialogResult.Cancel)
        //        {
        //            e.Cancel = true; // Do not close Notepad
        //        }
        //        else if (dialogResult == DialogResult.OK)
        //        {
        //            // Create new file if file doesn't exists 
        //            // or
        //            // overwrite the existing file with the new text
        //            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
        //            {
        //                string text = GetText(); // Obtain the TextBox text
        //                writer.WriteLine(text); // Write the text to the file
        //            } // close the file

        //            e.Cancel = true; // Do not close Notepad

        //            SetFormTitle(saveFileDialog.FileName); // Set filepath as the title

        //            HasTextChanged = false; // Text already saved
        //        }
        //    }
        //}
        //else // If new text is not typed in TextBox
        //{
        //    e.Cancel = false; // Close the Notepad 
        //}
    }
    private void InputTxt_TextChanged(object sender, System.EventArgs e)
    {
        HasTextChanged = true;
    }
    public string GetText()
    {
        return this.inputTxt.Text;
    }
    public void SetFormTitle(string text)
    {
        this.Text = text;
    }

    private void btnOpen_Click(object sender, System.EventArgs e)
    {
        ofd = new OpenFileDialog();
        //ofd.OpenFile();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            StreamReader sr = new StreamReader(ofd.FileName);
            this.inputTxt.Text= sr.ReadToEnd();
            string text = sr.ReadToEnd(); // Obtain the TextBox text
            sr.Close();
            this.SetExistingFileState(ofd.FileName);
        }
    }

}