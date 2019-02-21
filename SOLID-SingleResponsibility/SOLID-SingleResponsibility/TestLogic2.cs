using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLID_SingleResponsibility
{

    // Business Logic (Business Logic Layer) - in a separate class
    sealed class TestLogic2
    {
        Question[] questions;

        int index = 0, userMarks = 0;

        // Helps in storing unique numbers
        HashSet<int> indexes = new HashSet<int>();

        Random random;

        public TestLogic2()
        {
            random = new Random(DateTime.Now.Millisecond);
            HardCodedQuestions hcq = new HardCodedQuestions();
            questions = hcq.GetQuestions();
        }

        private int GetNewRandonIndex()
        {
            // Run until unique number is found
            while (true)
            {
                int randomIndex = random.Next(0, questions.Count());
                if (indexes.Add(randomIndex))
                {
                    return randomIndex;
                }
            }
        }

        // Method to supply one question at a time to the UI code
        public Question NextQuestion()
        {
            if (indexes.Count < questions.Length)
            {
                index = GetNewRandonIndex();
                return questions[index];
            }
            else
                return null;
        }

        // Helps in comparing user's choice with correct answer
        public void CheckAnswer(int userOption)
        {
            if (userOption == questions[index].CorrectAnswer)
                userMarks += questions[index].Marks;
        }

        public int UserMarks { get { return userMarks; } }

        public int TotalMarks { get { return (from question in questions select question.Marks).Sum(); } }
    }



}