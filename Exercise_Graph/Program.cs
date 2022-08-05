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
                { -1, 15, -1, 35, -1, -1 },
                { 15, -1, 05, 10, -1, -1 },
                { -1, 05, -1, -1, -1, -1 },
                { 35, 10, -1, -1, 05, -1 },
                { -1, -1, -1, 05, -1, 05 },
                { -1, -1, -1, -1, 05, -1 }
        };

        // 다익스트라 알고리즘
        // 가중치가 있을 때 사용
        // 가중치의 합이 가장 작은 경로(ex. 가장 가까운 거리, 시간이 덜 걸리는 거리)를 찾는다.
        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 좋은 후보를 찾는다(가장 가까이에 있는 후보)

                // 가장 유력한 후보의 거리와 번호를 저장한다
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i])
                        continue;
                    // 아직 발견된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 후보 갱신
                    closest = distance[i];
                    now = i;
                }

                // 다음 후보가 없다 -> 종료
                if (now == -1)
                    break;

                // 제일 좋은 후보를 찾았으니까 방문
                visited[now] = true;

                // 방문한 정점과 인접한 정점들을 조사해서, 상황에 따라 발견한 최단거리를 갱신한다.
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 정점 스킵
                    if (adj[now, next] == -1)
                        continue;
                    // 이미 방문한 정점은 스킵
                    if (visited[next])
                        continue;

                    // 새로 조사된 정점의 최단거리를 계산하다.
                    int nextDist = distance[now] + adj[now, next];

                    // 만약 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면, 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
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
            graph.Dijikstra(1);
        }
    }
}