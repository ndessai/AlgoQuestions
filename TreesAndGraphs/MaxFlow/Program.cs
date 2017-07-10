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

        public static void Print(int? [,] graph)
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
            GraphWithMatrix<int> graph = new GraphWithMatrix<int>(new int[] { 1,2,3,4,5,6});
            graph.Costs =  new int?[,]{
                { 0, 16, 13, 0, 0, 0},
                        { 0, 0, 10, 12, 0, 0},
                        { 0, 4, 0, 0, 14, 0},
                        { 0, 0, 9, 0, 0, 20},
                        { 0, 0, 0, 7, 0, 4},
                        { 0, 0, 0, 0, 0, 0}
            };
            graph.Print();
            var p = new Program();
            Console.WriteLine();
            Console.WriteLine("Max flow from " + 0 + " to " + 5 + " is  " + p.MaxFlow(graph, 0, 5));
            Console.Read();
        }

        private int MaxFlow(GraphWithMatrix<int> graph, int s, int t)
        {
            int[] parents = new int[graph.Nodes.Length];
            int?[,] rGraph = (int?[,]) graph.Costs.Clone();

            int minPathFlow = Int32.MaxValue;
            int maxPathFlow = 0;

            while (BFS(rGraph, s, t, parents))
            {
                int child = t;
                minPathFlow = Int32.MaxValue;

                for (int i = t; i != s; i = parents[i])
                {
                    int val = rGraph[parents[i], i].HasValue ? rGraph[parents[i], i].Value : 0;
                    minPathFlow = Math.Min(minPathFlow, val);
                }

                for (int i = t; i != s; i = parents[i])
                {
                    rGraph[parents[i], i] -= minPathFlow;
                    rGraph[i, parents[i]] += minPathFlow;
                }
                maxPathFlow += minPathFlow;

                Console.WriteLine();
                GraphWithMatrix<int>.Print(rGraph);
                Console.WriteLine();
                Console.WriteLine("MaxFlow => " + maxPathFlow);
                Console.WriteLine();

            }
            return maxPathFlow;
        }

        private bool BFS(int?[,] graph, int s, int t, int[] parents)
        {
            Queue<int> q = new Queue<int>();

            bool[] visited = new bool[graph.GetLength(0)];
            visited[s] = true;
            q.Enqueue(s);
            parents[s] = -1;

            while(q.Count>0)
            {
                int u = q.Dequeue();
                for(int i = 0; i<graph.GetLength(0); i++)
                {
                    if(visited[i] == false && graph[u, i] >0)
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        parents[i] = u;
                    }
                }
            }

            return visited[t];
        }
    }
}
