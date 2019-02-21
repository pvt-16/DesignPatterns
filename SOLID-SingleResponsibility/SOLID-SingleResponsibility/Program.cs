using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLID_SingleResponsibility
{
    // Initiate the working of application
    sealed class Program
    {
        public static void Main()
        {
            // Display UI
            ConsoleUI cui = new ConsoleUI();
            cui.Show();

            GraphicalUI gui = new GraphicalUI();
            gui.Show();

            Console.ReadLine();
        }
    }
}