//Tree 

using System;
using System.Collections.Generic;

public class BinaryTreeNode<T> where T : IComparable<T>
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
        return 1 + Math.Min(leftHeight, rightHeight);
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


public class BinaryTree<T> where T : IComparable<T>, new()
{
    public BinaryTreeNode<T> Root { get; set; }
    public BinaryTreeNode<T> Dummy { get; set; }

    public BinaryTree()
    {
        Dummy = new BinaryTreeNode<T>(new T());
    }

    public BinaryTreeNode<T> Search(T data) 
    {
        var current = Root;
        while (current != null)
        {
            var result = current.Data.CompareTo(data);
            if (result == 0)
            {
                return current;
            }
            current = result > 0 ? current.Left : current.Right;
        }
        return current;
    }

    public void Insert(T data)
    {
        BinaryTreeNode<T> node = new BinaryTreeNode<T>(data);
        BinaryTreeNode<T> current = Root;
        BinaryTreeNode<T> parent = null;
        int result = 0;
        while (current != null)
        {
            result = current.Data.CompareTo(data);
            parent = current;
            current = result >0 ? current.Left : current.Right;
        }
        if (parent == null)
        {
            Root = node;
            return;
        }
         result = data.CompareTo(parent.Data);
        if (result <= 0)
            parent.Left = node;
        else
            parent.Right = node;

    }

    public void Delete(T data)
    {
        //1. No right child, replace parent.Left/Right = current.Left;
        //2. No left child of the right child parent.Left/Right = current.Right;
        //3. otherwise parent.Left/Right = leftmost child of right child
        int result =0;
        if (Root == null)
        {
            return;
        }
        
        BinaryTreeNode<T> current = Root;
        BinaryTreeNode<T> parent = null;
        while (current != null)
        {
            result = data.CompareTo(current.Data);
            if (result == 0)
            {
                break;
            }
            parent = current;
            current = (result <= 0) ? current.Left : current.Right;
            
        }
        if (current == null)
        {
            return;
        }
        //case 1. right child is null
        if (current.Right == null)
        {
            if(parent == null)
            {
                Root = current.Left;
                return;
            }
            if (parent.Left == current)
            {
                parent.Left = current.Left;
            }
            else
            {
                parent.Right = current.Left;
            }
            return;
        }

        //case 2. Left of right child is null
        if (current.Right.Left == null)
        {
            current.Right.Left = current.Left;
            if (parent == null)
            {
                Root = current.Right;
                return;
            }
            
            if (parent.Left == current)
            {
                parent.Left = current.Right;
            }
            else
            {
                parent.Right = current.Right;
            }
            return;
        }

        //case 3. right has left child
        BinaryTreeNode<T> leftMost = current.Right.Left;
        BinaryTreeNode<T> leftMostParent = current.Right;
        while (leftMost.Left != null)
        {
            leftMostParent = leftMostParent.Left;
            leftMost = leftMostParent.Left;
        }
        leftMostParent.Left = leftMost.Right;
        leftMost.Left = current.Left;
        leftMost.Right = current.Right;
        if(parent == null)
        {
            Root = leftMost;
            return;
        }
        if (parent.Left == current)
        {
            parent.Left = leftMost;
        }
        else
        {
            parent.Right = leftMost;
        }
    }

    public void PreOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node == null) return;
        Console.Write(node.Data + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }

    public void InOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node == null) return;
        InOrderTraversal(node.Left);
        Console.Write(node.Data + " ");
        InOrderTraversal(node.Right);
    }

    public void PostOrderTraversal(BinaryTreeNode<T> node)
    {
        if (node == null) return;
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.Write(node.Data + " ");

    }


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
            if (level + 1 != maxHeight) for (int i = 0; i <= gaps; i++) Console.Write(' ');

            list = new List<BinaryTreeNode<T>>();
            
            foreach (var node in levelLists[level])
            {
                if(node == Dummy)
                {
                    for (int i = 0; i <= gaps; i++) Console.Write(' ');
                    continue;
                }
                Console.Write(node.Data);
                for (int i = 0; i <= gaps; i++) Console.Write(' ');
                if (node.Left != null)
                    list.Add(node.Left);
                else
                    list.Add(Dummy);

                if (node.Right != null)
                    list.Add(node.Right);
                else
                    list.Add(Dummy);
            }
            if (list.Count <= 0)
            {
                break;
            }
            var temp = new List<BinaryTreeNode<T>>();
            foreach(var n in list)
            {
                if(n != Dummy)
                {
                    temp.Add(n);
                }
            }
            if (temp.Count <= 0)
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
        //bTree.Root = new BinaryTreeNode<int>(4);
        //bTree.Root.Left = new BinaryTreeNode<int>(2);
        //bTree.Root.Right = new BinaryTreeNode<int>(6);
        //bTree.Root.Left.Left = new BinaryTreeNode<int>(1);
        //bTree.Root.Left.Right = new BinaryTreeNode<int>(3);
        //bTree.Root.Right.Left = new BinaryTreeNode<int>(5);
        //bTree.Root.Right.Right = new BinaryTreeNode<int>(7);
        int[] array = new int[] { 4,2,6,1,3,5,7};
        foreach(var item in array)
        {
            bTree.Insert(item);
        }
        bTree.Print();
        Console.WriteLine();
        bTree.PostOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.PreOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.InOrderTraversal(bTree.Root);
        Console.WriteLine();
        Console.WriteLine();

        bTree.Insert(9);
        bTree.Insert(0);
        bTree.Print();
        Console.WriteLine();
        bTree.PostOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.PreOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.InOrderTraversal(bTree.Root);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine();

       // bTree.Delete(0);
        bTree.Delete(4);

        // bTree.Insert(0);
        bTree.Print();
        Console.WriteLine();
        bTree.PostOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.PreOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.InOrderTraversal(bTree.Root);
        Console.WriteLine();


        Console.WriteLine();
        Console.WriteLine();

        bTree.Insert(10);
        bTree.Print();
        Console.WriteLine();
        bTree.PostOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.PreOrderTraversal(bTree.Root);
        Console.WriteLine();
        bTree.InOrderTraversal(bTree.Root);
        Console.WriteLine();

        Console.Read();
    }
}
