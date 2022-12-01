using System.Linq;

namespace AdventOfCode.Challenges._2022;

public class DayOne2022 : Challenge
{
    private static string Input { get; set; }
    
    public DayOne2022() : base(1)
    {
        Input = Utils.GetInputAsSingleString(2022, 1);
    }
    public override string SolutionOne()
    {
        var items = Input.Split("\r\n\r\n");
        var sumItems = items.Select(x => x.Split("\r\n").Select(int.Parse).Sum());
        var max = sumItems.Max();
        return max.ToString();
    }

    public override string SolutionTwo()
    {
        var items = Input.Split("\r\n\r\n");
        var sumItems = items.Select(x => x.Split("\r\n").Select(int.Parse).Sum()).OrderByDescending(x => x)
            .Take(3).Sum();
        return sumItems.ToString();
    }
}