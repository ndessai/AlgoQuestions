using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naive
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
            foreach(var index in result) { Console.Write(index + "  "); }
            Console.Read();
        }

        private List<int> GetMatchingIndices(string text, string pat)
        {
            var result = new List<int>();
            for(int i = 0; i< text.Length - pat.Length; i++)
            {
                int j = 0;
                int start = i;
                if(text[i] == pat[j])
                {
                    while (j < pat.Length && text[i++] == pat[j++]) ;
                }
                
                if(j == pat.Length)
                {
                    i--;
                    result.Add(start);
                }
            }
            return result;
        }
    }
}
