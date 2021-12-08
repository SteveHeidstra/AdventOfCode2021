using System;
using System.Collections.Generic;

namespace Kerstpuzzel
{
    public static class Numbers
    {
        /// <summary>
        /// Determines if the provided number is a prime number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>true/false</returns>
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Determines if the given number is part of the fibonacci sequence
        /// </summary>
        /// <param name="number"></param>
        /// <returns>true/false</returns>
        public static bool IsFibonacci(int number)
        {
            List<int> fiblist = GetFibonacciSequence(number.ToString().Length);
            return fiblist.Contains(number);
        }

        /// <summary>
        /// Builds a hashset of fibonacci numbers untill the desired number of digits
        /// </summary>
        /// <param name="maxDigits">Number of digits to stop at</param>
        /// <returns>HashSet of int -> fibonacci sequence numbers</returns>
        public static List<int> GetFibonacciSequence(int maxDigits)
        {
            return buildFibonacciRecursive(0, 1, maxDigits, new List<int>());
        }

        private static List<int> buildFibonacciRecursive(int a, int b, int maxDigits, List<int> list )
        {
            if (a.ToString().Length <= maxDigits)
            {
                list.Add(a);
                return buildFibonacciRecursive(b, a + b, maxDigits, list);
            }
            return list;
        }

        public static string DecimalToDifferentBase(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        public static long DifferentBaseToDecimal(string numberInBase, int radix)
        {
            switch (radix)
            {
                case 2:
                    return Convert.ToInt64(numberInBase, 2);
                case 8:
                    return Convert.ToInt64(numberInBase, 8);
                case 10:
                    return Convert.ToInt64(numberInBase, 10);
                case 16:
                    return Convert.ToInt64(numberInBase, 16);

                default:
                    throw new NotImplementedException();
                    
            }           
        }

        public static Int64 Factorial(Int64 f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}
