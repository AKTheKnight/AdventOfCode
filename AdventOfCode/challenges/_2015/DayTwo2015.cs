using System.Collections.Generic;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2015
{
    public class DayTwo2015 : Challenge
    {

        private static List<string> Input { get; set; }
        
        public DayTwo2015() : base(2)
        {
            if (Input == null)
                Input = Utils.getInput(2015, 2);
        }

        public override string SolutionOne()
        {
            var total = 0;
            foreach (var present in Input)
            {
                var edges = present.Split('x').Select(int.Parse).ToArray();
                var sides = new int[3];
                for (var i = 0; i < 3; i++)
                {
                    sides[i] = edges[i] * edges[(i + 1) == 3 ? 0 : i + 1];
                }

                var area = sides.Sum(side => 2 * side);
                area += sides.Min();

                total += area;
            }

            return total.ToString();
        }

        public override string SolutionTwo()
        {
            var total = 0;
            foreach (var present in Input)
            {
                var edges = present.Split('x').Select(int.Parse).ToArray();
                var wrap = edges.OrderBy(side => side).Take(2).Sum(side => side * 2);
                var ribbon = edges.Aggregate(1, (x, y) => x * y);

                total += wrap;
                total += ribbon;
            }

            return total.ToString();
        }
    }
}