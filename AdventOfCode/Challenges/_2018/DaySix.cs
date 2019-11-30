using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2018
{
    public class DaySix : Challenge
    {
        private static List<string> Input { get; set; }

        public DaySix() : base(6)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 6);
        }

        public override string SolutionOne()
        {
            var coordinates = Input
                .Select(s => s.Split(new[] { ", " }, StringSplitOptions.None))
                .Select(s => s.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(c => (x: c[0], y: c[1]))
                .ToList();
            
            var maxX = coordinates.Max(c => c.x);
            var maxY = coordinates.Max(c => c.y);
        
            var grid = new int[maxX + 2, maxY + 2];

            for (int x = 0; x <= maxX + 1; x++)
            {
                for (int y = 0; y <= maxY + 1; y++)
                {
                    var distances = coordinates
                        .Select((c, i) => (i, dist: Math.Abs(c.x - x) + Math.Abs(c.y - y)))
                        .OrderBy(c => c.dist)
                        .ToArray();

                    grid[x, y] = distances[1].dist != distances[0].dist
                        ? distances[0].Item1
                        : -1;
                }
            }
            
            var excluded = new List<int>();
            var counts = Enumerable.Range(-1, coordinates.Count + 1).ToDictionary(i => i, _ => 0);

            for (int x = 0; x <= maxX + 1; x++)
            for (int y = 0; y <= maxY + 1; y++)
            {
                if (x == 0 || y == 0 ||
                    x == maxX + 1 || y == maxY + 1)
                {
                    excluded.Add(grid[x, y]);
                }
                counts[grid[x, y]] += 1;
            }

            excluded = excluded.Distinct().ToList();
            var output = counts
                .Where(kvp => !excluded.Contains(kvp.Key))
                .Max(kvp => kvp.Value);

            return output.ToString();
            throw new System.NotImplementedException();
        }

        public override string SolutionTwo()
        {
            var coordinates = Input
                .Select(s => s.Split(new[] { ", " }, StringSplitOptions.None))
                .Select(s => s.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(c => (x: c[0], y: c[1]))
                .ToList();
            
            var maxX = coordinates.Max(c => c.x);
            var maxY = coordinates.Max(c => c.y);
        
            var grid = new int[maxX + 2, maxY + 2];
            var safeCount = 0;

            for (int x = 0; x <= maxX + 1; x++)
            {
                for (int y = 0; y <= maxY + 1; y++)
                {
                    var distances = coordinates
                        .Select((c, i) => (i, dist: Math.Abs(c.x - x) + Math.Abs(c.y - y)))
                        .OrderBy(c => c.dist)
                        .ToArray();

                    grid[x, y] = distances[1].dist != distances[0].dist
                        ? distances[0].Item1
                        : -1;
                    
                    if (distances.Sum(c => c.dist) < 10000)
                        safeCount++;
                }
            }

            return safeCount.ToString();
        }
    }
}