using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace AdventOfCode.Challenges._2022;

public class DayTwo2022 : Challenge
{
    private static List<string> Input { get; set; }
    
    public DayTwo2022() : base(2)
    {
        Input = Utils.GetInput(2022, 2);
    }
    public override string SolutionOne()
    {
        var sum = 0;
        foreach (var s in Input)
        {
            sum += GetScore(s.Split(" ")[0], s.Split(" ")[1]);
        }

        return sum.ToString();
    }

    public override string SolutionTwo()
    {
        throw new NotImplementedException();
    }

    static int GetScore(string first, string second)
    {
        return (first + second) switch
        {
            "AX" => 3,
            "AY" => 4,
            "AZ" => 8,
            "BX" => 1,
            "BY" => 5,
            "BZ" => 9,
            "XC" => 2,
            "XY" => 6,
            "CZ" => 7
        };
    }
}