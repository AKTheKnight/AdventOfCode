using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2019
{
    public class DayThree2019 : Challenge
    {
        private static List<string> Input { get; set; }
        public DayThree2019() : base(3)
        {
            if (Input == null)
                Input = Utils.GetInput(2019, 3);
        }

        public override string SolutionOne()
        {
            var positions = new Dictionary<Utils.CoOrd, int>();

            var pathnum = 1;
            foreach (var input in Input)
            {
                var path = input.Split(',');
                var pos = new Utils.CoOrd(0, 0);
                foreach (var pathsect in path)
                {
                    var direction = pathsect.Substring(0, 1);
                    var length = int.Parse(pathsect.Substring(1));

                    int newy;
                    int newx;
                    switch (direction)
                    {
                        case "U":
                            newy = pos.y + length;
                            for (var y = pos.y + 1; y <= newy; y++)
                            {
                                var newpos = new Utils.CoOrd(pos.x, y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, pathnum);
                                else
                                {
                                    if (positions[newpos] < pathnum)
                                        positions[newpos] = positions[newpos] + pathnum;
                                }

                                pos.y++;
                            }
                            break;
                        case "D":
                            newy = pos.y - length;
                            for (var y = pos.y -1; y >= newy; y--)
                            {
                                var newpos = new Utils.CoOrd(pos.x, y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, pathnum);
                                else
                                {
                                    if (positions[newpos] < pathnum)
                                        positions[newpos] = positions[newpos] + pathnum;
                                }

                                pos.y--;
                            }
                            break;
                        case "R":
                            newx = pos.x + length;
                            for (var x = pos.x + 1; x <= newx; x++)
                            {
                                var newpos = new Utils.CoOrd(x, pos.y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, pathnum);
                                else
                                {
                                    if (positions[newpos] < pathnum)
                                        positions[newpos] = positions[newpos] + pathnum;
                                }

                                pos.x++;
                            }
                            break;
                        case "L":
                            newx = pos.x - length;
                            for (var x = pos.x - 1; x >= newx; x--)
                            {
                                var newpos = new Utils.CoOrd(x, pos.y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, pathnum);
                                else
                                {
                                    if (positions[newpos] < pathnum)
                                        positions[newpos] = positions[newpos] + pathnum;
                                }

                                pos.x--;
                            }
                            break;
                    }
                }

                pathnum++;
            }

            var crosses = positions.Where(p => p.Value == 3).ToList();
            crosses = crosses.OrderBy(p => Math.Abs(p.Key.x) + Math.Abs(p.Key.y)).ToList();

            return (Math.Abs(crosses[0].Key.x) + Math.Abs(crosses[0].Key.y)).ToString();
        }

        public override string SolutionTwo()
        {
            var positions = new Dictionary<Utils.CoOrd, NumSteps>();

            var pathnum = 1;
            foreach (var input in Input)
            {
                var steps = 0;
                var path = input.Split(',');
                var pos = new Utils.CoOrd(0, 0);
                foreach (var pathsect in path)
                {
                    var direction = pathsect.Substring(0, 1);
                    var length = int.Parse(pathsect.Substring(1));

                    int newy;
                    int newx;
                    switch (direction)
                    {
                        case "U":
                            newy = pos.y + length;
                            for (var y = pos.y + 1; y <= newy; y++)
                            {
                                steps++;
                                var newpos = new Utils.CoOrd(pos.x, y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, new NumSteps(pathnum, steps));
                                else
                                {
                                    if (positions[newpos].pathnum < pathnum)
                                        positions[newpos] = new NumSteps(positions[newpos].pathnum + pathnum, positions[newpos].steps + steps);
                                }

                                pos.y++;
                            }
                            break;
                        case "D":
                            newy = pos.y - length;
                            for (var y = pos.y -1; y >= newy; y--)
                            {
                                steps++;
                                var newpos = new Utils.CoOrd(pos.x, y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, new NumSteps(pathnum, steps));
                                else
                                {
                                    if (positions[newpos].pathnum < pathnum)
                                        positions[newpos] = new NumSteps(positions[newpos].pathnum + pathnum, positions[newpos].steps + steps);
                                }

                                pos.y--;
                            }
                            break;
                        case "R":
                            newx = pos.x + length;
                            for (var x = pos.x + 1; x <= newx; x++)
                            {
                                steps++;
                                var newpos = new Utils.CoOrd(x, pos.y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, new NumSteps(pathnum, steps));
                                else
                                {
                                    if (positions[newpos].pathnum < pathnum)
                                        positions[newpos] = new NumSteps(positions[newpos].pathnum + pathnum, positions[newpos].steps + steps);
                                }

                                pos.x++;
                            }
                            break;
                        case "L":
                            newx = pos.x - length;
                            for (var x = pos.x - 1; x >= newx; x--)
                            {
                                steps++;
                                var newpos = new Utils.CoOrd(x, pos.y);
                                if (!positions.ContainsKey(newpos))
                                    positions.Add(newpos, new NumSteps(pathnum, steps));
                                else
                                {
                                    if (positions[newpos].pathnum < pathnum)
                                        positions[newpos] = new NumSteps(positions[newpos].pathnum + pathnum, positions[newpos].steps + steps);
                                }

                                pos.x--;
                            }
                            break;
                    }
                }

                pathnum++;
            }

            var crosses = positions.Where(p => p.Value.pathnum == 3).ToList();
            crosses = crosses.OrderBy(p => p.Value.steps).ToList();

            return (crosses[0].Value.steps).ToString();
        }

        struct NumSteps
        {
            public NumSteps(int pathnum, int steps)
            {
                this.pathnum = pathnum;
                this.steps = steps;
            }
            
            public int pathnum;
            public int steps;
        }
        
    }
}