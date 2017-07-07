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

    public GraphWithMatrix(int?[,] costs)
    {
        Costs = costs;

    }
}