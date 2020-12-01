using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2020
{
    public class DayOne2020 : Challenge
    {
        private static List<int> Input { get; set; }
        public DayOne2020() : base(1)
        {
            if (Input == null)
                Input = Utils.GetInput(2020, 1).Select(int.Parse).ToList();
        }

        public override string SolutionOne()
        {
            var (i, j) = GetTwoValues();

            return (i * j).ToString();
        }

        public override string SolutionTwo()
        {
            var (i, j, k) = GetThreeValues();

            return (i * j * k).ToString();
        }

        private static (int, int) GetTwoValues()
        {
            foreach (var i in Input)
            {
                foreach (var j in Input)
                {
                    if (i + j == 2020)
                    {
                        return (i, j);
                    }
                }
            }

            return (0, 0);
        }

        private static (int, int, int) GetThreeValues()
        {
            foreach (var i in Input)
            {
                foreach (var j in Input)
                {
                    foreach (var k in Input)
                    {
                        if (i + j + k == 2020)
                        {
                            return (i, j, k);
                        }
                    }
                }
            }

            return (0, 0, 0);
        }
        
    }
}