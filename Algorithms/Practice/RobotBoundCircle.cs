using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
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
            throw new NotImplementedException();
        }
    }
}
