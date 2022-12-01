using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021;

public class DayThree2021 : Challenge
{
    private static List<string> Input { get; set; }
    
    public DayThree2021() : base(3)
    {
        Input ??= Utils.GetInput(2021, 3).ToList();
    }

    public override string SolutionOne()
    {
        var str = "";
        for (var i = 0; i < Input[0].Length; i++)
        {
            var zero = 0;
            var one = 0;
            foreach (var s in Input)
            {
                var ss = s.Substring(i, 1);
                if (ss.Equals("0"))
                {
                    zero++;
                }
                else
                {
                    one++;
                }

            }

            str += zero > one ? "0" : "1";
        }

        var gamma = Convert.ToInt32(str, 2);
        var epsilon = Convert.ToInt32(new string(str.Select(s => s == '0' ? '1' : '0').ToArray()), 2);
        
        return (gamma * epsilon).ToString();
    }

    public override string SolutionTwo()
    {
        throw new System.NotImplementedException();
    }
}