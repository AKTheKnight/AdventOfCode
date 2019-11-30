using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2018
{
    public class DayFive : Challenge
    {
        
        private static string Input { get; set; }
        public DayFive() : base(5)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 5)[0];
        }

        public override string SolutionOne()
        {
            return React(Input).Length.ToString();
        }

        public override string SolutionTwo()
        {
            var letters = Input.Select(c => c.ToString().ToUpperInvariant()).Distinct().ToList();
            var lengths = new List<string>();
            
            for (var i = 0; i < letters.Count; i++)
            {
                var input = Input.Replace(letters[i], "");
                input = Input.Replace(letters[i].ToLower(), "");
                
                lengths.Add(React(input));
            }

            return lengths.Min(s => s.Length).ToString();
        }

        private static string React(string input)
        {
            var changes = 1;

            
            while (changes > 0)
            {
                changes = 0;
                for (var i = 0; i < input.Length - 1; i++)
                {
                    if (IsPolar(input[i], input[i + 1]))
                    {
                        input = input.Remove(i, 2);
                        changes++;
                        break;
                    }
                }
            }

            return input;
        }

        private static char[] lowercase = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        
        public static bool IsPolar(char c1, char c2)
        {
            if (char.IsLower(c1))
            {
                var pos = Array.IndexOf(lowercase, c1);
                if (uppercase[pos] == c2)
                    return true;
            }
            
            if (char.IsUpper(c1))
            {
                var pos = Array.IndexOf(uppercase, c1);
                if (lowercase[pos] == c2)
                    return true;
            }

            return false;
        }
    }
}