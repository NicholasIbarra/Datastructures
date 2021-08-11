using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
    On an infinite plane, a robot initially stands at (0, 0) and faces north. The robot can receive one of three instructions:

    "G": go straight 1 unit;
    "L": turn 90 degrees to the left;
    "R": turn 90 degrees to the right.
    The robot performs the instructions given in order, and repeats them forever.

    Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.
    
    https://leetcode.com/problems/robot-bounded-in-circle/
    
     */
    class RobotBoundCircle
    {
        public static void Test()
        {
            RobotBoundCircle solution = new RobotBoundCircle();

            List<string> instructions = new List<string>() { "GGLLGG", "GG", "GL" };

            foreach (string instruction in instructions)
            {
                Console.WriteLine(instruction + ": " + solution.IsRobotBounded(instruction));
            }
        }

        public bool IsRobotBounded(string instructions)
        {
            // norder = 0, east = 1, south = 2, west = 3
            int[][] directions = new int[4][] {
                new int[]{0, 1}, new int[] { 1, 0}, new int[]{ 0, -1}, new int[] { -1, 0}
            };

            int x = 0, y = 0;
            int idx = 0;

            foreach (char i in instructions)
            {
                if (instructions[i] == 'L')
                    idx = (idx + 3) % 4;
                else if (instructions[i] == 'R')
                    idx = (idx + 1) % 4;
                else
                    x += directions[idx][0];
                    y += directions[idx][1];
            }


            // after one cycle, cirlce if robot is back to start or isn't facing north
            return (x == 0 && y == 0) || (idx != 0);
        }
    }
}
