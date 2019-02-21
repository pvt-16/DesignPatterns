using System;

namespace SOLID_OpenClosed
{
    // Initiate the working of application
    sealed class Program
    {
        public static void Main()
        {
            // Display UI
            //ConsoleUI cui = new ConsoleUI();
            //cui.Show();

           // GraphicalUI gui = new GraphicalUI();
           // gui.Show();

            ITestLogic tl = Factory.GetLogic();
            IUI cui = Factory.GetUI();
            cui.Show(tl);

            Console.ReadLine();
        }
    }
}