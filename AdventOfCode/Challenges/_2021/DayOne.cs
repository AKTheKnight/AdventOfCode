using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021;

public class DayOne2021 : Challenge
{
    private static List<int> Input { get; set; }
    
    public DayOne2021() : base(1)
    {
        Input ??= Utils.GetInput(2021, 1).Select(int.Parse).ToList();
    }

    public override string SolutionOne()
    {
        return Input.Skip(1).Zip(Input, (x, y) => x > y).Count(x => x).ToString();
    }

    public override string SolutionTwo()
    {
        throw new System.NotImplementedException();
    }
}