using System;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        var array = new int[] { 10, 12, 14, 16, 18, 20, 22, 2, 4, 6, 8 };

        Console.WriteLine(" 10 " + p.SearchArray(array, 10, 0, array.Length - 1));
        Console.WriteLine(" 14 " + p.SearchArray(array, 14, 0, array.Length - 1));
        Console.WriteLine(" 20 " + p.SearchArray(array, 20, 0, array.Length - 1));
        Console.WriteLine(" 2 " + p.SearchArray(array, 2, 0, array.Length - 1));
        Console.WriteLine(" 4 " + p.SearchArray(array, 4, 0, array.Length - 1));
        Console.WriteLine(" 9 " + p.SearchArray(array, 9, 0, array.Length - 1));
        Console.WriteLine(" 23 " + p.SearchArray(array, 23, 0, array.Length - 1));
        Console.WriteLine(" 15 " + p.SearchArray(array, 15, 0, array.Length - 1));

        Console.Read();

    }

    private int SearchArray(int[] array, int item, int low, int high)
    {
        while (low <= high)
        {
            int m = (low + high) / 2;
            if (array[m] == item) return m;

            if (array[low] <= array[m] && array[m] <= array[high])
            {
                if (item < array[m]) high = m - 1;
                else low = m + 1;
            }
            else
            {
                if (item > array[m])
                {
                    low = m + 1;
                }
                else if (item < array[low])
                {
                    if (array[low] > array[m]) high = m - 1;
                    else low = m + 1;
                }
                else
                    high = m - 1;
            }
        }
        return -1;
    }

}
