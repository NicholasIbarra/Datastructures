using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Practice
{
    /*
     A valid number can be split up into these components (in order):

        A decimal number or an integer.
        (Optional) An 'e' or 'E', followed by an integer.
        A decimal number can be split up into these components (in order):

        (Optional) A sign character (either '+' or '-').
        One of the following formats:
        One or more digits, followed by a dot '.'.
        One or more digits, followed by a dot '.', followed by one or more digits.
        A dot '.', followed by one or more digits.
        An integer can be split up into these components (in order):

        (Optional) A sign character (either '+' or '-').
        One or more digits.
        For example, all the following are valid numbers: ["2", "0089", "-0.1", "+3.14", "4.", 
                "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"], 
    
        while the following are not valid numbers: 
            ["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].

        Given a string s, return true if s is a valid number.

    https://leetcode.com/problems/valid-number/
    
     */
    public class ValidNumber
    {
        public static void Test()
        {
            ValidNumber solution = new ValidNumber();

            List<string> validInput = new List<string>() { "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789", "4.", "+.8" };
            List<string> invalidInput = new List<string>() { "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53", "3+", ".", "4e+", "+." };

            Console.WriteLine("Should return true\n");

            foreach (string i in validInput)
            {
                var shouldBeTrue = solution.IsNumber(i).ToString();
                Console.WriteLine(i + " Result: " + shouldBeTrue);
            }

            Console.WriteLine("\nShould return false\n");

            foreach (string i in invalidInput)
            {
                Console.WriteLine(i + " Result: " + solution.IsNumber(i).ToString());
            }

            string input = "..2";
            Console.WriteLine(solution.IsNumber(input));
        }

        private class State
        {
            public bool IsValidEndState { get; set; }
            public Func<char, State> NextState { get; set; }

            public static bool IsSign (char c) { return c == '+' || c == '-'; }
            public static bool IsExp (char c) { return c == 'e' || c == 'E'; }
            public static bool IsDot (char c) { return c == '.'; }
            public static bool IsNum (char c) { return char.IsNumber(c); }
        }

        private State Init;

        private State Number;
        private State Dot;
        private State Sign;

        private State Decimal;
        private State Exp;

        private State OnlyInts;
        private State DecimalSign;

        private State Invalid;

        private bool IsNumber(string input)
        {

            Init = new State
            {
                IsValidEndState = false,
                NextState = c =>
                {
                    if (State.IsNum(c)) return Number;
                    if (State.IsDot(c)) return Dot;
                    if (State.IsSign(c)) return Sign;

                    return Invalid;
                }
            };

            Number = new State
            {
                IsValidEndState = true,
                NextState = c =>
                {
                    if (State.IsNum(c)) return Number;
                    if (State.IsDot(c)) return Decimal;
                    if (State.IsExp(c)) return Exp;

                    return Invalid;
                }
            };

            Sign = new State
            {
                IsValidEndState = false,
                NextState = c =>
                {
                    if (State.IsNum(c)) return Number;
                    if (State.IsDot(c)) return Dot;
                    return Invalid;
                }
            };

            Dot = new State
            {
                IsValidEndState = false,
                NextState = c =>
                {
                    if (State.IsNum(c)) return Decimal;
                    return Invalid;
                }
            };

            Decimal = new State
            {
                IsValidEndState = true,
                NextState = c =>
                {
                    if (State.IsNum(c)) return Decimal;
                    if (State.IsExp(c)) return Exp;
                    return Invalid;
                }
            };

            Exp = new State
            {
                IsValidEndState = false,
                NextState = c =>
                {
                    if (State.IsNum(c)) return OnlyInts;
                    if (State.IsSign(c)) return DecimalSign;
                    return Invalid;
                }
            };

            OnlyInts = new State
            {
                IsValidEndState = true,
                NextState = c =>
                {
                    if (State.IsNum(c)) return OnlyInts;
                    return Invalid;
                }
            };

            DecimalSign = new State
            {
                IsValidEndState = false,
                NextState = c =>
                {
                    if (State.IsNum(c)) return OnlyInts;
                    return Invalid;
                }
            };


            Invalid = new State();

            // Run through rules
            State state = Init;

            foreach(char c in input)
            {
                state = state.NextState(c);

                if (state.Equals(Invalid))
                {
                    return false;
                }
            }

            return state.IsValidEndState;
        }
    }
}
