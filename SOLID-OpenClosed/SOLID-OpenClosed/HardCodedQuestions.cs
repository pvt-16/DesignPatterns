using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLID_OpenClosed
{
    sealed class HardCodedQuestions : IQuestions
    {
        public IQuestion[] GetQuestions()
        {
            IQuestion[] questions =
            {
            new IQuestion() { Statement="AAA", Option1 = "A1", Option2 = "A2", Option3 = "A3", Option4 = "A4", CorrectAnswer = 1, Marks = 5 },
            new IQuestion() { Statement="BBB", Option1 = "B1", Option2 = "B2", Option3 = "B3", Option4 = "B4", CorrectAnswer = 2, Marks = 6 },
            new IQuestion() { Statement="CCC", Option1 = "C1", Option2 = "C2", Option3 = "C3", Option4 = "C4", CorrectAnswer = 3, Marks = 7 }
        };
            return questions;
        }
    }
}