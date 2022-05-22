using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class GraphHelper
    {
        public static Dictionary<int, List<int>> GetAdjacencyListForEdges(int n, int[][] edges, bool isUndirected = false)
        {
            // construct the dictionary of each nodes with empty edges
            Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                data.Add(i, new List<int>());
            }
            foreach (var edge in edges)
            {
                data[edge[0]].Add(edge[1]);
                if (isUndirected)
                {
                    data[edge[1]].Add(edge[0]);
                }
            }
            return data;
        }

        public static void DisplayAdjacencyList(Dictionary<int, List<int>> data)
        {
            foreach(var kvp in data)
            {
                Console.WriteLine($"{kvp.Key} : [{string.Join(",",kvp.Value)}]");
            }
        }
    }
}
