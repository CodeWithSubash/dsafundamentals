using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    public static class SmallestIsland
    {
        public static int SmallIslandAvailable(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int result = rows * cols + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int size = ExploreIsland(i, j, grid);
                    Console.WriteLine(size);
                    if (size != 0)
                    {
                        result = size < result ? size : result;
                    }
                }
            }
            return result;
        }

        private static int ExploreIsland(int i, int j, char[][] grid)
        {
            bool boundsCheck = i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length;

            if (!boundsCheck || grid[i][j] != 'l')
            {
                return 0;
            }
            //Now I found new Land
            int count = 1;
            grid[i][j] = 'v';
            count += ExploreIsland(i + 1, j, grid);
            count += ExploreIsland(i - 1, j, grid);
            count += ExploreIsland(i, j + 1, grid);
            count += ExploreIsland(i, j - 1, grid);

            return count;
        }
    }
}
