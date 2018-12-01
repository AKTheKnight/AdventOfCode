using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2015
{
    public class DayFive2015 : Challenge
    {
        
        private static List<string> Input { get; set; }
        
        public DayFive2015() : base(5)
        {
            if (Input == null)
                Input = Utils.GetInput(2015, 5);
        }
        
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
        string[] naughtys = {"ab", "cd", "pq", "xy"};

        public override string SolutionOne()
        {
            var num = 0;
            
            foreach (var line in Input)
            {
                //Not enough vowels
                if (line.Count(c => vowels.Contains(c)) < 3)
                    continue;

                var doubleChar = false;
                
                for (var i = 0; i < line.Length -1; i++)
                {
                    if (line[i] == line[i + 1])
                        doubleChar = true;
                }
                
                if (!doubleChar)
                    continue;

                var naughty = false;
                
                foreach (var n in naughtys)
                {
                    if (line.Contains(n))
                        naughty = true;
                }
                
                if (naughty)
                    continue;

                num++;
            }

            return num.ToString();
        }

        private string letters = "abcdefghijklmnopqrstuvwxyz";

        public override string SolutionTwo()
        {
            var pairs = (from letter1 in letters from letter2 in letters select letter1.ToString() + letter2).ToList();

            var num = 0;
            
            foreach (var line in Input)
            {
                var hasPair = false;

                foreach (var pair in pairs)
                {
                    if ((line.Length - line.Replace(pair, "").Length) < 4)
                        continue;

                    hasPair = true;
                }
                
                if (!hasPair)
                    continue;

                var repeatLetter = false;
                
                for (var i = 0; i < line.Length - 2; i++)
                {
                    if (line[i] == line[i + 2])
                        repeatLetter = true;
                }
                
                if (!repeatLetter)
                    continue;
                
                
                num++;
            }

            return num.ToString();
        }
    }
}