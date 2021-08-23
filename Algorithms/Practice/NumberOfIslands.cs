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
            int islands = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; i < grid[i].Length; j++)
                {
                    islands += dfs(grid, i, j);
                }
            }

            return islands;
        }

        private int dfs(char[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[j].Length || grid[i][j] == '0')
            {
                return 0;
            }

            grid[i][j] = '0';

            dfs(grid, i + 1, j);
            dfs(grid, i - 1, j);
            dfs(grid, i, j + 1);
            dfs(grid, i, j - 1);

            return 1;
        }
    }
}
