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
                { 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1, 0 }
        };

        // 필요한 index 정보만
        List<int>[] adj2 = new List<int>[]
        {
                new List<int>() { 1, 3 },
                new List<int>() { 0, 2, 3 },
                new List<int>() { 1 },
                new List<int>() { 0, 1 },
                new List<int>() { 5 },
                new List<int>() { 4 }
        };

        bool[] visited = new bool[6];

        // 1) 우선 now부터 방문
        // 2) now와 연결된 정점들을 하나씩 확인해서, 아직 미발견 상태라면 방문
        public void DFS(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;    // 1)

            // 행렬
            for (int next = 0; next < 6; next++)
            {
                if (adj[now, next] == 0)
                    continue;
                if (visited[next])
                    continue;
                DFS(next);
            }
        }

        // index 이용
        public void DFS2(int now)
        {
            Console.WriteLine(now);
            visited[now] = true;

            foreach (int next in adj2[now])
            {
                if (visited[next])
                    continue;
                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];
            for (int now = 0; now < 6; now++)
            {
                if(visited[now] == false)
                    DFS(now);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DFS (Depth First Search, 깊이 우선 탐색)
            // BFS (Breadth First Search, 너비 우선 탐색)
            Graph graph = new Graph();
            graph.SearchAll();
        }
    }
}