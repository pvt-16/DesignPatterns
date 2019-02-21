using System;
using System.Collections;
using System.Collections.Generic;

class Stack<T> : IEnumerable<T>
{
    // factory method – to create enumerator class object
    public IEnumerator<T> GetEnumerator()
    {
        // Enumerator class object
        return new StackEnumerator(this);
    }

    // This is for backward compatibility with .NET Framework 1.0 and 1.1, hence we will not implement it
    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // Enumerator class
    private class StackEnumerator : IEnumerator<T>
    {
        private Stack<T> stk;
        private int index = 0;

        public StackEnumerator(Stack<T> stk)
        {
            this.stk = stk;
        }

        public bool MoveNext()
        {
            return (index++ < stk.top);
        }

        public T Current
        {
            get
            {
                return stk.items[index - 1];
            }
        }

        // This is for backward compatibility with .NET Framework 1.0 and 1.1, hence we will not implement it
        object IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }


        // This method can be called by the client the enumerator object to start from the beginning
        public void Reset()
        {
            index = 0;
        }

        // If the enumerator object holds an unmanaged resource like file, this method can be used to release the resource
        // The client should always call the method at the end of enumeration to tell enumerator object to release the resource
        // Our enumerator object is not holding any unmanaged resource, hence we need not implement anything in it.
        public void Dispose()
        {
        }

    }

    private T[] items = new T[100];
    private int top = 0;

    public void Push(T item)
    {
        items[top] = item;
        top++;
    }
    public T Pop()
    {
        top--;
        return items[top];
    }
}

class ListBox
{
    public void Display<T>(IEnumerable<T> collection)
    {
        // obtain the enumerator class object
        IEnumerator<T> enumerator = collection.GetEnumerator();
        try
        {
            // Traverse the collection with the help of enumerator class object
            while (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                Console.WriteLine(item);
            }
        }
        finally
        {
            enumerator.Dispose();
        }
    }
}

class Program
{
    public static void Main()
    {
        Stack<double> stk = new Stack<double>();
        stk.Push(100);
        stk.Push(200);

        ListBox lb = new ListBox();
        lb.Display(stk);

        Console.ReadLine();
    }
}
