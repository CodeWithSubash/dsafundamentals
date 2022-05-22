using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class LargestConnectedComponent
    {
        public static int FindLargestComponent(int n, int[][] edges)
        {
            var graph = GraphHelper.GetAdjacencyListForEdges(n, edges, true);
            int largest = 0;
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int currentSize = ExploreGraphThroughNode(graph, i, visited);
                if (currentSize > largest)
                {
                    largest = currentSize;
                }
            }
            return largest;
        }

        private static int ExploreGraphThroughNode(Dictionary<int, List<int>> graph, int i, HashSet<int> visited)
        {
            if (visited.Contains(i))
            {
                return 0;
            }
            visited.Add(i);
            int count = 1;
            foreach (int neighbour in graph[i])
            {
                count += ExploreGraphThroughNode(graph, neighbour, visited);
            }
            return count;
        }
    }
}
