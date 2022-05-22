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
            // Basic Graph Construction
            // GraphFundamental();

            // Traverse a Graph (DFS, BFS)
            // ExploreTraversalAlgorithms();

            // Problem1: Has Path Problem
            // GraphHasPathProblem();

            // Problem2: Connected Components Count
            //ConnectedComponentProblem();

            // Problem2: Connected Components Count
            LargestConnectedComponentProblem();

            Console.Read();
        }

        private static void LargestConnectedComponentProblem()
        {
            // https://www.geeksforgeeks.org/number-of-simple-cyclic-components-in-an-undirected-graph/
            var edgeArray = new[] { new[] { 0, 4 }, new[] { 0, 9 }, new[] { 4, 9 }, new[] { 1, 11 }, new[] {1,8 },
            new[]{1,14 }, new[]{ 8,14} ,new[]{ 14,11},new[]{ 1,14},new[]{ 12,7},new[]{ 5,10},new[]{ 10,6},new[]{ 6,2},new[]{ 2,13},
            new[]{ 13,5} };
            int largest = LargestConnectedComponent.FindLargestComponent(15, edgeArray);
            Console.WriteLine($"The largest connected components : {largest}");
        }

        private static void ConnectedComponentProblem()
        {
            var edgeArray = new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 1, 3 }, new[] { 4, 5 } };
            var count = ConnectedComponents.CountComponents(7, edgeArray);
            Console.WriteLine($"The number of connected components : {count}");

            // https://www.geeksforgeeks.org/number-of-simple-cyclic-components-in-an-undirected-graph/
            edgeArray = new[] { new[] { 0, 4 }, new[] { 0, 9 }, new[] { 4, 9 }, new[] { 1, 11 }, new[] {1,8 },
            new[]{1,14 }, new[]{ 8,14} ,new[]{ 14,11},new[]{ 1,14},new[]{ 12,7},new[]{ 5,10},new[]{ 10,6},new[]{ 6,2},new[]{ 2,13},
            new[]{ 13,5} };
            count = ConnectedComponents.CountComponents(15, edgeArray);
            Console.WriteLine($"The number of connected components : {count}");
        }

        private static void GraphHasPathProblem()
        {
            // Input: [[0,1],[1,2],[0,3],[3,1],[4,3],[3,5]]
            var edgeArray = new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 0, 3 }, new[] { 3, 1 }, new[] { 4, 3 }, new[] { 3, 5 } };
            (int source, int destination) = (4, 0);
            Dictionary<int, List<int>> adjList = GraphHelper.GetAdjacencyListForEdges(6, edgeArray, false);
            GraphHelper.DisplayAdjacencyList(adjList);
            bool result;

            Console.WriteLine("Implementing the Directed Acyclic graph problem (BFS+DFS)");
            result = HasPath.Execute_BFS(adjList, source, destination);
            Console.WriteLine($"BFS: There is a path from {source} to {destination} : {result}");
            (source, destination) = (4, 2);
            result = HasPath.Execute_DFS(adjList, source, destination);
            Console.WriteLine($"DFS: There is a path from {source} to {destination} : {result}");

            // Input: [[0,1],[0,2],[2,3],[2,4],[5,6]]
            // Source: https://structy.net/problems/undirected-path
            edgeArray = new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 2, 4 }, new[] { 5, 6 } };
            (source, destination) = (0, 3);
            adjList = GraphHelper.GetAdjacencyListForEdges(7, edgeArray, true);
            GraphHelper.DisplayAdjacencyList(adjList);

            Console.WriteLine("Implementing the UnDirected Cyclic graph problem (BFS+DFS)");
            result = HasPath.Execute_BFS_Undirected(adjList, source, destination);
            Console.WriteLine($"Undirected BFS: There is a path from {source} to {destination} : {result}");
            (source, destination) = (2, 5);
            result = HasPath.Execute_DFS_Undirected(adjList, source, destination, new HashSet<int>());
            Console.WriteLine($"Undirected DFS: There is a path from {source} to {destination} : {result}");

        }

        private static void ExploreTraversalAlgorithms()
        {
            // Mock Data
            var edges = new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 4 }, new[] { 1, 3 }, new[] { 3, 5 } };
            var adjList = GraphHelper.GetAdjacencyListForEdges(6, edges, false);
            Console.WriteLine("Recursive Depth Traverse :");
            Traversal.DepthFirstPrintRecursive(adjList, 0);
            Console.WriteLine("Iterative Depth Traverse :");
            Traversal.DepthFirstPrint(adjList, 0);
            Console.WriteLine("Graph Breadth Traverse :");
            Traversal.BreadthWise(adjList, 0);
        }

        private static void GraphFundamental()
        {
            (int numberOfVertices, int[][] edges) data = GetGraphDataFromFile();
            Graph graphObject1 = new Graph(data.numberOfVertices, data.edges);
            graphObject1.DisplayEdges();
        }

        #region Helper Methods
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
        #endregion
    }
}
