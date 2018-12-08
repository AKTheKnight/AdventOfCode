using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using uk.co.aktheknight.AdventOfCode.Extensions;

/**
 * https://dylansmith.visualstudio.com/adventofcode2018/_git/AdventOfCode2018?path=%2Fsrc%2FDay07.cs&version=GBmaster
 */

namespace uk.co.aktheknight.AdventOfCode.Challenges._2018
{
    public class DaySeven : Challenge
    {
        private static List<string> Input { get; set; }

        public DaySeven() : base(7)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 7);
        }

        public override string SolutionOne()
        {
            var dependencies = new List<(string pre, string post)>();

            Input.ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

            var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct()
                .OrderBy(x => x).ToList();
            var result = string.Empty;

            while (allSteps.Any())
            {
                var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).First();

                result += valid;

                allSteps.Remove(valid);
                dependencies.RemoveAll(d => d.pre == valid);
            }

            return result;
            throw new System.NotImplementedException();
        }

        public override string SolutionTwo()
        {
            var dependencies = new List<(string pre, string post)>();

            Input.ForEach(x => dependencies.Add((x.Words().ElementAt(1), x.Words().ElementAt(7))));

            var allSteps = dependencies.Select(x => x.pre).Concat(dependencies.Select(x => x.post)).Distinct()
                .OrderBy(x => x).ToList();
            var workers = new List<int>(5) {0, 0, 0, 0, 0};
            var currentSecond = 0;
            var doneList = new List<(string step, int finish)>();

            while (allSteps.Any() || workers.Any(w => w > currentSecond))
            {
                foreach (var tuple in doneList.Where(d => d.finish <= currentSecond))
                {
                    dependencies.RemoveAll(d => d.pre == tuple.step);
                }

                doneList.RemoveAll(d => d.finish <= currentSecond);

                var valid = allSteps.Where(s => !dependencies.Any(d => d.post == s)).ToList();

                for (var w = 0; w < workers.Count && valid.Any(); w++)
                {
                    if (workers[w] <= currentSecond)
                    {
                        workers[w] = GetWorkTime(valid.First()) + currentSecond;
                        allSteps.Remove(valid.First());
                        doneList.Add((valid.First(), workers[w]));
                        valid.RemoveAt(0);
                    }
                }

                currentSecond++;
            }

            return currentSecond.ToString();
        }

        private static int GetWorkTime(string v)
        {
            return (v[0] - 'A') + 61;
        }

    }
}