using System;

public class Program
{

    public static void Main(string[] args)
    {
        int[] array = new int[] { 9, 5, 2, 7, 6, 8, 1, 3, 4, 6 };
        var p = new Program();
        p.InsertionSort(ref array);

        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.Read();
    }

    private void InsertionSort(ref int[] array)
    {
        int j;
        for (int i = 1; i < array.Length; i++)
        {
            j = i;
            while (j > 0 && array[j] < array[j - 1])
            {
                var temp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = temp;
                j--;
            }
        }
    }
}
