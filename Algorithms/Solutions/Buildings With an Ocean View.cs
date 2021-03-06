using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
        There are n buildings in a line. You are given an integer array heights of size n 
        that represents the heights of the buildings in the line.

        The ocean is to the right of the buildings. A building has an ocean view if
        the building can see the ocean without obstructions. Formally, a building has an ocean view if all the buildings to its right have a smaller height.

        Return a list of indices (0-indexed) of buildings that have an ocean view, sorted in increasing order.

        https://leetcode.com/problems/buildings-with-an-ocean-view/
    
     */
    class Buildings_With_an_Ocean_View
    {
        public static void Test()
        {
            Buildings_With_an_Ocean_View solution = new Buildings_With_an_Ocean_View();

            Console.WriteLine(string.Join(",", solution.FindBuildings(new int[] { 4, 2, 3, 1 })));
        }

        public int[] FindBuildings(int[] heights)
        {
            List<int> ls = new List<int>();
            int last = int.MinValue;

            for (int i = heights.Length - 1; i >= 0; i--)
            {
                if (heights[i] > last)
                {
                    ls.Add(i);
                    last = heights[i];
                }
            }

            int index = 0;
            int[] answer = new int[ls.Count];

            for(int i = ls.Count - 1; i >= 0; i--)
            {
                answer[index] = ls[i];
                index++;
            }

            return answer;
        }
    }
}
