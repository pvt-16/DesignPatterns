using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLID_SingleResponsibility
{
    sealed class HardCodedQuestions
    {
        public Question[] GetQuestions()
        {
            Question[] questions =
            {
            new Question() { Statement="AAA", Option1 = "A1", Option2 = "A2", Option3 = "A3", Option4 = "A4", CorrectAnswer = 1, Marks = 5 },
            new Question() { Statement="BBB", Option1 = "B1", Option2 = "B2", Option3 = "B3", Option4 = "B4", CorrectAnswer = 2, Marks = 6 },
            new Question() { Statement="CCC", Option1 = "C1", Option2 = "C2", Option3 = "C3", Option4 = "C4", CorrectAnswer = 3, Marks = 7 }
        };
            return questions;
        }
    }
}