using System;

class A
{
    public static void Main(string[] args)
    {
        int[] array = new int[] { 2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8, 9 };
        var p = new A();
        int[] biTree;
        p.BuildBITree(array, out biTree);
        foreach (var bi in biTree) Console.Write(bi + "  ");
        Console.WriteLine("\n\nSum till 7 " + p.GetSum(biTree, 7));
        p.UpdateBit(biTree, 3, 10);
        Console.WriteLine("\n\nSum till 7 " + p.GetSum(biTree, 7));
        Console.Read();
    }

    void BuildBITree(int[] array, out int[] biTree)
    {
        biTree = new int[array.Length + 1];
        for (int j = 1; j<= array.Length; j++) biTree[j] = 0;

        for (var i = 0; i < array.Length; i++) UpdateBit(biTree, i, array[i]);
    }

    void UpdateBit(int[] biTree, int i, int val)
    {
        i++;
        while (i < biTree.Length)
        {
            biTree[i] += val;
            i += (i & (-i));
        }
    }

    int GetSum(int[] biTree, int i)
    {
        int sum = 0;
        i++;
        while (i > 0)
        {
            sum += biTree[i];
            i -= (i & (-i));
        }
        return sum;
    }
}
