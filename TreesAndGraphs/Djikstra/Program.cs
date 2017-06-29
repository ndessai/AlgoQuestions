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
    public Node<T> GetNextNearestNode(List<Node<T>> nodeList, Dictionary<Node<T>, int> distances)
    {
        if (nodeList == null || nodeList.Count <= 0) return null;

        Node<T> nearestNode = null;
        foreach (var node in nodeList)
        {
            if (nearestNode == null) { nearestNode = node; continue; }
            if (distances[node] < distances[nearestNode]) nearestNode = node;
        }
        nodeList.Remove(nearestNode);
        return nearestNode;
    }

    public void Djikstras(T from)
    {
        var nodeDistances = new Dictionary<Node<T>, int>();
        foreach (var node in Nodes)
        {
            nodeDistances.Add(node, (node == FindNode(from)) ? 0 : Int32.MaxValue);
        }

        var routes = new Dictionary<Node<T>, Node<T>>();
        List<Node<T>> nodeList = new List<Node<T>>(Nodes);
        Node<T> nearestNode = GetNextNearestNode(nodeList, nodeDistances);
        while (nearestNode != null)
        {
            int i = 0;
            foreach (var neighbor in nearestNode.Neighbors)
            {
                var cost = nearestNode.Costs[i++];

                if (nodeDistances[neighbor] > nodeDistances[nearestNode] + cost.Value)
                {
                    nodeDistances[neighbor] = nodeDistances[nearestNode] + cost.Value;
                    routes[neighbor] = nearestNode;
                }
            }
            nearestNode = GetNextNearestNode(nodeList, nodeDistances);
        }

        //Printing distance table
        Console.WriteLine("Printing distance tables");
        foreach (var key in nodeDistances.Keys)
        {
            Console.WriteLine();
            Console.Write(key.Data + "  " + nodeDistances[key]);
            Node<T> fromDict = null;
            if (routes.TryGetValue(key, out fromDict))
            {
                while (fromDict != null)
                {
                    Console.Write("\t\t" + fromDict.Data);
                    routes.TryGetValue(fromDict, out fromDict);
                }
            }
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

        graph.Djikstras("NY");
        Console.Read();
    }
}



