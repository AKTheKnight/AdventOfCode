using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using uk.co.aktheknight.AdventOfCode.Challenges;
using uk.co.aktheknight.AdventOfCode.Challenges._2015;
using uk.co.aktheknight.AdventOfCode.Challenges._2016;
using uk.co.aktheknight.AdventOfCode.Challenges._2017;
using uk.co.aktheknight.AdventOfCode.Challenges._2018;

namespace uk.co.aktheknight.AdventOfCode
{
    internal static class AdventOfCode
    {

        private static Challenge[] _2015;
        private static Challenge[] _2016;
        private static Challenge[] _2017;
        private static Challenge[] _2018;
        
        public static void Main(string[] args)
        {
            _2015 = new Challenge[]
            {
                new DayOne2015(), new DayTwo2015(), new DayThree2015(), new DayFour2015(), new DayFive2015(),
                new DaySix2015(), 
            };

            _2016 = new Challenge[]
            {
                new DayTwo2016(), 
            };
            
            _2017 = new Challenge[]
            {
                new DayOne2017(), new DayTwo2017(), new DayThree2017(), new DayFour2017(), new DayFive2017(),
                new DaySix2017(), new DaySeven2017(), new DayEight2017(), new DayNine2017(), new DayTwelve2017(), 
                new DayFifteen2017(), 
            };

            _2018 = new Challenge[]
            {
                new DayOne(), new DayTwo(), new DayThree(), new DayFour(), 
            };
            
            Challenge[] solutions;
            
            Console.WriteLine("What year would you like to do? (2015-2018)");
            var year = Console.ReadLine();
             
            switch (year)
            {
                case "2015":
                    solutions = _2015;
                    break;
                case "2016":
                    solutions = _2016;
                    break;
                case "2017":
                    solutions = _2017;
                    break;
                default:
                    solutions = _2018;
                    break;
            }
            
            Console.WriteLine("\nWhat day would you like to do? (1-{0})", solutions.Length);
            var day = Console.ReadLine();

            var solution = solutions.FirstOrDefault(sol => sol.Day.ToString() == day);

            if (solution != null)
            {
                CompleteSolution("one", solution.SolutionOne);
                CompleteSolution("two", solution.SolutionTwo);

                Console.ReadLine();
                return;
            }

            Console.WriteLine("\nCould not find that challenge\n\n");
            Main(new string[]{});
        }

        private static void CompleteSolution(string number, Func<string> getSolution)
        {
            var start = NanoTime();

            string result;
            
            try
            {
                result = getSolution();
            }
            catch (NotImplementedException)
            {
                result = "Not Implemented";
            }

            var finish = NanoTime();

            var units = "ns";
            var elapsed = finish - start;
            
            if (elapsed / 1000000 > 1) {
                elapsed = elapsed / 1000000;
                units = "ms";
            }
            
            Console.WriteLine("\nSolution {0}: {1}", number, result);
            Console.WriteLine("Time: {0}{1}", elapsed, units);
        }
        
        private static long NanoTime() {
            var nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}