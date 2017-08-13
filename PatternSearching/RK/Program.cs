using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RK
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

            int i, j, p = 0, t = 0, h = 1, d = 256, q = 101;

            for(i = 0; i< pat.Length -1; i++)
            {
                h = (h * d)%q;
            }

            for (i = 0; i < pat.Length ; i++)
            {
                p = (d * p + pat[i]) % q;
                t = (d * t + text[i]) % q;
            }

            for(i = 0; i < text.Length - pat.Length; i++)
            {
                if(p == t)
                {
                    for(j = 0; j< pat.Length; j++)
                    {
                        if (text[i+j] != pat[j] )
                        {
                            break;
                        }
                    }
                    if(j == pat.Length)
                    {
                        result.Add(i);
                    }
                }
                if(i < text.Length - pat.Length)
                {
                    t = (d * (t - text[i] * h) + text[i + pat.Length]) % q;
                    if (t < 0) t += q; 
                }
            }

            return result;
        }
    }
}
