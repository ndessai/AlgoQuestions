//selection sort

using System;

public class Program
{

    public static void Main(string[] args)
    {
        var p = new Program();
        int[] array = new int[] { 4, 3, 7, 6, 8, 1, 9, 2, 5 };
        p.MergeSort(ref array, 0, array.Length - 1);
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.Read();
    }

    private void MergeSort(ref int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        int middle = (start + end) / 2;
        MergeSort(ref array, start, middle);
        MergeSort(ref array, middle + 1, end);

        int i = start;
        int j = middle + 1;
        while (i < j && j <= end)
        {
            if (array[i] < array[j])
            {
                i++;
                continue;
            }
            int shiftIndex = j;
            int temp = array[j];
            while (shiftIndex > i)
            {
                array[shiftIndex] = array[shiftIndex - 1];
                shiftIndex--;
            }
            array[i] = temp;
            i++;
            j++;
        }
    }
}