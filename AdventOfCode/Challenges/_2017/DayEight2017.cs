using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2017
{
    public class DayEight2017 : Challenge
    {
        private static List<string> Input { get; set; }

        public DayEight2017() : base(8)
        {
            if (Input == null)
                Input = Utils.GetInput(2017, 8);
        }

        public override string SolutionOne()
        {
            var dict = new Dictionary<string, int>();
            
            foreach (var line in Input)
            {
                var args = line.Split(' ');

                var register = args[0];
                var change = args[1];
                var value = args[2];
                
                if (!dict.ContainsKey(register))
                    dict.Add(register, 0);

                var conditionRegister = args[4];
                var condition = args[5];
                var conditionValue = args[6];
                
                if (!dict.ContainsKey(conditionRegister))
                    dict.Add(conditionRegister, 0);

                var shouldProcess = false;

                switch (condition)
                {
                    case ">":
                        if (dict[conditionRegister] > int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case ">=":
                        if (dict[conditionRegister] >= int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "<":
                        if (dict[conditionRegister] < int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "<=":
                        if (dict[conditionRegister] <= int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "==":
                        if (dict[conditionRegister] == int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "!=":
                        if (dict[conditionRegister] != int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                }
                
                if (!shouldProcess)
                    continue;

                switch (change)
                {
                    case "inc":
                        dict[register] += int.Parse(value);
                        break;
                    case "dec":
                        dict[register] -= int.Parse(value);
                        break;
                }
            }
            
            var max = dict.Values.Max();
            
            return max.ToString();
            
            
            throw new System.NotImplementedException();
        }

        public override string SolutionTwo()
        {
            var dict = new Dictionary<string, int>();
            var max = 0;
            
            foreach (var line in Input)
            {
                var args = line.Split(' ');

                var register = args[0];
                var change = args[1];
                var value = args[2];
                
                if (!dict.ContainsKey(register))
                    dict.Add(register, 0);

                var conditionRegister = args[4];
                var condition = args[5];
                var conditionValue = args[6];
                
                if (!dict.ContainsKey(conditionRegister))
                    dict.Add(conditionRegister, 0);

                var shouldProcess = false;

                switch (condition)
                {
                    case ">":
                        if (dict[conditionRegister] > int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case ">=":
                        if (dict[conditionRegister] >= int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "<":
                        if (dict[conditionRegister] < int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "<=":
                        if (dict[conditionRegister] <= int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "==":
                        if (dict[conditionRegister] == int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                    case "!=":
                        if (dict[conditionRegister] != int.Parse(conditionValue))
                            shouldProcess = true;
                        break;
                }
                
                if (!shouldProcess)
                    continue;

                switch (change)
                {
                    case "inc":
                        dict[register] += int.Parse(value);
                        break;
                    case "dec":
                        dict[register] -= int.Parse(value);
                        break;
                }

                if (dict.Values.Max() > max)
                    max = dict.Values.Max();
            }
            
            
            return max.ToString();
        }
    }
}