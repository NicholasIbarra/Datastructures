using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    class NumberofIslands
    {
        public static void Test()
        {
            char[][] grid = new char[4][]
            {
                new char[]{'1', '1', '1', '1', '0'},
                new char[]{'1', '1', '0', '1', '1'},
                new char[]{'1', '1', '0', '0', '0'},
                new char[]{'0', '0', '0', '0', '0'}
            };

            char[][] grid2 = new char[4][]
            {
                new char[]{'1', '1', '0', '0', '0'},
                new char[]{'1', '1', '0', '0', '0'},
                new char[]{'0', '0', '1', '0', '0'},
                new char[]{'0', '0', '0', '1', '1'}
            };

            NumberofIslands solution = new NumberofIslands();

            Console.WriteLine(solution.NumIslands(grid));
            Console.WriteLine(solution.NumIslands(grid2));
        }

        public int NumIslands(char[][] grid)
        {
            if(grid == null || grid.Length == 0)
            {
                return 0;
            }

            int islands = 0;

            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    islands += dfs(grid, r, c);
                }
            }

            return islands;
        }

        private int dfs(char[][] grid, int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length || grid[r][c] == '0')
            {
                return 0;
            }

            grid[r][c] = '0';

            dfs(grid, r + 1, c);
            dfs(grid, r - 1, c);
            dfs(grid, r, c + 1);
            dfs(grid, r, c - 1);

            return 1;
        }
    }
}
