//selection sort

using System;

public class Program
{

    public static void Main(string[] args)
    {
        var p = new Program();
        int[] array = new int[] { 4, 3, 7, 6, 8, 1, 9, 2, 5 };
        p.SelectionSort(ref array);
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.Read();
    }


    private void SelectionSort(ref int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var minIndex = i;
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex]) minIndex = j;
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }
}
