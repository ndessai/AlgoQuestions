//add numbers represented by linked list with least significant as list head

// 567+ 894 =  1461 =>  7->6->5     4 ->9 ->8  === 1->6->4->1


using System;

namespace AdditionUsingLists
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
            LinkedListNode first = p.BuildList(new int[] { 7, 6, 5 });
            LinkedListNode second = p.BuildList(new int[] { 4, 9, 8 });
            LinkedListNode sum = p.AddLists(first, second, 0);
            p.PrintList(first);
            p.PrintList(second);
            p.PrintList(sum);
            Console.Read();

        }

        private LinkedListNode AddLists(LinkedListNode first,
                        LinkedListNode second, int carry)
        {
            LinkedListNode sum = new LinkedListNode();
            int value = carry;
            if (first != null)
            {
                value += first.Value;
            }
            if (second != null)
            {
                value += second.Value;
            }
            if (value == 0)
            {
                return null;
            }
            sum.Value = value % 10;
            sum.Next = AddLists(first == null ? null : first.Next,
                        second == null ? null : second.Next,
                        value > 10 ? 1 : 0);
            return sum;
        }

        private LinkedListNode BuildList(int[] array)
        {
            LinkedListNode list = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                list = new LinkedListNode { Value = array[i], Next = list };
            }
            return list;
        }

        private void PrintList(LinkedListNode list)
        {
            Console.WriteLine();
            while (list != null)
            {
                Console.Write(list.Value + " ");
                list = list.Next;
            }
        }
    }
}
