using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            foreach(var str in p.GetPermutations("This"))
            {
                Console.WriteLine(str);
            }
            Console.Read();
        }

        private List<string> GetPermutations(string str)
        {
            List<string> result = new List<string>();
            if(str == null)
            {
                return null;
            } else if(string.IsNullOrEmpty(str))
            {
                result.Add("");
                return result;
            }

            char c = str[0];
            string remainder = str.Substring(1);
            var subPerms = GetPermutations(remainder);
            foreach(var perm in subPerms)
            {
                var array = perm.ToCharArray();
                for(int i = 0;i<=array.Length;i++)
                {
                    var newArray = new char[array.Length + 1];
                    int k = 0;
                    for(int m=0;m< newArray.Length; m++)
                    {
                        if(m==i) { newArray[m] = c;  continue; }

                        newArray[m++] = array[k++];
                    }
                    result.Add(new string(newArray));
                }
            }
            return result;
        }
    }
}
