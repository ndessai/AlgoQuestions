//given linked list, find the beginning of cycle

using System;

namespace CycleBeginning
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
            LinkedListNode list = p.BuildList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            LinkedListNode last = list;
            LinkedListNode cycle = null;
            while (last.Next != null) last = last.Next;
            var third = list.Next.Next.Next;
            var fourth = list.Next.Next.Next.Next;

            cycle = p.GetCycleBeginnning(list);
            if (cycle == null)
            {
                Console.WriteLine("NULL");
            }

            last.Next = third;
            cycle = p.GetCycleBeginnning(list);
            if (cycle == null)
            {
                Console.WriteLine("NULL");
            }
            else
            {
                Console.WriteLine(cycle.Value);
            }

            last.Next = fourth;
            cycle = p.GetCycleBeginnning(list);
            if (cycle == null)
            {
                Console.WriteLine("NULL");
            }
            else
            {
                Console.WriteLine(cycle.Value);
            }

            Console.Read();
        }

        private LinkedListNode GetCycleBeginnning(LinkedListNode list)
        {
            if (list == null || list.Next == null)
            {
                return null;
            }
            var first = list;
            var second = list;
            while (second.Next != null)
            {
                second = second.Next.Next;
                first = first.Next;
                if (first == second || second.Next == null)
                {
                    break;
                }
            }
            if (first != second)
            {
                return null;
            }
            first = list;
            while (first != second)
            {
                first = first.Next;
                second = second.Next;
            }
            return first;
        }

        private LinkedListNode BuildList(int[] array)
        {
            LinkedListNode list = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list = new LinkedListNode { Next = list, Value = array[i] };
            }
            return list;
        }
    }
}
