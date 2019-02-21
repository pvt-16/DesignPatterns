using System;
using System.Linq;

class SubCommand : ICommand
{
    public bool Process(string input, ref double data)
    {
        string[] items = input.Split(' ');

        if (items[0] == "subtract")
        {
            data -= Convert.ToDouble(items[1]);
            return true;
        }

        return false;
    }
}

class DivideCommand : ICommand
{
    public bool Process(string input, ref double data)
    {
        string[] items = input.Split(' ');

        if (items[0] == "divide")
        {
            data /= Convert.ToDouble(items[1]);
            return true;
        }

        return false;
    }
}