//using an array to implment three stacks

using System;

public class Program
{
    public static void Main(string[] args)
    {
        var stack = new StackEx(10);
        stack.Push(0, 10);
        stack.Push(0, 11);
        stack.Push(0, 12);
        stack.Push(1, 100);
        stack.Push(1, 200);
        stack.Push(2, 1000);

        Console.WriteLine(stack.IsEmpty(0));
        Console.WriteLine(stack.IsEmpty(1));
        Console.WriteLine(stack.IsEmpty(2));

        Console.WriteLine(stack.Peek(0));
        Console.WriteLine(stack.Pop(0));
        Console.WriteLine(stack.Pop(1));
        Console.WriteLine(stack.Pop(2));
        Console.WriteLine(stack.IsEmpty(0));
        Console.WriteLine(stack.IsEmpty(1));
        Console.WriteLine(stack.IsEmpty(2));

        Console.WriteLine(stack.Pop(0));
        Console.WriteLine(stack.Pop(1));

        Console.WriteLine(stack.IsEmpty(0));
        Console.WriteLine(stack.IsEmpty(1));
        Console.WriteLine(stack.IsEmpty(2));

        Console.Read();
    }
}

public class StackNode
{
    public int PrevIndex { get; set; }
    public int Value { get; set; }

    public StackNode(int prevIndex, int val)
    {
        PrevIndex = prevIndex;
        Value = val;
    }
}

public class StackEx
{
    private int _stackSize;
    private int _currentIndex = 0;
    private int[] _stackHeads = new int[] { -1, -1, -1 };
    private StackNode[] _array;

    public StackEx(int stackSize)
    {
        _stackSize = stackSize;
        _array = new StackNode[stackSize * 3];
    }

    public void Push(int stackId, int value)
    {
        int prevIndex = _stackHeads[stackId];
        var node = new StackNode(prevIndex, value);
        _array[_currentIndex] = node;
        _stackHeads[stackId] = _currentIndex;
        _currentIndex++;
    }

    public int Pop(int stackId)
    {
        var node = _array[_stackHeads[stackId]];
        _stackHeads[stackId] = node.PrevIndex;
        int val = node.Value;
        return node.Value;
    }

    public int Peek(int stackId)
    {
        return _array[_stackHeads[stackId]].Value;
    }

    public bool IsEmpty(int stackId)
    {
        return _stackHeads[stackId] == -1;
    }
}
