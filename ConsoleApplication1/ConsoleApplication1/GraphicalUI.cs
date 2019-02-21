using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ConsoleApplication1
{

    // Input and Output (Presentation Layer) - in a separate class
    sealed class GraphicalUI : Form
    {
        // Create UI Controls to display data 
        Label StatementLbl = new Label();
        RadioButton Option1RB = new RadioButton();
        RadioButton Option2RB = new RadioButton();
        RadioButton Option3RB = new RadioButton();
        RadioButton Option4RB = new RadioButton();
        Button NextBtn = new Button();

        TestLogic tl = new TestLogic();

        public GraphicalUI()
        {
            NextBtn.Text = "Next";
            NextBtn.Click += OnNextClicked; // event handler for the next button

            // Set the location of UI controls
            StatementLbl.Location = new Point(10, 10);
            Option1RB.Location = new Point(10, 50);
            Option2RB.Location = new Point(10, 90);
            Option3RB.Location = new Point(10, 130);
            Option4RB.Location = new Point(10, 170);
            NextBtn.Location = new Point(10, 210);

            // Make UI controls become children on the main form
            Controls.Add(StatementLbl);
            Controls.Add(Option1RB);
            Controls.Add(Option2RB);
            Controls.Add(Option3RB);
            Controls.Add(Option4RB);
            Controls.Add(NextBtn);

            // Display the first question
            DisplayNextQuestion();
        }

        private void DisplayNextQuestion()
        {
            // Obtain next question
            Question question = tl.NextQuestion();

            if (question != null)
            {
                // Display data in UI
                StatementLbl.Text = question.Statement;
                Option1RB.Text = question.Option1;
                Option2RB.Text = question.Option2;
                Option3RB.Text = question.Option3;
                Option4RB.Text = question.Option4;
            }
            else
                TestOver(); // when no questions are left to be displayed
        }

        // Display result
        private void TestOver()
        {
            NextBtn.Enabled = false;
            MessageBox.Show($"You obtained ${ tl.UserMarks} out of ${ tl.TotalMarks}");
        }

        // Obtain user's choice from radio buttons
        private int GetUserOption()
        {
            int choice = 0;
            if (Option1RB.Checked)
                choice = 1;
            else if (Option2RB.Checked)
                choice = 2;
            else if (Option3RB.Checked)
                choice = 3;
            else if (Option4RB.Checked)
                choice = 4;
            return choice;
        }

        // Called when Next button is clicked
        private void OnNextClicked(object sender, EventArgs e)
        {
            int choice = GetUserOption();
            tl.CheckAnswer(choice);
            DisplayNextQuestion();
        }

        public new void Show()
        {
            // Display the GUI and Start the Event Loop
            ShowDialog();
        }
    }
}
