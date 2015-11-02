using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.StringCalculator
{
    public class StringCalculator
    {
        public static int Calculate(string numbers)
        {
            if (numbers == string.Empty) return 0;
            var numbersFirstChar = 0;
            var delimiters = new List<string>();

            if (numbers.StartsWith("//["))
            {
                var delimiterEndTag = 0;
                while (numbers.IndexOf('[', delimiterEndTag) > 0)
                {
                    var delimiterStartTag = numbers.IndexOf('[', delimiterEndTag) + 1;
                    delimiterEndTag = numbers.IndexOf(']', delimiterStartTag);
                    delimiters.Add(numbers.Substring(delimiterStartTag, delimiterEndTag - delimiterStartTag));
                    numbersFirstChar = delimiterEndTag + 1;
                }
            }
            else if (numbers.StartsWith("//"))
            {
                numbersFirstChar = 3;
                delimiters.Add(numbers.Substring(2, 1));   
            }
            else
            {
                delimiters.Add(",");
                delimiters.Add("\n");
            }

            numbers = numbers.Substring(numbersFirstChar, numbers.Length - numbersFirstChar);
            var numbersArray = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            if(numbersArray.Any(x => int.Parse(x) < 0)) throw new ArgumentException();
            var sum = numbersArray.Sum(s => int.Parse(s) > 1000 ? 0: int.Parse(s));            
            return sum;
        }
    }
}
