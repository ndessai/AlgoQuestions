//quick sort

using System;

public class Program
{

    public static void Main(string[] args)
    {
        var p= new Program();
        int[] array = new int[] { 4, 3, 7, 6, 8, 1, 9, 2, 5 };
        p.QuickSort(ref array, 0, array.Length - 1);
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.Read();
    }

    private void QuickSort(ref int[] array, int left, int right)
    {
        int pivot = new Random().Next(left, right);
        int i = left;
        int j = right;

        while (i <= j)
        {
            if (array[i] < array[pivot]) i++;

            if (array[j] > array[pivot]) j--;

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }
        if (left < j) QuickSort(ref array, left, j);
        if (right > i) QuickSort(ref array, i, right);

    }
}
