//Tree 

using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
	{

        Data = data;
		Children = new List<TreeNode<T>>();
	}

public int MinHeight()
{
    if (Children == null || Children.Count == 0)
    {
        return 1;
    }
    int height = Int32.MaxValue;
    foreach (var child in Children)
    {
        height = 1+ Math.Min(child.MinHeight(), height);
    }
    return height;
}

public int MaxHeight()
{
    if (Children == null || Children.Count == 0)
    {
        return 1;
    }
    int height = 0;
    foreach (var child in Children)
    {
        height = 1+ Math.Max(child.MaxHeight(), height);
    }
    return height;
}	
}
 
public class BinaryTreeNode<T>
{
    public T Data { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }
    public BinaryTreeNode(T data)
	{

        Data = data;
	}
public int MinHeight()
{
    if (Left == null && Right == null)
    {
        return 1;
    }
    int leftHeight = Left == null ? 0 : Left.MinHeight();
    int rightHeight = Right == null ? 0 : Right.MinHeight();
    return 1+ Math.Min(leftHeight, rightHeight);
}

public int MaxHeight()
{
    if (Left == null && Right == null)
    {
        return 1;
    }
    int leftHeight = Left == null ? 0 : Left.MaxHeight();
    int rightHeight = Right == null ? 0 : Right.MaxHeight();
    return 1 + Math.Max(leftHeight, rightHeight);
}
}
 
public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
    public void Print()
    {
        var maxHeight = Root.MaxHeight();
        Console.WriteLine(" Height => " + maxHeight);
        var levelLists = new List<TreeNode<T>>[maxHeight];
        var list = new List<TreeNode<T>>();
        list.Add(Root);
        levelLists[0] = list;
        int level = 0;
        int width = (int)Math.Pow(2, maxHeight);

        while (true)
        {
            Console.WriteLine();
            int gaps = (width) / (2 * (level + 1));
            if (level + 1 != maxHeight) for (int i = 0; i <= gaps; i++) Console.Write(' ');

            list = new List<TreeNode<T>>();

            foreach (var node in levelLists[level])
            {
                Console.Write(node.Data);
                for (int i = 0; i <= gaps; i++) Console.Write(' ');
                list.AddRange(node.Children);
            }
            if (levelLists[level].Count <= 0)
            {
                break;
            }
            level++;
            levelLists[level] = list;
        }
    }
}


public class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; }

    public void Print()
    {
        var maxHeight = Root.MaxHeight();
        Console.WriteLine(" Height => " + maxHeight);
        var levelLists = new List<BinaryTreeNode<T>>[maxHeight];
        var list = new List<BinaryTreeNode<T>>();
        list.Add(Root);
        levelLists[0] = list;
        int level = 0;
        int width = (int)Math.Pow(2, maxHeight);

        while (true)
        {
            Console.WriteLine();
            int gaps = (width) / (2 * (level + 1));
            if(level + 1 != maxHeight) for (int i = 0; i <= gaps; i++) Console.Write(' ');

            list = new List<BinaryTreeNode<T>>();

            foreach (var node in levelLists[level])
            {
                Console.Write(node.Data);
                for (int i = 0; i <= gaps; i++) Console.Write(' ');
                if(node.Left != null)
                    list.Add(node.Left);

                if (node.Right != null)
                    list.Add(node.Right);
            }
            if (list.Count <= 0)
            {
                break;
            }
            level++;
            levelLists[level] = list;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<int> bTree = new BinaryTree<int>();
        bTree.Root = new BinaryTreeNode<int>(4);
        bTree.Root.Left = new BinaryTreeNode<int>(2);
        bTree.Root.Right = new BinaryTreeNode<int>(6);
        bTree.Root.Left.Left = new BinaryTreeNode<int>(1);
        bTree.Root.Left.Right = new BinaryTreeNode<int>(3);
        bTree.Root.Right.Left = new BinaryTreeNode<int>(5);
        bTree.Root.Right.Right = new BinaryTreeNode<int>(7);
        bTree.Print();
        Console.Read();

    }
}
