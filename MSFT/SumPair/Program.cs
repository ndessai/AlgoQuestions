using System;
using System.Collections.Generic;

class A
{
    public static void Main(string[] args)
    {
        int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var p = new A();
        p.PrintSumPair(a, 14);
        Console.Read();
    }

    private void PrintSumPair(int[] a, int sum)
    {
        HashSet<int> hashSet = new HashSet<int>();
        foreach (var item in a)
        {
            int diff = sum - item;
            if (hashSet.Contains(diff)){
                Console.WriteLine("Found " + item + " " + (sum - item));
                return;
            }
            hashSet.Add(item);
        }
        Console.WriteLine("Not found");
    }
}
