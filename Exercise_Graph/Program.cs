using System;
using System.Collections.Generic;

namespace Exercise_Graph
{
    // 스택 : LIFO (후입선출)
    // ex) 마지막으로 켜진 ui가 먼저 꺼져야 할 때

    // 큐 : FIFO (선입선출)
    // ex) 순서를 정해야 할 때
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Stack<int> stack = new Stack<int>();

                stack.Push(101);
                stack.Push(102);
                stack.Push(103);
                stack.Push(104);
                stack.Push(105);

                int data = stack.Pop();
                int data2 = stack.Peek();

                int cnt = stack.Count;

                Console.WriteLine(cnt);
            }

            {
                Queue<int> queue = new Queue<int>();

                queue.Enqueue(101);
                queue.Enqueue(102);
                queue.Enqueue(103);
                queue.Enqueue(104);
                queue.Enqueue(105);

                int data3 = queue.Dequeue();
                int data4 = queue.Peek();
            }

        }
    }
}