using System;
using System.Collections.Generic;

namespace Exercise_Graph
{
    // 스택 : LIFO (후입선출)
    // ex) 마지막으로 켜진 ui가 먼저 꺼져야 할 때

    // 큐 : FIFO (선입선출)
    // ex) 순서를 정해야 할 때

    // 그래프 생성
    class Graph
    {
        // 행렬이용
        int[,] adj = new int[6, 6]
        {
                { 0, 1, 0, 1, 0, 0 },
                { 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0 }
        };

        // 필요한 index 정보만
        List<int>[] adj2 = new List<int>[]
        {
                new List<int>() { 1, 3 },
                new List<int>() { 0, 2, 3 },
                new List<int>() { 1 },
                new List<int>() { 0, 1, 4 },
                new List<int>() { 3, 5 },
                new List<int>() { 4 }
        };

        public void BFS(int start)
        {
            bool[] found = new bool[6];
            // **** 추가정보 ****
            int[] parent = new int[6]; // 어느 방에서 왔는지
            int[] distance = new int[6]; // 이동거리

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (q.Count > 0)
            {
                int now = q.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0) // 인접하지 않았으면 스킵
                        continue;
                    if (found[next]) // 이미 발견한 방이면 스킵
                        continue;
                    q.Enqueue(next);
                    found[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now] + 1;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DFS (Depth First Search, 깊이 우선 탐색)
            // BFS (Breadth First Search, 너비 우선 탐색) -> 거의 길찾기(최단거리)에서만 사용
            Graph graph = new Graph();
            graph.BFS(1);
        }
    }
}