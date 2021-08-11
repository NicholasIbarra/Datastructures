using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
    Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
    
    An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically.
    You may assume all four edges of the grid are all surrounded by water.

    https://leetcode.com/problems/number-of-islands/
    */
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

        private int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int islands = 0;

            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    islands += Dfs(grid, r, c);
                }
            }

            return islands;
        }

        private int Dfs(char[][] grid, int r, int c)
        {
            if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length || grid[r][c] == '0')
                return 0;

            grid[r][c] = '0';

            Dfs(grid, r - 1, c);
            Dfs(grid, r + 1, c);
            Dfs(grid, r, c + 1);
            Dfs(grid, r, c - 1);

            return 1;
        }
    }

}
