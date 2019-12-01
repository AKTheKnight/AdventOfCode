using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2019
{
    public class DayOne2019 : Challenge
    {
        private static List<string> Input { get; set; }
        public DayOne2019() : base(1)
        {
            if (Input == null)
                Input = Utils.GetInput(2019, 1);
        }

        public override string SolutionOne()
        {
            var total = Input
                .Select(s => int.Parse(s))
                .Select(val => ((int) Math.Floor(val / 3.0)) - 2)
                .Sum();

            return total.ToString();
        }

        public override string SolutionTwo()
        {
            var total = 0;
            
            foreach (var s in Input)
            {
                var valtotal = 0;
                var val = int.Parse(s);

                while (val != 0)
                {
                    val = GetFuel(val);
                    valtotal += val;
                }

                total += valtotal;
            }

            return total.ToString();
        }

        private int GetFuel(int s)
        {
            //Divide by 3 and round down then sub 2
            //Max val from 0 or val. COnverts negatives to 0
            return Math.Max(0, ((int) Math.Floor(s / 3.0)) - 2);
        }
        
    }
}