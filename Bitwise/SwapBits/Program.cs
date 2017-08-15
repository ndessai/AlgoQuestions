using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapBits
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(" 47, 3, 1, 5 =>" + p.SwapBits(47, 3, 1, 5));
            Console.WriteLine(" 28, 2, 0, 3 =>" + p.SwapBits(28, 2, 0, 3));
            Console.Read();

        }

        private int SwapBits(int a, int size, int loc1, int loc2)
        {
            int set1 = (a >> loc1) & ((1 << size) - 1);
            int set2 = (a >> loc2) & ((1 << size) - 1);

            int xor = set1 ^ set2;
            int xorNum = xor << loc1 | xor << loc2;

            return a ^ xorNum;
        }
    }
}
