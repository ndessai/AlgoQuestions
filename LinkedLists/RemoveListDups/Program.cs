//Remove duplicates from unsorted list

using System;

namespace RemoveLinkedListDuplicate
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
            p.CreateListAndRemoveDups(new int[]{ 2, 5, 6, 7, 9, 1, 2, 4, 5, 7, 8, 8, 9, 2});
            p.CreateListAndRemoveDups(new int[]{ 2, 5, 6, 7, 9, 1, 3, 0, 0, 8, 9, 2});
            Console.Read();
        }

        private void CreateListAndRemoveDups(int[] array)
        {
            Console.WriteLine();
            LinkedListNode list = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list = new LinkedListNode
                {
                    Next = list,
                    Value = array[i]
                };
            }
            LinkedListNode current = list;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine("After duplicate removed");
            RemoveDups(list);
            current = list;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }

        }

        private void RemoveDups(LinkedListNode head)
        {
            LinkedListNode current = head.Next;
            LinkedListNode runner = head;
            LinkedListNode previous = head;
            while (current != null)
            {
                runner = head;
                while (runner != current)
                {
                    if (runner.Value == current.Value)
                    {
                        previous.Next = current.Next;
                        break;
                    }
                    runner = runner.Next;
                }
                if (runner == current)
                {
                    previous = current;
                }
                current = current.Next;
                
            }
        }
    }
}
