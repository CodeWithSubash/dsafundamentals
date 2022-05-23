using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class ShortestPath
    {
        public static int FindShortestPath(int n, int[][] edges, int src, int dst)
        {
            var graph = GraphHelper.GetAdjacencyListForEdges(n, edges, true);
            GraphHelper.DisplayAdjacencyList(graph);
            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue((src, 0));
            visited.Add(src);
            while (queue.Count > 0)
            {
                (int current, int weight) = queue.Dequeue();
                if (current == dst)
                {
                    return weight;
                }

                foreach (int neighbour in graph[current])
                {
                    // When we are looking on neighbour, we can directly check there and return immediately weight +1
                    //if (neighbour == dst)
                    //{
                    //    return weight+1;
                    //}
                    // Only start adding neighbour, if its not the target node
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(current);
                        queue.Enqueue((neighbour, weight + 1));
                    }
                }
            }
            return -1;
        }
    }
}
