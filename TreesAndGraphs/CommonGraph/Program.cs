using System;
using System.Collections.Generic;

public class Node<T> where T : IComparable<T>
{
    public T Data { get; set; }
    public List<Node<T>> Neighbors { get; set; }
    public List<int?> Costs;

    public Node(T val)
    {
        Data = val;
        Neighbors = new List<Node<T>>();
        Costs = new List<int?>();
    }
}

public class Graph<T> where T : IComparable<T>
{
    public bool Directed { get; set; }
    public List<Node<T>> Nodes { get; set; }

    public Graph()
    {
        Nodes = new List<Node<T>>();
    }

    public void AddNode(T val)
    {
        var node = new Node<T>(val);
        Nodes.Add(node);
    }

    public Node<T> FindNode(T val)
    {
        foreach (var node in Nodes)
        {
            if (node.Data.CompareTo(val) == 0) return node;
        }
        return null;
    }

    public void AddEdge(T source, T dest, int? cost = null)
    {
        var srcNode = FindNode(source);
        if (srcNode == null) return;

        var destNode = FindNode(dest);
        if (destNode == null) return;

        srcNode.Neighbors.Add(destNode);
        srcNode.Costs.Add(cost);
        if (!Directed)
        {
            destNode.Neighbors.Add(srcNode);
            destNode.Costs.Add(cost);
        }
    }

    public void Print()
    {
        Console.WriteLine(string.Format("Printing Graph with {0} nodes and Directed {1}",
            Nodes.Count, Directed));

        foreach (var node in Nodes)
        {
            Console.WriteLine();
            Console.Write(node.Data + " \t");
            int i = 0;
            foreach (var neighbor in node.Neighbors)
            {
                var cost = node.Costs[i++];
                Console.Write(neighbor.Data + " , " + (cost.HasValue ? cost.Value.ToString() : "") + " \t");
            }
        }
        Console.WriteLine();
    }

    public void DFS(T root)
    {
        Node<T> rootNode = FindNode(root);
        if (rootNode == null) return;

        var visitedDictionary = new Dictionary<Node<T>, bool>();
        foreach (var node in Nodes)
        {
            visitedDictionary.Add(node, false);
        }
        DFSRecursive(rootNode, visitedDictionary);
    }

    private void DFSRecursive(Node<T> node, Dictionary<Node<T>, bool> visited)
    {
        if (visited[node])
        {
            return;
        }
        visited[node] = true;
        Console.Write(" " + node.Data + " ");

        foreach (var neighbor in node.Neighbors)
        {
            DFSRecursive(neighbor, visited);
        }

    }

    public void BFS(T root)
    {
        Node<T> rootNode = FindNode(root);
        if (rootNode == null) return;

        var visitedDictionary = new Dictionary<Node<T>, bool>();
        foreach (var node in Nodes)
        {
            visitedDictionary.Add(node, false);
        }
        Queue<Node<T>> nodes = new Queue<Node<T>>();
        nodes.Enqueue(rootNode);
        visitedDictionary[rootNode] = true;
        while (nodes.Count > 0)
        {
            var node = nodes.Dequeue();
            
            Console.Write(" " + node.Data + " ");
            foreach (var neighbor in node.Neighbors)
            {
                if (visitedDictionary[neighbor]) continue;
                visitedDictionary[neighbor] = true;
                nodes.Enqueue(neighbor);
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var graph = new Graph<string>();
        graph.Directed = true;
        graph.AddNode("NY");
        graph.AddNode("CH");
        graph.AddNode("MI");
        graph.AddNode("DE");

        graph.AddNode("DA");
        graph.AddNode("SF");
        graph.AddNode("LA");
        graph.AddNode("SD");

        graph.AddEdge("NY", "MI", 90);
        graph.AddEdge("NY", "DA", 125);
        graph.AddEdge("NY", "CH", 75);
        graph.AddEdge("NY", "DE", 100);

        graph.AddEdge("MI", "DA", 50);

        graph.AddEdge("CH", "DE", 20);
        graph.AddEdge("CH", "SF", 25);

        graph.AddEdge("DE", "LA", 100);
        graph.AddEdge("DE", "SF", 75);

        graph.AddEdge("DA", "LA", 80);
        graph.AddEdge("DA", "SD", 90);

        graph.AddEdge("SF", "LA", 45);
        graph.AddEdge("SD", "LA", 45);

        graph.Print();
        Console.WriteLine(" Doing DFS ");
        
        graph.DFS("NY");
        Console.WriteLine(" Doing BFS");
        graph.BFS("NY");
        Console.WriteLine("Cycle =>" + graph.HasCycle);
        Console.WriteLine();

        //second graph
        graph = new Graph<string>();
        graph.Directed = false;
        graph.AddNode("H1");
        graph.AddNode("H2");
        graph.AddNode("H3");
        graph.AddNode("H4");

        graph.AddNode("H5");
        graph.AddNode("H6");
        graph.AddNode("H7");
        graph.AddNode("H8");
        graph.AddNode("H9");
        graph.AddNode("H10");

        graph.AddEdge("H1", "H3", 45);
        graph.AddEdge("H1", "H2", 20);
        graph.AddEdge("H1", "H10", 45);

        graph.AddEdge("H3", "H4", 45);
        graph.AddEdge("H3", "H2", 30);

        graph.AddEdge("H10", "H2", 30);
        graph.AddEdge("H10", "H8", 50);

        graph.AddEdge("H2", "H5", 25);
        graph.AddEdge("H2", "H8", 100);

        graph.AddEdge("H5", "H4", 75);
        graph.AddEdge("H5", "H6", 75);
        graph.AddEdge("H5", "H8", 90);

        graph.AddEdge("H6", "H9", 40);
        graph.AddEdge("H6", "H7", 80);

        graph.AddEdge("H8", "H9", 45);
        graph.AddEdge("H8", "H7", 15);

        graph.Print();
        Console.WriteLine(" Doing DFS ");
        graph.DFS("H1");
        Console.WriteLine(" Doing BFS");
        graph.BFS("H1");
        Console.WriteLine("Cycle =>" + graph.HasCycle);
        Console.Read();
    }
}



