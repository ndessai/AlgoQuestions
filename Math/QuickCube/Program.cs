using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickCube
{
    class Program
    {
        static void Main(string[] args)
        {
            //find (Q+U+I+C+K)^3 = QUICK

            //min sum of quick can be 1+0+2+3+4 =   10
            //max sum is 9+8+7+6+5 = 37

            //so the sum must be between 10 and 37 including
            Dictionary<int, int> sumCubes = new Dictionary<int, int>();
            for(int i = 10; i<=37; i++)
            {
                var power = (int)Math.Pow(i, 3);
                if (power < 10234 || power > 98756) //we should exclude these entries as we want 5 digits
                    continue;

                // last digit cubes can only be like these
                //1-1, 2-8, 3-7, 4-4, 5-5, 6-6, 7-3, 8-2, 9-9, 0-0 - includes all digits, so no investigatin



                int lastDigit = power % 10;
                int sumWithoutLastDigit = i - lastDigit;
                //get sum of other digits as sumWithoutLastDigit
                int maxSum = 0;
                int minSum = 0;
                int[] exclude = new int[1];
                exclude[0] = lastDigit;
                bool sumPossible = IsSumPossibleExcluding(sumWithoutLastDigit, exclude, out maxSum, out minSum);
                if(!sumPossible)
                {
                    continue;//other digits cannot do the sum
                }
                //now apply formula (a+b)^3 = a^3 + b^3 + 3a^b + 3ab^2;
                int rhs = (int)Math.Pow(sumWithoutLastDigit, 3) + (int)Math.Pow(lastDigit, 3)
                            + 3 * lastDigit * (int)Math.Pow(sumWithoutLastDigit, 2)
                            + 3* sumWithoutLastDigit * (int)Math.Pow(lastDigit, 2); 
                sumCubes.Add(i, power );
                Console.WriteLine(i + "  " + power + "  " + lastDigit + "  " + sumWithoutLastDigit + " " + sumPossible + " " + minSum + " " + maxSum);
            }

            Console.Read();
             
        }

        static bool IsSumPossibleExcluding(int sum, int[] exclude, out int maxSum, out int minSum)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            maxSum = 0;
            minSum = 0;
            int i = 0;
            int l = 0;
            int h = array.Length - 1;
            while (true)
            {
                if (exclude.Contains(h)) { h--; continue; }
                maxSum += array[h];
                if (++i == 4) break;
                h--;
            }
            i = 0;
            while (true)
            {
                if (exclude.Contains(l)) { l++; continue; }
                minSum += array[l];
                if (++i == 4) break;
                l++;
            }
            if(!( sum >= minSum && sum <= maxSum)) return false;
            //sum is possible -- check permutations
            int computeSum = 0;
            foreach (var item in exclude) computeSum += item;
            for(int j =0;j< array.Length;j++)
            {
                if (exclude.Contains(j)) continue;
                if (exclude.Length == 4 && sum == computeSum + j)
                {
                    //Console.WriteLine(j);
                    foreach (var item in exclude) {
                        // Console.Write(" " + item + " "); 
                    }
                    return true;
                }
                if (exclude.Length == 5) return false;
                var excludeList = new List<int>(exclude);
                excludeList.Add(j);
                int maxSum1 = 0;
                int minSum1 = 0;
                var possible = IsSumPossibleExcluding(sum, excludeList.ToArray(), out maxSum1, out minSum1);
                if (possible) return true;
            }
            return false;
        }
    }
}
