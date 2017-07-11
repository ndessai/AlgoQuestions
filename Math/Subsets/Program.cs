using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Program().GetSubsets(new List<int>(new int[] { 1, 2, 3, 4, 5 }), 0);
            foreach(var item in result)
            {
                Console.WriteLine();
                foreach (var e in item) Console.Write(e + "  ");
            }
            Console.Read();

        }

        private List<List<int>> GetSubsets(List<int> set, int index)
        {
            List<List<int>> allsubSets;

            if(set.Count == index)
            {
                allsubSets =  new List<List<int>>();
                allsubSets.Add(new List<int>());
            }
            else
            {
                allsubSets = GetSubsets(set, index + 1);
                int item = set[index];
                var moreSubsets = new List<List<int>>();
                foreach (var subset in allsubSets)
                {
                    var newSubset = new List<int>();
                    newSubset.AddRange(subset);
                    newSubset.Add(item);
                    moreSubsets.Add(newSubset);
                }
                allsubSets.AddRange(moreSubsets);
            }

            return allsubSets;
        }
    }
}
