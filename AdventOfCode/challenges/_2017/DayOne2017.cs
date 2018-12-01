using System;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2017
{
    public class DayOne2017 : Challenge
    {
        
        private static string Input { get; set; }
        
        public DayOne2017() : base(1)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 1)[0];
        }

        public override string SolutionOne()
        {
            var sum = 0;
            for (var i = 0; i < Input.Length - 1; i++)
            {
                //If the char at a position is equal to the one next to it then add it to the sum
                if ((int) char.GetNumericValue(Input[i]) == (int) char.GetNumericValue(Input[i + 1]))
                    sum += (int) char.GetNumericValue(Input[i]);
            }

            //Does the end char equal the first char
            if ((int) char.GetNumericValue(Input[Input.Length - 1]) == (int) char.GetNumericValue(Input[0]))
                sum += (int) char.GetNumericValue(Input[0]);

            return sum.ToString();
        }

        public override string SolutionTwo()
        {
            var sum = 0;
            var step = Input.Length / 2;
            for (var i = 0; i < Input.Length - 1; i++)
            {
                var pos2 = i + step;
                if (pos2 >= Input.Length)
                    pos2 -= Input.Length;
                
                if ((int) char.GetNumericValue(Input[i]) == (int) char.GetNumericValue(Input[pos2]))
                    sum += (int) char.GetNumericValue(Input[i]);
            }

            if ((int) char.GetNumericValue(Input[Input.Length - 1]) == (int) char.GetNumericValue(Input[Input.Length - step]))
                sum += (int) char.GetNumericValue(Input[0]);

            return sum.ToString();
        }
    }
}