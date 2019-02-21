using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_OpenClosed
{
    // Abstraction to hide logic implementations 
    interface ITestLogic
    {
        Question NextQuestion();
        void CheckAnswer(int userOption);
        int UserMarks { get; }
        int TotalMarks { get; }
    }

    // Abstraction to hide UI implementations
    interface IUI
    {
        void Show(ITestLogic tl);
    }

    interface IQuestion
    {
        
    }

    interface IQuestions
    {
        IQuestion[] GetQuestions();
    }
}
