using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure.Algorithms.Solutions
{
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

            public static bool IsSign(char c)
            {
                return c == '+' || c == '-';
            }

            public static bool IsExp(char c)
            {
                return c == 'e' || c == 'E';
            }

            public static bool IsDot(char c)
            {
                return c == '.';
            }

            public static bool IsDigit(char c)
            {
                return Char.IsDigit(c);
            }
        }

        private State Init;
        private State Decimal;
        private State Number;
        private State OnlyInts;
        private State Dot;
        private State Sign;
        private State Exp;
        private State DecimalSign;
        private State Invalid;


        public bool IsNumber(string s)
        {
            Init = new State
            {
                NextState =
                    c =>
                    {
                        if (State.IsDigit(c)) return Number;
                        if (State.IsSign(c)) return Sign;
                        if (State.IsDot(c)) return Dot;
                        return Invalid;
                    },
                IsValidEndState = false
            };

            Sign = new State
            {
                NextState =
                    c =>
                    {
                        if (State.IsDigit(c)) return Number;
                        if (State.IsDot(c)) return Dot;
                        return Invalid;
                    },
                IsValidEndState = false
            };

            DecimalSign = new State
            {
                NextState =
                    c => State.IsDigit(c) ? OnlyInts : Invalid,
                IsValidEndState = false
            };

            Dot = new State
            {
                NextState =
                    c => State.IsDigit(c) ? Decimal : Invalid,
                IsValidEndState = false
            };

            Number = new State
            {
                NextState =
                    c =>
                    {
                        if (State.IsDigit(c)) return Number;
                        if (State.IsExp(c)) return Exp;
                        if (State.IsDot(c)) return Decimal;
                        return Invalid;
                    },
                IsValidEndState = true
            };

            Decimal = new State
            {
                NextState =
                    c =>
                    {
                        if (State.IsDigit(c)) return Decimal;
                        if (State.IsExp(c)) return Exp;
                        return Invalid;
                    },
                IsValidEndState = true
            };

            Exp = new State
            {
                NextState =
                    c =>
                    {
                        if (State.IsDigit(c)) return OnlyInts;
                        if (State.IsSign(c)) return DecimalSign;
                        return Invalid;
                    },
                IsValidEndState = false
            };

            OnlyInts = new State
            {
                NextState =
                    c => State.IsDigit(c) ? OnlyInts : Invalid,
                IsValidEndState = true
            };

            Invalid = new State();

            State state = Init;
            foreach (char c in s)
            {
                state = state.NextState(c);
                if (state.Equals(Invalid)) return false;
            }
            return state.IsValidEndState;
        }
    }
}
