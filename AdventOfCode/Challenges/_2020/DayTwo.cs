using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges._2020
{
    public class DayTwo2020 : Challenge
    {
        private static List<string> Input { get; set; }
        public DayTwo2020() : base(2)
        {
            if (Input == null)
                Input = Utils.GetInput(2020, 2);
        }

        private const String Pattern1 = @"(?<min>[0-9]*)-(?<max>[0-9]*) (?<letter>[a-z]): (?<password>[a-z]*)";
        
        public override string SolutionOne()
        {
            var correctCount = 0;
            
            foreach (var s in Input)
            {
                var matches = Regex.Matches(s, Pattern1, RegexOptions.IgnoreCase);
                var min = int.Parse(matches[0].Groups["min"].Value);
                var max = int.Parse(matches[0].Groups["max"].Value);
                var letter = matches[0].Groups["letter"].Value;
                var password = matches[0].Groups["password"].Value;

                var passwordChar = password
                    .ToCharArray()
                    .GroupBy(x => x)
                    .Select(d => new {d.Key, Count = d.Count()})
                    .FirstOrDefault(e => e.Key == char.Parse(letter));

                if (passwordChar is null)
                {
                    continue;
                }

                if (passwordChar.Count <= max && passwordChar.Count >= min)
                {
                    correctCount++;
                }
            }

            return correctCount.ToString();
        }
        
        private const String Pattern2 = @"(?<first>[0-9]*)-(?<second>[0-9]*) (?<letter>[a-z]): (?<password>[a-z]*)";

        public override string SolutionTwo()
        {
            var correctCount = 0;
            
            foreach (var s in Input)
            {
                var matches = Regex.Matches(s, Pattern2, RegexOptions.IgnoreCase);
                var first = int.Parse(matches[0].Groups["first"].Value);
                var second = int.Parse(matches[0].Groups["second"].Value);
                var letter = char.Parse(matches[0].Groups["letter"].Value);
                var password = matches[0].Groups["password"].Value;

                var firstChar = password.ToCharArray()[first - 1];
                var secondChar = password.ToCharArray()[second - 1];

                if (firstChar == letter && secondChar != letter)
                {
                    correctCount++;
                    continue;
                }
                
                if (firstChar != letter && secondChar == letter)
                {
                    correctCount++;
                    continue;
                }

            }

            return correctCount.ToString();
        }

    }
}