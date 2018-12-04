using System;
using System.Collections.Generic;
using System.Linq;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2015
{
    public class DaySix2015 : Challenge
    {
        
        private static List<string> Input { get; set; }

        public DaySix2015() : base(6)
        {
            if (Input == null)
                Input = Utils.GetInput(2015, 6);
        }
        
       
        
        public override string SolutionOne()
        {
            var lights = new bool[1000, 1000];
            
            foreach (var s in Input)
            {
                var line = s.Replace(" through ", "-");
                if (line.StartsWith("toggle"))
                {
                    var coOrds = line.Replace("toggle ", "").Split('-');

                    var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                    var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                    for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                    {
                        for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                        {
                            if (lights[i, j])
                                lights[i, j] = false;
                            else
                                lights[i, j] = true;
                        }
                    }
                }
                else
                {
                    line = line.Replace("turn ", "");
                    //Turn on
                    if (line.StartsWith("on"))
                    {
                        var coOrds = line.Replace("on ", "").Split('-');

                        var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                        var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                        for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                        {
                            for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                            {
                                if (!lights[i, j])
                                    lights[i, j] = true;
                            }
                        }
                    }
                    //Turn off
                    else
                    {
                        var coOrds = line.Replace("off ", "").Split('-');

                        var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                        var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                        for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                        {
                            for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                            {
                                if (lights[i, j])
                                    lights[i, j] = false;
                            }
                        }
                    }
                }
            }
            
            var num = 0;
                
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    if (lights[i, j])
                        num++;
                }
            }

            return num.ToString();
        }

        public override string SolutionTwo()
        {
            var lights = new int[1000, 1000];
            
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    lights[i, j] = 0;
                }
            }
            
            foreach (var s in Input)
            {
                var line = s.Replace(" through ", "-");
                if (line.StartsWith("toggle"))
                {
                    var coOrds = line.Replace("toggle ", "").Split('-');

                    var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                    var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                    for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                    {
                        for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                        {
                            lights[i, j] += 2;
                        }
                    }
                }
                else
                {
                    line = line.Replace("turn ", "");
                    //Turn on
                    if (line.StartsWith("on"))
                    {
                        var coOrds = line.Replace("on ", "").Split('-');

                        var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                        var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                        for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                        {
                            for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                            {
                                lights[i, j] += 1;
                            }
                        }
                    }
                    //Turn off
                    else
                    {
                        var coOrds = line.Replace("off ", "").Split('-');

                        var coOrd1 = coOrds[0].Split(',').Select(int.Parse).ToArray();
                        var coOrd2 = coOrds[1].Split(',').Select(int.Parse).ToArray();

                        for (var i = coOrd1[0]; i <= coOrd2[0]; i++)
                        {
                            for (var j = coOrd1[1]; j <= coOrd2[1]; j++)
                            {
                                if (lights[i,j] > 0)
                                    lights[i, j] -= 1;
                            }
                        }
                    }
                }
            }
            
            var num = 0;
                
            for (var i = 0; i < 1000; i++)
            {
                for (var j = 0; j < 1000; j++)
                {
                    num += lights[i, j];
                }
            }

            return num.ToString();
        }
    }
}