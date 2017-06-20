//SetOfStacks using stacks

using System;
using System.Collections.Generic;

public class SetOfStacks
{
    private List<Stack<int>> _sets = new List<Stack<int>>();
    private int _threshold;

    public SetOfStacks(int threshold = 10)
    {
        _threshold = threshold;
    }

    public void Push(int val)
    {
        if (_sets.Count <= 0 || _sets[_sets.Count - 1].Count >= _threshold)
        {
            _sets.Add(new Stack<int>());
        }
        _sets[_sets.Count - 1].Push(val);
    }

    public int Pop()
    {
        var val = _sets[_sets.Count - 1].Pop();
        if (_sets[_sets.Count - 1].Count == 0)
        {
            _sets.Remove(_sets[_sets.Count - 1]);
        }
        return val;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var setOfStacks = new SetOfStacks(2);
        setOfStacks.Push(1);
        setOfStacks.Push(2);
        setOfStacks.Push(3);
        Console.WriteLine(setOfStacks.Pop());
        Console.WriteLine(setOfStacks.Pop());

        setOfStacks.Push(4);
        setOfStacks.Push(5);
        setOfStacks.Push(6);
        Console.Read();
    }
}
