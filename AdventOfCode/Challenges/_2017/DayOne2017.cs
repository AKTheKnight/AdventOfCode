using System.Linq;

namespace AdventOfCode.Challenges._2017
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
            var sum = Input
                .Where(((c, i) => i < Input.Length - 1))
                .Where((val, i) => val == Input[i + 1])
                .Sum(c => (int) char.GetNumericValue(c));

            if (Input[Input.Length - 1] == Input[0])
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
                
                if (Input[i] == Input[pos2])
                    sum += (int) char.GetNumericValue(Input[i]);
            }

            if (Input[Input.Length - 1] == Input[0])
                sum += (int) char.GetNumericValue(Input[0]);

            return sum.ToString();
        }
    }
}