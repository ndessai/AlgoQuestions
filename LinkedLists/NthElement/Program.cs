//nth element search

using System;

namespace NthElementSearch
{
    public class LinkedListNode
    {
        public LinkedListNode Next { get; set; }
        public int Value { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.BuildListAndPrint(new int[] { 1, 2, 3, 4, 5, 6 });
            Console.Read();
        }

        private void BuildListAndPrint(int[] array)
        {
            LinkedListNode list = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list = new LinkedListNode
                {
                    Next = list,
                    Value = array[i]
                };
                Console.Write(array[i]);
            }
            Console.WriteLine();
        
        LinkedListNode nth = null;
        nth = GetNthLastNode(list, 3);
        Console.WriteLine("3 => " + ( nth == null? "null " : nth.Value.ToString()));
			nth = GetNthLastNode(list, 1);
        Console.WriteLine("1 => " + ( nth == null? "null " : nth.Value.ToString()));
			nth = GetNthLastNode(list, 8);
        Console.WriteLine("8 => " + ( nth == null? "null " : nth.Value.ToString()));
			
		}

    private LinkedListNode GetNthLastNode(LinkedListNode list, int n)
    {
        LinkedListNode current = list;
        LinkedListNode nthNode = list;

        for (int i = 0; i < n - 1; i++)
        {
            if (current == null)
            {
                return null;
            }
            current = current.Next;
        }

        while (current.Next != null)
        {
            current = current.Next;
            nthNode = nthNode.Next;
        }
        return nthNode;
    }
}
}
