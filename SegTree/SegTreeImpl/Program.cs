using System;

class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        int[] array = new int[] { 1, 3, 5, 7, 9, 11 };
        int[] st;
        p.BuildSegTree(array, out st);
        foreach (var item in st) { Console.Write(" " + item); }
        Console.WriteLine("Sum-> 2-4 ->" + p.GetSum(st, array.Length - 1, 2, 4));
        p.UpdateVal(array, st, 17, 3);
        Console.WriteLine("Sum-> 2-4 ->" + p.GetSum(st, array.Length - 1, 2, 4));
        Console.Read();
    }

    private void UpdateVal(int[] array, int[] st, int val, int index)
    {
        if (index < 0 || index > array.Length - 1) { throw new Exception("Wrong"); }
        int diff = val - array[index];
        array[index] = val;
        UpdateValUtil(st, 0, array.Length - 1, diff, 0, index);
    }

    private void UpdateValUtil(int[] st, int ss, int se, int diff, int si, int i)
    {
        if (i < ss || i > se) return;

        st[si] += diff;
        if (ss != se)
        {
            int mid = ss + (se - ss) / 2;
            UpdateValUtil(st, ss, mid, diff, 2 * si + 1, i);
            UpdateValUtil(st, mid + 1, se, diff, 2 * si + 2, i);
        }
    }


    private int GetSum(int[] st, int n, int s, int e)
    {
        if (s < 0 || e > n) { throw new Exception("Invalid"); }
        return GetSumRecur(st, 0, n, s, e, 0);
    }

    private int GetSumRecur(int[] st, int ss, int se, int qs, int qe, int index)
    {
        if (qs <= ss && qe >= se) return st[index];

        if (qs > se || qe < ss) return 0;

        int mid = ss + (se - ss) / 2;
        return GetSumRecur(st, ss, mid, qs, qe, 2 * index + 1) +
            GetSumRecur(st, mid + 1, se, qs, qe, 2 * index + 2);
    }

    private void BuildSegTree(int[] array, out int[] st)
    {
        int h = (int)Math.Ceiling((double)Math.Log(array.Length - 1, 2));
        int size = 2 * (int)Math.Pow(2, h) - 1;

        st = new int[size];
        BuildSegTreeRecur(array, 0, array.Length - 1, st, 0);
    }

    private int BuildSegTreeRecur(int[] a, int s, int e, int[] st, int index)
    {
        if (s == e) { st[index] = a[s]; return st[index]; }

        int mid = s + (e - s) / 2;
        st[index] = BuildSegTreeRecur(a, s, mid, st, 2 * index + 1) +
                BuildSegTreeRecur(a, mid + 1, e, st, 2 * index + 2);
        return st[index];
    }
}
