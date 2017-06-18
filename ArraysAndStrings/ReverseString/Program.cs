//Reverse C Style string

using System;

namespace ReverseString
{
public class Program
{
    public static void Main(string[] args)
    {
        var p = new Program();
        string input = "ABCD";
        var reverse = input.ToCharArray();
        p.ReverseString(reverse);

        Console.WriteLine(input + "  " + new String(reverse));

        input = "abcde";
        reverse = input.ToCharArray();
        p.ReverseString(reverse);

        Console.WriteLine(input + "  " + new String(reverse));

        Console.Read();
    }

    private void ReverseString(char[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input.Length - 1 - i <= i)
                break;
            char temp = input[i];
            input[i] = input[input.Length - 1 - i];
            input[input.Length - 1 - i] = temp;
        }
    }
}
}
