﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class Traversal
    {
        public static void DepthFirstPrint(Dictionary<int, List<int>> adjList, int source)
        {
            Stack<int> bfs = new Stack<int>();
            bfs.Push(source);
            while (bfs.Count > 0)
            {
                var current = bfs.Pop();
                Console.WriteLine(current);
                foreach (var neighbour in adjList[current])
                {
                    bfs.Push(neighbour);
                }
            }
        }

        public static void DepthFirstPrintRecursive(Dictionary<int, List<int>> adjList, int source)
        {
            Console.WriteLine(source);
            foreach (var neighbour in adjList[source])
            {
                DepthFirstPrintRecursive(adjList, neighbour);
            }
        }

        public static void BreadthWise(Dictionary<int, List<int>> adjList, int source)
        {
            Queue<int> bfs = new Queue<int>();
            bfs.Enqueue(source);
            while (bfs.Count > 0)
            {
                var current = bfs.Dequeue();
                Console.WriteLine(current);
                foreach (var neighbour in adjList[current])
                {
                    bfs.Enqueue(neighbour);
                }
            }
        }

        public static Dictionary<int, List<int>> CreateGraph(int n, int[][] edges, bool directed = true)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                adjList[edges[i][0]].Add(edges[i][1]);
                if (!directed)
                {
                    adjList[edges[i][1]].Add(edges[i][0]);
                }
            }

            return adjList;
        }
    }
}
