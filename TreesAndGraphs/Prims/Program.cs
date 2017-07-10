using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlow
{

    using System;
    using System.Collections.Generic;

    public class GraphWithMatrix<T>
    {
        public T[] Nodes { get; set; }
        public int?[,] Costs { get; set; }

        public GraphWithMatrix(T[] nodeNames)
        {
            Nodes = nodeNames;
            Costs = new int?[Nodes.Length, Nodes.Length];
        }

        public void Print()
        {
            Print(Costs);
        }

        public static void Print(int?[,] graph)
        {
            Console.WriteLine(); Console.Write("\t\t");
            for (int i = 1; i <= graph.GetLength(0); i++) Console.Write("\t" + i);
            for (int j = 0; j < graph.GetLength(0); j++)
            {
                Console.WriteLine();
                Console.Write((j + 1) + "\t\t");
                for (int k = 0; k < graph.GetLength(1); k++) Console.Write("\t" + graph[j, k]);
            }
        }

        public void AddEdge(int i, int j, int cost)
        {
            Costs[i, j] = cost;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            GraphWithMatrix<int> graph = new GraphWithMatrix<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            graph.Costs = new int?[,]{{0, 2, 0, 6, 0},
                      {2, 0, 3, 8, 5},
                      {0, 3, 0, 0, 7},
                      {6, 8, 0, 0, 9},
                      {0, 5, 7, 9, 0},
                     };
            graph.Print();
            var p = new Program();
            p.Prims(graph.Costs);
            Console.Read();
        }
        
        private void Prims(int?[,] graph)
        {
            bool[] mst = new bool[graph.GetLength(0)];
            int[] parents = new int[graph.GetLength(0)];
            int[] keys = new int[graph.GetLength(0)];

            for(int i =0;i<keys.Length; i++)
            {
                keys[i] = Int32.MaxValue;
            }
            keys[0] = 0;
            parents[0] = -1;

            for(int i =0; i< keys.Length; i++)
            {
                int nextKey = GetNextNode(mst, keys);
                mst[nextKey] = true;

                for(int j = 0; j< keys.Length; j++)
                {
                    if(graph[nextKey, j].HasValue && graph[nextKey, j].Value > 0 && !mst[j] &&
                        graph[nextKey, j].Value < keys[j])
                    {
                        parents[j] = nextKey;
                        keys[j] = graph[nextKey, j].Value;
                    }
                }
            }

            Console.WriteLine("\nMinimum spanning tree");
            for(int i = 1; i< keys.Length; i++)
            {
                Console.WriteLine(i + " " + parents[i] + " => " + graph[i, parents[i]]);
            }
        }

        private int GetNextNode(bool[] mst, int[] keys)
        {
            int key = Int32.MaxValue;
            int minIndex = 0;

            for(int i =0; i< keys.Length; i++)
            {
                if(!mst[i] && keys[i] < key)
                {
                    minIndex = i;
                    key = keys[i];
                }
            }
            return minIndex;
        }
    }
}
