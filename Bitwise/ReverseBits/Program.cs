using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseBits
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine(" 1 " + p.ReverseBits(1));
            Console.WriteLine(" 2147483648 " + p.ReverseBits(2147483648));
            Console.Read();
        }

        uint ReverseBits(uint n)
        {
            uint result = 0;
            uint hmask = (uint)1 << 31;
            uint lmask = 1;
            int index = 31;
            uint lbit, hbit;

            while(hmask > lmask)
            {
                lbit = (n & lmask) << index;
                hbit = (n & hmask) >> index;
                index--;
                hmask >>= 1;
                lmask <<= 1;
                result = result | hbit | lbit;
            }

            return result;
        }
    }
}
