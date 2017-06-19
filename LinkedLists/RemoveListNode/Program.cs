//delete middle node in linked list

using System;

namespace DeleteMiddleNode
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
            p.BuildAndDelete(new int[] { 3, 4, 1, 5, 6, 2 });
            Console.Read();
        }

        private void BuildAndDelete(int[] array)
        {
            LinkedListNode list = null;
            LinkedListNode first = null;
            LinkedListNode second = null;
            LinkedListNode last = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list = new LinkedListNode
                {
                    Value = array[i],
                    Next = list
                };
                if (i == 0) first = list;
                if (i == 1) second = list;
                if (i == array.Length - 1) last = list;

            }
            PrintList(list);
            list = DeleteNode(list, second);
            PrintList(list);
            list = DeleteNode(list, first);
            PrintList(list);
           
            list = DeleteNode(list, last);
            PrintList(list);
        }

        private void PrintList(LinkedListNode list)
        {
            Console.WriteLine();
            if (list == null)
            {
                Console.WriteLine("NULL");
            }
            else
            {
                while (list != null)
                {
                    Console.Write(list.Value + " ");
                    list = list.Next;
                }
            }
        }

        private LinkedListNode DeleteNode(LinkedListNode list, LinkedListNode node)
        {
            if (node == null)
            {
                return list;
            }

            if (list == null)
            {
                return null;
            }
            if (list == node)
            {
                return list.Next;
            }

            LinkedListNode head = list;
            if (node.Next != null)
            {
                node.Value = node.Next.Value;
                node.Next = node.Next.Next;
            }
            else
            {
                while (list != null && list.Next != node)
                {
                    list = list.Next;
                }
                if (list != null)
                {
                    list.Next = list.Next.Next;
                }
            }
            return head;
        }
    }
}
