using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApplication1
{
    // Business Logic (Business Logic Layer) in a separate class
    sealed class TestLogic
    {
        Question[] questions;
        int index = 0, userMarks = 0;

        public TestLogic()
        {
            // Obtain questions from data access layer
            HardCodedQuestions hcq = new HardCodedQuestions();
            questions = hcq.GetQuestions();
        }

        // Method to supply one question at a time to the UI code
        public Question NextQuestion()
        {
            if (index < questions.Length)
                return questions[index++];
            else
                return null;
        }

        // Helps in comparing user's choice with correct answer
        public void CheckAnswer(int userOption)
        {
            if (userOption == questions[index - 1].CorrectAnswer)
                userMarks += questions[index - 1].Marks;
        }

        // Helps UI to obtain user's marks
        public int UserMarks { get { return userMarks; } }

        // Helps UI to obtain total marks
        public int TotalMarks { get { return (from question in questions select question.Marks).Sum(); } }

    }
}