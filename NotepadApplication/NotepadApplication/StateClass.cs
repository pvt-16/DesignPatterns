// Define an Abstraction to hide various State Implementations behind it.
// This will help us to change the states at runtime.
using System.Windows.Forms;

abstract class State
{
    protected MainForm mainForm;

    protected State(MainForm mainForm)
    {
        this.mainForm = mainForm;
    }

    // Implement Close functionality that is common to all the states 
    // Making call to the OnClose() in one step that is handled by the Sub-Class
    public bool Close()
    {
        // If new text is typed in TextBox
        if (mainForm.HasTextChanged)
        {
            // Show the prompt
            DialogResult messageBoxResult = MessageBox.Show("Do you want to Save?", "Notepad", MessageBoxButtons.YesNoCancel);

            // Implement Cancel, No, and Yes clicks in the prompt
            if (messageBoxResult == DialogResult.Cancel)
            {
                return true; // Do not close Notepad
            }
            else if (messageBoxResult == DialogResult.No)
            {
                return false; // Close Notepad
            }
            else // if (messageBoxResult == DialogResult.Yes)
            {
                // Delegating the call to the Sub-Class or Derived Class
                return this.OnClose();
            }
        }
        else // If new text is not typed in TextBox
        {
            return false; // Close the Notepad 
        }
    }

    public abstract bool OnClose();
}

