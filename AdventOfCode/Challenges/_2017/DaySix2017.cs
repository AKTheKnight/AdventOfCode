using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2017
{
    public class DaySix2017 : Challenge
    {
        
        private static string Input { get; set; }
        
        public DaySix2017() : base(6)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 6)[0];
        }

        public override string SolutionOne()
        {
            var line = string.Copy(Input);
            //Console.WriteLine(line);

            var lines = new List<string>();
            var count = 0;

            while (!lines.Contains(line))
            {
                count++;
                lines.Add(line);
                var nums = line.Split('\t').Select(int.Parse).ToList();
                
                var maxPos = nums.IndexOf(nums.Max());
                var num = nums.Max();

                nums[maxPos] = 0;
                
                for (var i = 1; i <= num; i++)
                {
                    var pos = maxPos + i;
                    while (pos >= nums.Count)
                        pos -= nums.Count;

                    nums[pos] += 1;
                }

                line = JoinNumbers(nums);
                //Console.WriteLine(line);
            }

            return count.ToString();
        }

        public override string SolutionTwo()
        {
            var line = string.Copy(Input);
            //Console.WriteLine(line);

            var lines = new List<string>();
            var count = 0;

            while (!lines.Contains(line))
            {
                count++;
                lines.Add(line);
                var nums = line.Split('\t').Select(int.Parse).ToList();
                
                var maxPos = nums.IndexOf(nums.Max());
                var num = nums.Max();

                nums[maxPos] = 0;
                
                for (var i = 1; i <= num; i++)
                {
                    var pos = maxPos + i;
                    while (pos >= nums.Count)
                        pos -= nums.Count;

                    nums[pos] += 1;
                }

                line = JoinNumbers(nums);
                //Console.WriteLine(line);
            }

            return (count - lines.IndexOf(line)).ToString();
        }

        private static string JoinNumbers(List<int> numbers)
        {
            var str = "";
            str += numbers[0];
            
            for (var i = 1; i < numbers.Count; i++)
            {
                str += "\t" + numbers[i];
            }

            return str;
        }
    }
}