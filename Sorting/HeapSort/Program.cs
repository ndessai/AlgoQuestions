using System;

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        int[] array = new int[] { 7, 10, 8, 4, 1, 5, 6, 9, 2, 3 };
        int heapSize = array.Length - 1;
        for (int i = (array.Length - 1) / 2; i >= 0; i--)
            p.Heapify(ref array, array.Length - 1, i);


        for (int j = array.Length - 1; j >= 0; j--)
        {
            int temp = array[j];
            array[j] = array[0];
            array[0] = temp;
            heapSize--;
            p.Heapify(ref array, heapSize, 0);
        }


        foreach (var item in array) Console.Write(item + " ");
        Console.Read();

    }

    private void Heapify(ref int[] array, int heapSize, int index)
    {
        int left = (index + 1) * 2 - 1;
        int right = (index + 1) * 2;
        int largest = 0;

        if (left < heapSize && array[left] > array[index])
            largest = left;
        else
            largest = index;

        if (right < heapSize && array[right] > array[largest])
            largest = right;

        if (largest != index)
        {
            int temp = array[index];
            array[index] = array[largest];
            array[largest] = temp;
            Heapify(ref array, heapSize, largest);
        }
    }
}
