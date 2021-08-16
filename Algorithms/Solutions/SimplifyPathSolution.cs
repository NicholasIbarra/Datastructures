using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
    /*
     Given a string path, which is an absolute path (starting with a slash '/') to a file or directory in a Unix-style file system, 
    convert it to the simplified canonical path.

    In a Unix-style file system, a period '.' refers to the current directory, a double period '..' 
    refers to the directory up a level, and any multiple consecutive slashes (i.e. '//') are treated as a 
    single slash '/'. For this problem, any other format of periods such as '...' are treated as file/directory names.

    The canonical path should have the following format:

    The path starts with a single slash '/'.
    Any two directories are separated by a single slash '/'.
    The path does not end with a trailing '/'.
    The path only contains the directories on the path from the root directory to the target file or
        directory (i.e., no period '.' or double period '..')
    Return the simplified canonical path.
    
    https://leetcode.com/problems/simplify-path/
     */
    class SimplifyPathSolution
    {
        public static void Test()
        {
            SimplifyPathSolution solution = new SimplifyPathSolution();

            List<string> paths = new List<string> { "/home//foo/", "/home/", "/../",  "/a/./b/../../c/" };

            foreach(string path in paths)
            {
                Console.WriteLine(path + " -> " + solution.SimplifyPath(path));
            }
        }

        public string SimplifyPath(string path)
        {
            Stack<string> stack = new Stack<string>();
            string[] components = path.Split("/");

            foreach(string directory in components)
            {
                if (directory == "." || string.IsNullOrEmpty(directory))
                {
                    // No operation to be done, current folder
                    continue;
                }
                else if(directory == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(directory);
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (string dir in stack)
            {
                result.Insert(0, dir);
                result.Insert(0, "/");
            }

            return result.Length > 0 ? result.ToString() : "/";
        }
    }
}
