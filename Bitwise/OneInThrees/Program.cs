using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] array = { 13, 14, 15, 6, 13, 15, 14, 2, 13, 2, 15, 14, 2 };
        var p = new Program();
        Console.WriteLine("Single is " + p.GetSingle(array));
        Console.Read();
    }

    private int GetSingle(int[] array)
    {
        int ones = 0; int twos = 0;
        int common_bit_mask = 0;

        foreach (var no in array)
        {
            twos |= (ones & no);
            ones ^= no;

            common_bit_mask = ~(ones & twos);
            ones &= common_bit_mask;
            twos &= common_bit_mask;
        }
        return ones;
    }
}
