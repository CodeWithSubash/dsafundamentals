using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class IslandCounter
    {
        public static int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++;
                        ExploreAroundNode(i, j, grid);
                    }
                }
            }
            return count;
        }

        private static void ExploreAroundNode(int i, int j, char[][] grid)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] != '1')
            {
                return;
            }
            grid[i][j] = '2';
            // Explore the 4 neighbours
            ExploreAroundNode(i + 1, j, grid);
            ExploreAroundNode(i - 1, j, grid);
            ExploreAroundNode(i, j + 1, grid);
            ExploreAroundNode(i, j - 1, grid);
        }
    }
}
