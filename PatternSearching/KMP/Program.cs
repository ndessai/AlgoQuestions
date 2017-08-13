using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "..\\..\\..\\Text.js";
            string text = File.ReadAllText(path);
            var pat = "updateType";
            var start = DateTime.Now;
            var result = new Program().GetMatchingIndices(text, pat);
            var time = (DateTime.Now - start).Milliseconds;
            Console.WriteLine("Time taken(ms): " + time);
            foreach (var index in result) { Console.Write(index + "  "); }
            Console.Read();
        }

        private List<int> GetMatchingIndices(string text, string pat)
        {
            var result = new List<int>();
            int[] lps;
            BuildLps(pat, out lps);
            int i = 0, j=0;
            while (i < text.Length)
            {
                if(text[i] == pat[j])
                {
                    i++;
                    j++;
                }

                if(j == pat.Length)
                {
                    result.Add(i-j);
                    j = lps[j - 1];
                }
                else if(i < text.Length && text[i] != pat[j])
                {
                    if(j == 0)
                    {
                        i++;
                    }
                    else
                    {
                        j = lps[j - 1];
                    }
                }
            }

            return result;
        }

        private void BuildLps(string pat, out int[] lps)
        {
            lps = new int[pat.Length];
            int i = 0;
            int len = 0;
            lps[i++] = 0;

            while(i < pat.Length)
            {
                if(pat[i] == pat[len])
                {
                    lps[i++] = ++len;
                }
                else
                {
                    if( len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i++] = 0;
                    }
                }
            }
        }
    }
}
