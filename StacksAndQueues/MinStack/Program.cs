//stack with min O(1) support

using System;
using System.Collections.Generic;

public class StackEx : Stack<int>
{
    private Stack<int> _minStack = new Stack<int>();

    public new void Push(int val)
    {
        if (_minStack.Count <= 0 || _minStack.Peek() > val)
        {
            _minStack.Push(val);
        }
        base.Push(val);
    }

    public new int Pop()
    {
        int val = base.Pop();
        if (val == _minStack.Peek())
        {
            _minStack.Pop();
        }
        return val;
    }

    public int Min()
    {
        return _minStack.Peek();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var stack = new StackEx();
        stack.Push(10);
        stack.Push(20);
        Console.WriteLine(stack.Min());

        stack.Push(5);
        Console.WriteLine(stack.Min());
        stack.Pop();
        Console.WriteLine(stack.Min());
        stack.Push(2);
        Console.WriteLine(stack.Min());
        Console.Read();
    }
}
