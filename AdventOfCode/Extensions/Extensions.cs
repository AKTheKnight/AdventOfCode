using System;
using System.Collections.Generic;

namespace uk.co.aktheknight.AdventOfCode.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<string> Words(this string input)
        {
            return input.Split(new string[] { " ", "\t", Environment.NewLine, "," }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}