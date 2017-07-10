using System;
using System.Collections.Generic;

public class GraphWithMatrix<T> 
{
    T[] Nodes { get; set; }
    int? [,] Costs  {get;set;}

    public GraphWithMatrix(T [] nodeNames)
    {
        Nodes = nodeNames;
        Costs = new int?[Nodes.Length, Nodes.Length];
    }

    public void Print()
    {
        Console.WriteLine(); Console.Write("\t\t");
        for (int i = 1; i <= Costs.Length; i++) Console.Write("\t" + i);
        for(int j=0;j<Costs.Rank;j++)
        {
            Console.WriteLine();
            Console.Write(j+"\t\t");
            for(int k=0;k<Costs.GetLength(j);k++) Console.Write("\t" + Costs[j,k]);
        }
    }

    public void AddEdge(int i, int j, int cost)
    {
        Costs[i, j] = cost;
    }
}