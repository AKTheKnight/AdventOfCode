using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2017
{
    public class DayFive2017 : Challenge
    {
        
        private static List<string> Input { get; set; }
        
        public DayFive2017() : base(5)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 5);
            
            Input.Add("END");
        }

        public override string SolutionOne()
        {
            var input = Input.ToList();
            
            var position = 0;
            var steps = 0;

            var arg = input[position];

            while (arg != "END")
            {
                steps++;

                var step = int.Parse(arg);

                var newVal = step + 1;
                input[position] = (newVal).ToString();
                
                position += step;

                arg = input[position];

            }

            return steps.ToString();
        }

        public override string SolutionTwo()
        {
            var input = Input.ToList();
            
            var position = 0;
            var steps = 0;

            var arg = input[position];

            while (arg != "END")
            {
                steps++;

                var step = int.Parse(arg);

                var newVal = step >= 3 ? step - 1 : step + 1;
                
                input[position] = (newVal).ToString();
                
                position += step;

                arg = input[position];

            }

            return steps.ToString();
        }
    }
}