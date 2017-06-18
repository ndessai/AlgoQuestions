//unique characters
using System;

namespace UniqueCharacters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            string testString = "ABCDEFGHijklmnopqrst";
            Console.WriteLine(testString + " Results => " +p.IsUniqueCharacterString(testString) + "  " +p.IsUniqueCharacterStringNoDS(testString));

            testString = "";
            Console.WriteLine(testString + " Results => " +p.IsUniqueCharacterString(testString) + "  " +p.IsUniqueCharacterStringNoDS(testString));

            testString = "ABCDEFGHijklmnopqrstA";
            Console.WriteLine(testString + " Results => " +p.IsUniqueCharacterString(testString) + "  " +p.IsUniqueCharacterStringNoDS(testString));

            testString = "AABCDEFGHijklmnopqrst";
            Console.WriteLine(testString + " Results => " +p.IsUniqueCharacterString(testString) + "  " +p.IsUniqueCharacterStringNoDS(testString));

            Console.Read();
        }

        private bool IsUniqueCharacterString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            if (input.Length > (long)(Math.Pow(2, 2 * 8 * sizeof(char))))
            {
                return false;
            }
            bool[] charHashes = new bool[256];
            for (int i = 0; i < 256; i++)
            {
                charHashes[i] = false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (charHashes[input[i]])
                {
                    return false;
                }
                charHashes[input[i]] = true;
            }
            return true;
        }

        private bool IsUniqueCharacterStringNoDS(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            if (input.Length > (long)(Math.Pow(2, 2 * 8 * sizeof(char))))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (input[i] == input[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }

}
