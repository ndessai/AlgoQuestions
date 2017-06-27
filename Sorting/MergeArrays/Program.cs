//quick sort

using System;

public class Program
{

    public static void Main(string[] args)
    {
        var p= new Program();
        int[] A = new int[] { 1, 3, 5, 7, 9 };
        int[] B = new int[9];

        B[0] = 2; B[1] = 4; B[2] = 6; B[3] = 8;

        p.MergeAIntoB(A, ref B, 4);
        foreach (var i in B)
        {
            Console.Write(i + " ");
        }
        Console.Read();
    }

    private void MergeAIntoB(int[] A, ref int[] B, int bLength)
    {
        int total = A.Length + bLength - 1;

        int a = A.Length - 1;
        int b = bLength - 1;

        while (a >= 0 && b >= 0)
        {
            if (A[a] > B[b])
                B[total--] = A[a--];
            else
                B[total--] = B[b--];
        }
        if (a >= 0)
            while (a >= 0) B[total--] = A[a--];
    }
}
