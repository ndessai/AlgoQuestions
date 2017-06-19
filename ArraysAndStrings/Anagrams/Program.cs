//anagram check

using System;

namespace AnagramCheck
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            string str1 = "working";
            string str2 = "krogwin";
            Console.WriteLine(str1 + " " + str2 + " " + p.IsAnagram(str1, str2));

            str1 = "working";
            str2 = "krogwin2";
            Console.WriteLine(str1 + " " + str2 + " " + p.IsAnagram(str1, str2));

            str1 = "working1";
            str2 = "krogwin";
            Console.WriteLine(str1 + " " + str2 + " " + p.IsAnagram(str1, str2));
            Console.Read();
        }

        private bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
            {
                return false;
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            int[] charCount = new int[256];
            for (int i = 0; i < 256; i++)
            {
                charCount[i] = 0;
            }

            int num_unique_chars = 0;
            int num_unique_counted = 0;
            foreach (char c in s1)
            {
                if (charCount[c] == 0)
                {
                    num_unique_chars++;
                }
                charCount[c]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];
                charCount[c]--;
                if (charCount[c] == 0)
                {
                    num_unique_counted++;
                    if (num_unique_chars == num_unique_counted)
                    {
                        return s2.Length - 1 == i;
                    }
                }
            }
            return false;
        }
    }
}
