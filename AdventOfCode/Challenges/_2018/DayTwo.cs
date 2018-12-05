using System;
using System.Collections.Generic;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2018
{
    public class DayTwo : Challenge
    {
        private static List<string> Input { get; set; }
        
        public DayTwo() : base(2)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 2);
        }

        public override string SolutionOne()
        {
            var twos = Input.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 2));
            var threes = Input.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 3));

            var checksum = twos * threes;
            return checksum.ToString();
        }

        public override string SolutionTwo()
        {
            var smallestDiff = int.MaxValue;
            var wordOne = "";
            var wordTwo = "";
            
            foreach (var word1 in Input)
            {
                foreach (var word2 in Input)
                {
                    if (word1 == word2)
                        continue;
                    
                    var differences = word1.Where((t, i) => t != word2[i]).Count();
                
                    if (differences < smallestDiff)
                    {
                        wordOne = word1;
                        wordTwo = word2;
                        smallestDiff = differences;
                    }
                }
            }

            var output = "";
            
            for (var i = 0; i < wordOne.Length; ++i)
            {
                if (wordOne[i] == wordTwo[i])
                {
                    output += wordOne[i];
                }
            }

            return output;
        }
    }
}