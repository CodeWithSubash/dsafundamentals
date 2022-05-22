using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class ConnectedComponents
    {
        public static int CountComponents(int n, int[][] edges)
        {
            var graph = GraphHelper.GetAdjacencyListForEdges(n, edges, true);
            int count = 0;
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                count += ExploreGraphThroughNode(graph, i, visited);
            }
            return count;
        }

        private static int ExploreGraphThroughNode(Dictionary<int, List<int>> graph, int i, HashSet<int> visited)
        {
            if (visited.Contains(i))
            {
                return 0;
            }
            // Its not visited, and we are now going to visit it
            visited.Add(i);
            foreach (var neighbour in graph[i])
            {
                ExploreGraphThroughNode(graph, neighbour, visited);
            }
            return 1;
        }
    }
}
