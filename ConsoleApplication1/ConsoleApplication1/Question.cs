using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApplication1
{
    // Data entity class
    sealed class Question
    {
        public string Statement { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int CorrectAnswer { get; set; }
        public int Marks { get; set; }
    }
}