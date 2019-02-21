
// Create the New File State Implementation
using System.IO;
using System.Windows.Forms;

class NewFileState : State
{
    public NewFileState(MainForm mainForm) : base(mainForm)
    {

    }

    public override bool OnClose()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        DialogResult dialogResult = saveFileDialog.ShowDialog();

        // Implement Cancel, and Save clicks in the file dialog
        if (dialogResult == DialogResult.Cancel)
        {
            return true; // Do not close Notepad
        }
        else // if (dialogResult == DialogResult.OK)
        {
            // overwrite the existing file with the new text
            using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
            {
                string text = mainForm.GetText(); // Obtain the TextBox text
                writer.WriteLine(text); // Write the text to the file
            } // close the file

            mainForm.SetExistingFileState(saveFileDialog.FileName);

            return true;
        }
    }
}

// Create the Existing File State Implementation
class ExistingFileState : State
{
    public ExistingFileState(MainForm mainForm) : base(mainForm)
    {

    }

    public override bool OnClose()
    {
        // overwrite the existing file with the new text
        using (StreamWriter writer = new StreamWriter(mainForm.FilePath))
        {
            string text = mainForm.GetText(); // Obtain the TextBox text
            writer.WriteLine(text); // Write the text to the file
        } // close the file

        return false;
    }
}

