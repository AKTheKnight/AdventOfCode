using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2019
{
    public class DayTwo2019 : Challenge
    {
        private static string Input { get; set; }

        public DayTwo2019() : base(2)
        {
            if (Input == null)
                Input = Utils.GetInput(2019, 2)[0];
        }

        public override string SolutionOne()
        {
            var vals = Input.Split(',').Select(int.Parse).ToList();

            vals[1] = 12;
            vals[2] = 2;

            var pos = 0;
            while (true)
            {
                var op = vals[pos];
                if (op == 99)
                    break;

                var val2 = vals[vals[pos + 1]];
                var val3 = vals[vals[pos + 2]];
                var outputpos = vals[pos + 3];
                var outputVal = 0;

                switch (op)
                {
                    case 1:
                        vals[outputpos] = val2 + val3;
                        break;
                    case 2:
                        vals[outputpos] = val2 * val3;
                        break;
                    default:
                        break;
                }

                pos += 4;
            }

            Console.WriteLine(string.Join(",", vals));
            return vals[0].ToString();
        }

        public override string SolutionTwo()
        {
            for (int noun = 0; noun < 99; noun++)
            {
                for (int verb = 0; verb < 99; verb++)
                {
                    var vals = Input.Split(',').Select(int.Parse).ToList();
                    vals = RunProgram(vals, noun, verb);

                    if (vals[0] == 19690720)
                        return (100 * noun + verb).ToString();
                }
            }

            return 69.ToString();
        }

        private List<int> RunProgram(List<int> vals, int noun, int verb)
        {
            vals[1] = noun;
            vals[2] = verb;

            var pos = 0;
            while (true)
            {
                var op = vals[pos];
                if (op == 99)
                    break;

                var val2 = vals[vals[pos + 1]];
                var val3 = vals[vals[pos + 2]];
                var outputpos = vals[pos + 3];
                var outputVal = 0;

                switch (op)
                {
                    case 1:
                        vals[outputpos] = val2 + val3;
                        break;
                    case 2:
                        vals[outputpos] = val2 * val3;
                        break;
                    default:
                        break;
                }

                pos += 4;
            }

            return vals;
        }

    }
}