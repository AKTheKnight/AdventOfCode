using System.Collections.Generic;

namespace AdventOfCode.Challenges._2018
{
    public class DayThree : Challenge
    {
        private static List<string> Input { get; set; }

        public DayThree() : base(3)
        {
            if (Input == null)
                Input = Utils.GetInput(2018, 3);
        }

        public override string SolutionOne()
        {
            var size = 1000;

            var area = new int[size, size];

            //0,0 is top left
            //x,y

            foreach (var input in Input)
            {
                var parts = input.Split(' ');

                var leftOffset = int.Parse(parts[2].Split(',')[0]);
                var topOffset = int.Parse(parts[2].Split(',')[1].Split(':')[0]);

                var width = int.Parse(parts[3].Split('x')[0]);
                var height = int.Parse(parts[3].Split('x')[1]);

                for (var x = leftOffset; x < leftOffset + width; x++)
                {
                    for (var y = topOffset; y < topOffset + height; y++)
                    {
                        area[x, y]++;
                    }
                }
            }

            var num = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    /*if (area[i,j] == 0)
                        Console.Write(".");
                    else
                        Console.Write(area[i,j]);*/

                    if (area[i, j] > 1)
                        num++;
                }

                /*Console.Write("\n");*/
            }

            return num.ToString();
        }

        public override string SolutionTwo()
        {
            var size = 1000;

            var area = new int[size, size];

            //0,0 is top left
            //x,y

            foreach (var input in Input)
            {
                var parts = input.Split(' ');

                var leftOffset = int.Parse(parts[2].Split(',')[0]);
                var topOffset = int.Parse(parts[2].Split(',')[1].Split(':')[0]);

                var width = int.Parse(parts[3].Split('x')[0]);
                var height = int.Parse(parts[3].Split('x')[1]);

                for (var x = leftOffset; x < leftOffset + width; x++)
                {
                    for (var y = topOffset; y < topOffset + height; y++)
                    {
                        area[x, y]++;
                    }
                }
            }

            var outputId = 0;

            //Check if all the values are 1
            foreach (var input in Input)
            {
                var parts = input.Split(' ');

                var id = int.Parse(parts[0].Split('#')[1]);
                var overlap = false;
                
                var leftOffset = int.Parse(parts[2].Split(',')[0]);
                var topOffset = int.Parse(parts[2].Split(',')[1].Split(':')[0]);

                var width = int.Parse(parts[3].Split('x')[0]);
                var height = int.Parse(parts[3].Split('x')[1]);

                for (var x = leftOffset; x < leftOffset + width; x++)
                {
                    for (var y = topOffset; y < topOffset + height; y++)
                    {
                        if (area[x, y] > 1)
                            overlap = true;
                    }
                }

                if (!overlap)
                    outputId = id;
            }

            return outputId.ToString();
        }
    }
}