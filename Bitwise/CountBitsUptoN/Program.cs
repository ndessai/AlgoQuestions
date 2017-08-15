//count bits upto n;

using System;

class BitCalc
{

    public static void Main(string[] args)
    {
        var p = new BitCalc();

        Console.WriteLine(" 4 " + p.GetBitCountUpto(4));
        Console.WriteLine(" 5 " + p.GetBitCountUpto(5));
        Console.WriteLine(" 6 " + p.GetBitCountUpto(6));
        Console.WriteLine(" 7 " + p.GetBitCountUpto(7));
        Console.WriteLine(" 8 " + p.GetBitCountUpto(8));

        Console.Read();
    }
    private int GetBitCountUpto(int n)
    {
        if (n <= 1) return n;

        int nn = n;
        int m = 0;

        while (nn > 1) { m++; nn = nn >> 1; };
        
        if( n == (1 << m+1) - 1)
        {
            return (m+1) * (int)Math.Pow(2, m);
        }
        int lowerBitCount = m * (int)Math.Pow(2, m - 1);

        
        int msbBits = n - (1 << m) + 1;
        int i = 0;
        while (m-- > 0) i = (i << 1 )| 1;
        return msbBits + GetBitCountUpto(n & i) + lowerBitCount;
    }
}

