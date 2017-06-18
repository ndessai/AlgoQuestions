//remove duplicate characters

using System;

namespace RemoveDuplicate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            string input = "ABCDABCADEFG";
            p.RemoveDuplicateChars(input.ToCharArray());

            input = "aaaa";
            p.RemoveDuplicateChars(input.ToCharArray());

            input = "abcdefabbaa";
            p.RemoveDuplicateChars(input.ToCharArray());
            Console.Read();


        }

        private void RemoveDuplicateChars(char[] input)
        {
            Console.WriteLine();
            Console.WriteLine(new String(input));

            int tail = 1;
            for (int i = 1; i < input.Length; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (input[i] == input[j]) break;
                }
                if (j == tail)
                {
                    input[tail] = input[i];
                    ++tail;
                }
                Console.WriteLine(new String(input));
            }
            input[tail] = '0';
            Console.WriteLine(new String(input));
        }
    }
}
