using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxMainCode
{
    class Program
    {
        public static void Main()
        {
            Stack<double> stk = new Stack<double>();
            stk.Push(100);
            stk.Push(200);

            ListBox<double> list = new ListBox<double>();
            list.AddAtEnd(1000);
            list.AddAtEnd(2000);

            ListBox lb = new ListBox();
            lb.Display(stk);
        }
    }
}
