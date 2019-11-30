using System;
using System.Collections.Generic;

namespace AdventOfCode.Challenges._2017
{
    public class DayNine2017 : Challenge
    
    {
        private static string Input { get; set; }

        public DayNine2017() : base(9)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 9)[0];
        }

        public override string SolutionOne()
        {
            var sum = 0;

            var group = 0;

            var line = RemoveExcessClosing(Input);
                
            for (var i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '{':
                        group++;
                        sum += group;
                        break;
                    case '}':
                        group--;
                        break;
                }
            }

            return sum.ToString();
        }

        public override string SolutionTwo()
        {
            throw new NotImplementedException();
        }

        struct StartAndFinish
        {
            public StartAndFinish(int start, int finish)
            {
                this.start = start;
                this.finish = finish;
            }
            
            public int start { get; }
            public int finish { get; }
        }

        private static string RemoveExcessClosing(string input)
        {
            var output = input + "";
            
            var locations = new List<StartAndFinish>();
            
            var garbageStart = -1;
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '<'
                    && garbageStart == -1)
                {
                    garbageStart = i;
                }
                else if (input[i] == '>'
                         && garbageStart != -1)
                {
                    if (input[i - 1] != '!')
                    {
                        locations.Add(new StartAndFinish(garbageStart, i));
                        garbageStart = -1;
                    }
                    else
                    {
                        var current = i;
                        var count = 0;
                        while (input[current - 1] == '!')
                        {
                            count++;
                            current--;
                        }

                        if (count % 2 == 0)
                        {
                            locations.Add(new StartAndFinish(garbageStart, i));
                            garbageStart = -1;
                        }
                    }
                }
            }

            locations.Reverse();
            foreach (var startAndFinish in locations)
            {
                output = output.Remove(startAndFinish.start, startAndFinish.finish - startAndFinish.start);
            }

            return output;
        }
        
        private object CountGarbage(string input)
        {
            var output = input + "";
            
            var locations = new List<StartAndFinish>();
            
            var garbageStart = -1;
            
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '<'
                    && garbageStart == -1)
                {
                    garbageStart = i;
                }
                else if (input[i] == '>'
                         && garbageStart != -1)
                {
                    if (input[i - 1] != '!')
                    {
                        locations.Add(new StartAndFinish(garbageStart, i));
                        garbageStart = -1;
                    }
                    else
                    {
                        var current = i;
                        var count = 0;
                        while (input[current - 1] == '!')
                        {
                            count++;
                            current--;
                        }

                        if (count % 2 == 0)
                        {
                            locations.Add(new StartAndFinish(garbageStart, i));
                            garbageStart = -1;
                        }
                    }
                }
            }

            var garbageText = new List<string>();

            locations.Reverse();
            foreach (var startAndFinish in locations)
            {
                garbageText.Add(output.Substring(startAndFinish.start + 1 , startAndFinish.finish - startAndFinish.start));
            }
            
            for (var j = 0; j < garbageText.Count; j++)
            {
                var garbage = @garbageText[j];
                Console.WriteLine(garbage);
                
                locations = new List<StartAndFinish>();
                
                for (var i = 0; i < garbage.Length; i++)
                {
                    if (garbage[i] != '!') continue;
                    
                    var current = i;
                    var count = 1;
                    while (garbage[current] == '!')
                    {
                        count++;
                        current++;
                    }

                    if (count % 2 != 0)
                    {
                        count++;
                    }

                    if (count > 0)
                    {
                        locations.Add(new StartAndFinish(i, count));

                        i += (count);
                    }
                }

                locations.Reverse();
                var garbage2 = garbage;
                foreach (var startAndFinish in locations)
                {
                    garbage2 = garbage2.Remove(startAndFinish.start, startAndFinish.finish);
                }

                Console.WriteLine(garbage2);
                Console.WriteLine(garbage);
                Console.WriteLine("Apple");
            }

            var sumGarbage = 0;
            
            foreach (var s in garbageText)
            {
                sumGarbage += s.Length;
            }
            
            Console.WriteLine(sumGarbage);

            return sumGarbage;
        }
        
    }
}