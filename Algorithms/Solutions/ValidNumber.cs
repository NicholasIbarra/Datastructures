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

        public bool IsNumber(string s)
        {
            bool dotIsAllowed = true;
            bool signAllowed = true;
            bool eIsAllowed = true;
            bool numerOrSignIsRequired = false;
            bool numerIsRequired = false;
            bool isSign = false;

            int i = 0;

            foreach (byte b in System.Text.Encoding.UTF8.GetBytes(s.ToCharArray()))
            {
                i++;
                int ascii = int.Parse(b.ToString());

                bool isDigit = ascii >= 48 && ascii <= 57;
                isSign = ascii == 43 || ascii == 45;
                bool isE = ascii == 101 || ascii == 69;
                bool isDot = ascii == 46;

                if (!(isDigit || isSign || isE || isDot))
                    return false;

                if (numerOrSignIsRequired)
                {
                    if (!(isDigit || isSign))
                        return false;
                    else
                    {
                        numerOrSignIsRequired = false;
                        continue;
                    }
                }

                if (numerIsRequired && !isDigit)
                    if (isDot && dotIsAllowed)
                        continue;
                    else

                        return false;

                if (isSign)
                {
                    if (!signAllowed)
                        return false;
                    else
                    {
                        signAllowed = false;
                        numerIsRequired = true;
                    }
                }
                else if(isDot)
                {
                    if (!dotIsAllowed)
                        return false; // a dot was previous detected
                    else
                    {
                        signAllowed = false;
                        dotIsAllowed = false;
                        numerIsRequired = i == 1;
                    }
                }
                else if (isE)
                {
                    if (i == 1 || !eIsAllowed)
                        return false;
                    else
                    {
                        numerOrSignIsRequired = true;
                        dotIsAllowed = false;
                        eIsAllowed = false;
                    }
                }
                else if (isDigit)
                {
                    signAllowed = false;
                    numerIsRequired = false;
                }
            }

            return numerOrSignIsRequired || numerIsRequired || isSign ? false : true;
        }
    }
}
