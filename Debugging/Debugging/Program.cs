
using System;
using System.Threading;

public class TestClass
{
    static int count = 0;

    public static void Method1()
    {
        int data = count++;
        Thread.Sleep(3000);
        Console.WriteLine("Method1");
    }
}

public class Program
{
    public static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateThreads(i);
        }
    }

    public static void CreateThreads(int i)
    {
        Thread thread = new Thread(new ThreadStart(TestClass.Method1));

        thread.Name = "Thread - " + i;

        thread.Start();
    }
}

