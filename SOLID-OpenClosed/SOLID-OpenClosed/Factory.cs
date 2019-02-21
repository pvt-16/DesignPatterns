using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_OpenClosed
{
    // Factory deals with Implementation Classes and create Implementation objects
    static class Factory
    {
        public static ITestLogic GetLogic()
        {
            return new TestLogic1();
        }

        public static IUI GetUI()
        {
            return new ConsoleUI();
        }
    }
}
