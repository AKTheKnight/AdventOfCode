using System;
using System.Collections.Generic;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2018
{
    public class DayOne : Challenge
    {
        
        private static List<string> Input { get; set; }
        
        public DayOne() : base(1)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 1);
        }

        public override string SolutionOne()
        {
            var frequency = Input.Sum(int.Parse);
            
            return frequency.ToString();
        }

        public override string SolutionTwo()
        {
            var frequency = 0;
            List<int> frequencies = new List<int>();
            
            for (var i = 0; i < Input.Count; i++)
            {
                frequency += Int32.Parse(Input[i]);

                //Console.WriteLine(i + " " + frequency);
                if (frequencies.Contains(frequency))
                    return frequency.ToString();
                
                frequencies.Add(frequency);
                
                if (i == Input.Count - 1)
                    i = -1;
            }

            return "No idea";
        }
    }
}