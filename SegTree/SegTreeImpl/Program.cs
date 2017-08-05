using System;

class Program
{
    public static void Main(string[] args)
    {
        int []array = new int[]  { 1, 3, 5, 7, 9, 11};
        var p = new Program();
        int[] segTree;
        p.BuildSegTree(array, out segTree);

        foreach(var item in segTree)
        {
            Console.Write(item + "   ");
        }

        Console.WriteLine();
        Console.WriteLine(" The sum of 1 to 3 is " + p.GetSum(segTree, array.Length -1, 1, 3));
        p.UpdateValue(array, 2, 10, segTree);
        Console.WriteLine(" The new sum of 1 to 3 is " + p.GetSum(segTree, array.Length - 1, 1, 3));
        Console.Read();
    }

    private void UpdateValue(int [] array, int i, int val, int [] st)
    {
        if(i < 0 || i> array.Length -1)
        {
            return;
        }
        int diff = val - array[i];
        array[i] = val;
        UpdateValueUtil(i, diff, st, 0, array.Length - 1, 0);
    }

    private void UpdateValueUtil(int i, int diff, int[] st, int ss, int se, int si)
    {
        if (i < ss || i > se)
        {
            return;
        }
        st[si] += diff;
        if(ss != se)
        {
            int mid = ss + (se - ss) / 2;
            UpdateValueUtil(i, diff, st, ss, mid, 2 * si + 1);
            UpdateValueUtil(i, diff, st, mid+1, se, 2 * si + 2);
        }
    }

    private int GetSumUtil(int [] st, int ss, int se, int qs, int qe, int index)
    {
        if (qs <= ss && qe >= se) return st[index];

        if (ss > qe || se < qs) return 0;

        int mid = ss + (se - ss) / 2;
        return GetSumUtil(st, ss, mid, qs, qe, 2 * index + 1) +
            GetSumUtil(st, mid+1, se, qs, qe, 2 * index + 2);
    }

    private int GetSum(int[] st, int n, int qs, int qe)
    {
        if(qs <0 || qe > n)
        {
            throw new Exception("Invalid");
        }
        return GetSumUtil(st, 0, n, qs, qe, 0);
    }

    private void BuildSegTree(int[] array, out int[] segTree)
    {
        int h = (int)Math.Ceiling(Math.Log(array.Length, 2));
        int newSize = 2 * (int)Math.Pow(2, h) - 1;
        segTree = new int[newSize];

        BuildSegTreeRecur(array, 0, array.Length - 1, segTree, 0);

    }

    private int BuildSegTreeRecur(int[] array, int s, int e, int[] segTree, int i)
    {
        if (s == e)
        {
            segTree[i] = array[s];
            return segTree[i];
        }
        int mid = s + (e - s) / 2;

        segTree[i] = BuildSegTreeRecur(array, s, mid, segTree, 2 * i + 1) +
                BuildSegTreeRecur(array, mid + 1, e, segTree, 2 * i + 2);

        return segTree[i];
    }
}
