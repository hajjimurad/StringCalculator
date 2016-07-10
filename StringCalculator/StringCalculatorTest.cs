using NUnit.Framework;
using System;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private static StringCalculator GetStringClaculator()
        {
            return new StringCalculator();
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator sc = GetStringClaculator();
            int result = sc.Add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        public void Add_OneNumber_ReturnsNumber(string number, int expected)
        {
            StringCalculator sc = GetStringClaculator();
            int result = sc.Add(number);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        public void Add_TwoNumbersDelimited_ReturnsSum(string numbers, int expected)
        {
            StringCalculator sc = GetStringClaculator();
            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1,2\n3\n4", 10)]
        public void Add_NumbersSeparatedByNewLineAndCommas_ReturnsSum(string numbers, int expected)
        {
            StringCalculator sc = GetStringClaculator();
            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("//;\n1;2;3;4", 10)]
        public void Add_NumbersSeparatedBySpecifiedDelimiter_ReturnsSum(string numbers, int expected)
        {
            StringCalculator sc = GetStringClaculator();
            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_NegativeNumber_ReturnsExceptionWithMessage()
        {
            StringCalculator sc = GetStringClaculator();

            TestDelegate testDelegate = delegate ()
            {
                sc.Add("0,-1");
            };

            var exception = Assert.Throws<ArgumentException>(testDelegate);
            Assert.AreEqual("Has negatives", exception.Message);
        }
    }
}
