using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            (int numberOfVertices,int[][] edges) data = GetGraphDataFromFile();
            Graph graphObject1 = new Graph(data.numberOfVertices, data.edges);
            graphObject1.DisplayEdges();

            // Traverse a Graph (DFS, BFS)
            Dictionary<int, List<int>> adjList = CreateAdjacencyList();
            Console.WriteLine("Recursive Depth Traverse :");
            Traversal.DepthFirstPrintRecursive(adjList, 0);
            Console.WriteLine("Iterative Depth Traverse :");
            Traversal.DepthFirstPrint(adjList, 0);
            Console.WriteLine("Graph Breadth Traverse :");
            Traversal.BreadthWise(adjList, 0);
            Console.Read();
        }

        private static Dictionary<int, List<int>> CreateAdjacencyList()
        {
            int[][] ed = { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 4 }, new[] { 1, 3 }, new[] { 3, 5 } };
            return Traversal.GetGraph(6, ed);
        }

        private static (int, int[][]) GetGraphDataFromFile()
        {
            List<string> data = GetAllLines("tinygraph.txt");
            int numberOfVertices = Convert.ToInt32(data[0]);
            int numberOfEdges = Convert.ToInt32(data[1]);

            int[][] edges = new int[numberOfEdges][];
            for (int i = 2; i < data.Count; i++)
            {
                string[] item = data[i].Split(' ');
                edges[i - 2] = new int[] { Convert.ToInt32(item[0]), Convert.ToInt32(item[1]) };
            }
            return (numberOfVertices, edges);
        }

        private static List<string> GetAllLines(string fileName)
        {
            var fullPath = Path.Combine(Environment.CurrentDirectory, fileName);
            return File.ReadAllLines(fullPath).ToList();
        }
    }
}
