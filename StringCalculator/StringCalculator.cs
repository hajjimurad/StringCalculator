using System.Linq;

namespace StringCalculator
{
    class StringCalculator
    {
        internal int Add(string source)
        {
            if (source == "")
                return 0;

            var numbersRaw = source.Split(',');            
            var numbersInt = numbersRaw.Select(item => int.Parse(item));

            return numbersInt.Aggregate((sum, item) => item + sum);
        }
    }
}
