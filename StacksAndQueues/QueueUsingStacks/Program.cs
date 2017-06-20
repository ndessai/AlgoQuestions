//implement queue using two stacks

using System;
using System.Collections.Generic;

public class QueueEx
{
    private Stack<int> _stack1 = new Stack<int>();
    private Stack<int> _stack2 = new Stack<int>();

    public void Enqueue(int val)
    {
        _stack1.Push(val);
    }

    public int Count()
    {
        return _stack1.Count + _stack2.Count;
    }

    public int Dequeue()
    {
        if (_stack2.Count <= 0)
        {
            while (_stack1.Count != 0)
            {
                _stack2.Push(_stack1.Pop());
            }
        }
        return _stack2.Pop();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var queue = new QueueEx();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        Console.WriteLine(queue.Dequeue());
        queue.Enqueue(6);
        queue.Enqueue(7);
        Console.WriteLine(queue.Dequeue());
        Console.Read();
    }
}
