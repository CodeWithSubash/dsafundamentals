using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public class HasPath
    {
        public static bool Execute_BFS(Dictionary<int, List<int>> adjList, int source, int destination)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            while (queue.Count != 0)
            {
                int current = queue.Dequeue();
                if (current == destination)
                {
                    return true;
                }
                foreach (int neighbour in adjList[current])
                {
                    queue.Enqueue(neighbour);
                }
            }
            return false;
        }

        public static bool Execute_DFS(Dictionary<int, List<int>> adjList, int source, int destination)
        {
            if (source == destination)
            {
                return true;
            }
            foreach (int neighbour in adjList[source])
            {
                var result = Execute_DFS(adjList, neighbour, destination);
                if (result == true)
                {
                    return true;
                }
            }
            return false;
        }


        public static bool Execute_BFS_Undirected(Dictionary<int, List<int>> adjList, int source, int destination)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            HashSet<int> visited = new HashSet<int>();
            while (queue.Count != 0)
            {
                int current = queue.Dequeue();
                visited.Add(current);
                if (current == destination)
                {
                    return true;
                }
                foreach (int neighbour in adjList[current])
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return false;
        }

        public static bool Execute_DFS_Undirected(Dictionary<int, List<int>> adjList, int source, int destination, HashSet<int> visited)
        {
            if (visited.Contains(source))
            {
                return false;
            }
            visited.Add(source);
            if (source == destination)
            {
                return true;
            }
            foreach (int neighbour in adjList[source])
            {
                var result = Execute_DFS_Undirected(adjList, neighbour, destination, visited);
                if (result == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
