using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode.Challenges._2018
{
    public class DayFour : Challenge
    {
        private static List<string> Input { get; set; }

        public DayFour() : base(4)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 4);
        }

        public override string SolutionOne()
        {
            var guard = GetGuards().OrderBy(g => g.MinsAsleep).Last();

            var count = -1;
            var minute = -1;
            
            for (var i = 0; i < guard.Minutes.Length; i++)
            {
                if (guard.Minutes[i] > count)
                {
                    count = guard.Minutes[i];
                    minute = i;
                }
            }

            return (guard.Id * minute).ToString();
        }

        public override string SolutionTwo()
        {
            var guards = GetGuards().OrderBy(g => g.MinsAsleep).ToList();

            var count = -1;
            var minute = -1;
            var id = -1;
            
            foreach (var guard in guards)
            {
                for (var i = 0; i < guard.Minutes.Length; i++)
                {
                    var min = guard.Minutes[i];

                    if (guard.Minutes[i] > count)
                    {
                        id = guard.Id;
                        count = guard.Minutes[i];
                        minute = i;
                    }
                }
            }

            return (id * minute).ToString();
        }

        private static IEnumerable<Guard> GetGuards()
        {
            var records = new List<string>();

            records = Input.OrderBy(r =>
                    DateTime.ParseExact("2018" + r.Substring(5, 12), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture))
                .ToList();

            var currentGuardId = -1;
            Guard guard = null;
            var guards = new List<Guard>();

            for (var i = 0; i < records.Count; i++)
            {
                var record = records[i].Substring(19);

                if (record.EndsWith("begins shift"))
                {
                    currentGuardId = int.Parse(record.Split(' ')[1].Substring(1));

                    guard = guards.FirstOrDefault(g => g.Id == currentGuardId);

                    if (guard == null)
                    {
                        guard = new Guard()
                        {
                            Id = currentGuardId,
                        };
                        guards.Add(guard);
                    }
                }
                else if (record.Contains("falls asleep"))
                {
                    if (i + 1 < records.Count
                        && records[i + 1].Contains("wakes up"))
                    {
                        var startTime = int.Parse(records[i]
                            .Split(' ')[1]
                            .Split(':')[1]
                            .Replace("]", ""));
                        var endTime = int.Parse(records[i + 1]
                            .Split(' ')[1]
                            .Split(':')[1]
                            .Replace("]", ""));
                        for (int j = startTime; j < endTime; j++)
                        {
                            guard.Minutes[j]++;
                        }
                    }
                }
            }

            return guards;
        }
    }

    public class Guard
    {
        public int Id { get; set; }
        public int[] Minutes { get; set; } = new int[60];
        public int Month { get; set; }
        public int Date { get; set; }

        public int MinsAsleep => Minutes.Sum();

        public string FormattedDate => Month + "-" + (Date < 10 ? "0" + Date : "" + Date);
    }
}