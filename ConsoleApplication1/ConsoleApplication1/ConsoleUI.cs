using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApplication1
{
    // Input and Output (Presentation Layer) - in a separate class
    sealed class ConsoleUI
    {
        public void Show()
        {
            TestLogic tl = new TestLogic();

            while (true)
            {
                // obtain one question at a time
                Question question = tl.NextQuestion();

                // break the loop when no questions are left
                if (question == null) break;

                // display question to the user
                Console.WriteLine($"Q: {question.Statement}");
                Console.WriteLine($"1: { question.Option1}");
                Console.WriteLine($"2: { question.Option2}");
                Console.WriteLine($"3: { question.Option3}");
                Console.WriteLine($"4: { question.Option4}");

                // Accept user's choice
                Console.Write("Select an Option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                // Get user's choice compared to correct answer and get user's marks incremented
                tl.CheckAnswer(choice);
            }

            // Display result
            Console.WriteLine($"You obtained ${ tl.UserMarks} out of ${ tl.TotalMarks}");
        }
    }
}