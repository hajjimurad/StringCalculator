using System;
using System.Linq;
using System.Collections.Generic;

namespace StringCalculator
{
    class StringCalculator
    {
        internal int Add(string source)
        {
            if (source == "")
                return 0;

            char[] delimiters;
            if (source.StartsWith("//"))
            {
                delimiters = new char[] { source[2] };
                source = source.Substring(3);
            }
            else
            {
                delimiters = new char[] { ',', '\n' };
            }

            IEnumerable<int> numbersInt = GetNumbersFromString(source, delimiters);

            if (numbersInt.Any(item => item < 0))
                throw new ArgumentException("Has negatives");

            return numbersInt.Aggregate((sum, item) => item + sum);
        }

        private static IEnumerable<int> GetNumbersFromString(string source, char[] delimiters)
        {
            var numbersRaw = source.Split(delimiters);
            var numbersInt = numbersRaw.Select(item => int.Parse(item));

            return numbersInt;
        }
    }
}
