using System;

namespace AdventOfCode.Challenges._2017
{
    public class DayThree2017 : Challenge
    {
        private static int Input { get; set; }
        
        public DayThree2017() : base(3)
        {
            Input = 1;
        }

        public override string SolutionOne()
        {
            const int size = 999;
            var spiral = new int[size, size];

            var max = 325489;
            var num = 1;

            var centre = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);
            var prevCoOrd = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);
            var curCoOrd = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);

            var direction = "R";

            while (num <= max)
            {
                prevCoOrd = new Utils.CoOrd(curCoOrd.x, curCoOrd.y);
                
                spiral[curCoOrd.y, curCoOrd.x] = num;
                //RIGHT, UP, DOWN, LEFT
                switch (direction)
                {
                    case "R":
                        curCoOrd.x++;
                        if (spiral[curCoOrd.y - 1, curCoOrd.x] == 0)
                            direction = "U";
                        break;
                    case "U":
                        curCoOrd.y--;
                        if (spiral[curCoOrd.y, curCoOrd.x - 1] == 0)
                            direction = "L";
                        break;
                    case "L":
                        curCoOrd.x--;
                        if (spiral[curCoOrd.y + 1, curCoOrd.x] == 0)
                            direction = "D";
                        break;
                    case "D":
                        curCoOrd.y++;
                        if (spiral[curCoOrd.y, curCoOrd.x + 1] == 0)
                            direction = "R";
                        break;
                }

                num++;
            }

            var x = Math.Abs(prevCoOrd.x - centre.x);
            var y = Math.Abs(prevCoOrd.y - centre.y);

            var steps = x + y;

            return steps.ToString();
        }

        public override string SolutionTwo()
        {
            const int size = 999;
            var spiral = new int[size, size];

            var max = 325489;
            var num = 1;

            var centre = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);
            var prevCoOrd = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);
            var curCoOrd = new Utils.CoOrd((size - 1) / 2, (size - 1) / 2);

            var direction = "R";

            while (num <= max)
            {
                prevCoOrd = new Utils.CoOrd(curCoOrd.x, curCoOrd.y);
                
                spiral[curCoOrd.y, curCoOrd.x] = num;
                //RIGHT, UP, DOWN, LEFT
                switch (direction)
                {
                    case "R":
                        curCoOrd.x++;
                        if (spiral[curCoOrd.y - 1, curCoOrd.x] == 0)
                            direction = "U";
                        break;
                    case "U":
                        curCoOrd.y--;
                        if (spiral[curCoOrd.y, curCoOrd.x - 1] == 0)
                            direction = "L";
                        break;
                    case "L":
                        curCoOrd.x--;
                        if (spiral[curCoOrd.y + 1, curCoOrd.x] == 0)
                            direction = "D";
                        break;
                    case "D":
                        curCoOrd.y++;
                        if (spiral[curCoOrd.y, curCoOrd.x + 1] == 0)
                            direction = "R";
                        break;
                }

                var sum = 0;
                
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        sum += spiral[curCoOrd.y + i, curCoOrd.x + j];
                    }
                }

                num = sum;
            }

            return num.ToString();
        }
    }
}