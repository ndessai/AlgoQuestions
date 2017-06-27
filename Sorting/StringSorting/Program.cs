using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = new string[] { "his", "an", "na"};
            Array.Sort(array1);
            foreach (var i in array1)
            {
                Console.WriteLine(i);
            }

            Array.Sort(array1, new AnagramComparer());
            foreach (var i in array1)
            {
                Console.WriteLine(i);
            }

            Console.Read();

        }
    }

    public class AnagramComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            char[] xArray = x.ToArray();
            char[] yArray = y.ToArray();
            Array.Sort(xArray);
            Array.Sort(yArray);
            if(xArray.Length == yArray.Length)
            {
                int i = 0;
                for(i = 0;i <xArray.Length; i++)
                {
                    if(xArray[i] != yArray[i])
                    {
                        break;
                    }
                }
                int j = x.CompareTo(y);
                if(i == xArray.Length)
                {
                    return -1;
                }
            }
            return x.CompareTo(y);
        }
    }
}
