using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021;

public class DayTwo2021 : Challenge
{
    private static List<string> Input { get; set; }
    
    public DayTwo2021() : base(2)
    {
        Input ??= Utils.GetInput(2021, 2).ToList();
    }

    public override string SolutionOne()
    {
        var horizontal = 0;
        var vertical = 0;
        
        foreach (var data in Input.Select(i => i.Split(' ')))
        {
            switch (data[0])
            {
                case "forward": 
                    horizontal += int.Parse(data[1]);
                    break;
                case "up": 
                    vertical -= int.Parse(data[1]);
                    break;
                case "down":
                    vertical += int.Parse(data[1]);
                    break;
            }
        }

        return (vertical * horizontal).ToString();
    }

    public override string SolutionTwo()
    {
        var horizontal = 0;
        var vertical = 0;

        var aim = 0;
        
        foreach (var data in Input.Select(i => i.Split(' ')))
        {
            switch (data[0])
            {
                case "forward": 
                    horizontal += int.Parse(data[1]);
                    vertical += (aim * int.Parse(data[1]));
                    break;
                case "up": 
                    aim -= int.Parse(data[1]);
                    break;
                case "down":
                    aim += int.Parse(data[1]);
                    break;
            }
        }

        return (vertical * horizontal).ToString();
    }
}