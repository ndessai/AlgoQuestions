//space (' ') replacement with "%20"

using System;

namespace ReplaceSpace
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            string input = "This is a space string";
            p.ReplaceSpaceChars(input);
            Console.Read();
        }

        private void ReplaceSpaceChars(string input)
        {
            int numOfSpaces = 0;
            foreach (var c in input)
            {
                if (c == ' ')
                {
                    numOfSpaces++;
                }
            }

            int replacedLength = numOfSpaces * 2 + input.Length;
            char[] replaced = new char[replacedLength];
            if (numOfSpaces > 0)
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i] == ' ')
                    {
                        replaced[replacedLength - 1] = '0';
                        replaced[replacedLength - 2] = '2';
                        replaced[replacedLength - 3] = '%';
                        replacedLength -= 3;
                    }
                    else
                    {
                        replaced[replacedLength - 1] = input[i];
                        replacedLength--;
                    }
                }
            }
            Console.WriteLine(input + "   => " + new String(replaced));
        }
    }

}
