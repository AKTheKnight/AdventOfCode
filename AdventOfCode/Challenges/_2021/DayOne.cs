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
        //If we combine the threes into a list, we can use the same function (Group by threes, then compare 1-2)
        var vals = new List<int>();
        for (var i = 1; i < Input.Count - 1; i++)
        {
            vals.Add(Input[i-1]+Input[i]+Input[i+1]);
        }

        return vals.Skip(1).Zip(vals, (x, y) => x > y).Count(x => x).ToString();
    }
}