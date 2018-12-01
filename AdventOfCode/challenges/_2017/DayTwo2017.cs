using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2017
{
    public class DayTwo2017 : Challenge
    {
        
        private static List<string> Input { get; set; }

        public DayTwo2017() : base(2)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 2);
        }

        public override string SolutionOne()
        {
            var sum = 0;
            
            foreach (var line in Input)
            {
                var numbers = line.Split('\t').Select(int.Parse).ToList();

                var max = numbers.Max();
                var min = numbers.Min();

                var dif = max - min;

                sum += dif;
            }

            return sum.ToString();
        }

        public override string SolutionTwo()
        {
            var sum = 0;

            Lines:
            foreach (var line in Input)
            {
                var numbers = line.Split('\t').Select(int.Parse).ToList();

                foreach (var number1 in numbers)
                {
                    foreach (var number2 in numbers)
                    {
                        if (number1 <= number2)
                            continue;

                        if ((number1 % number2) == 0)
                            sum += number1 / number2;
                    }
                }
            }

            return sum.ToString();
        }
    }
}