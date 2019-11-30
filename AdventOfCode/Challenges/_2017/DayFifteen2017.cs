using System;
using System.Collections.Generic;
using System.Numerics;
using AdventOfCode.Extensions;

namespace AdventOfCode.Challenges._2017
{
    public class DayFifteen2017 : Challenge
    {
        private static List<string> Input { get; set; }
        
        private static int GenAInitial { get; set; }
        private static int GenBInitial { get; set; }
        
        public DayFifteen2017() : base(15)
        {
            if (Input == null)
            {
                Input = Utils.GetInput(2017, 15);
                GenAInitial = Convert.ToInt32(Input[0]);
                GenBInitial = Convert.ToInt32(Input[1]);
            }
        }

        private static int GenAFactor { get; } = 16807;
        private static int GenBFactor { get; } = 48271;
        private static int Divisor { get; } = 2147483647;

        public override string SolutionOne()
        {
            var count = 0;
            
            BigInteger GenAVal = GenAInitial;
            BigInteger GenBVal = GenBInitial;
            for (int i = 0; i < 40 * 1000 *1000; i++)
            {
                GenAVal = (GenAVal * GenAFactor) % Divisor;
                GenBVal = (GenBVal * GenBFactor) % Divisor;
                
                var GenAString = GenAVal.ToBinaryString();
                GenAString = GenAString.Substring(Math.Max(0, GenAString.Length - 16)).PadLeft(16, '0');;
                
                var GenBString = GenBVal.ToBinaryString();
                GenBString = GenBString.Substring(Math.Max(0, GenBString.Length - 16)).PadLeft(16, '0');

                if (GenAString == GenBString)
                    count++;
            }

            return count.ToString();
        }
        
        public override string SolutionTwo()
        {
            var count = 0;

            List<string> GenAVals = new List<string>();
            List<string> GenBVals = new List<string>();            
            
            BigInteger GenAVal = GenAInitial;
            BigInteger GenBVal = GenBInitial;
            while (GenAVals.Count < 5*1000*1000
                   || GenBVals.Count < 5*1000*1000)
            {
                GenAVal = (GenAVal * GenAFactor) % Divisor;
                GenBVal = (GenBVal * GenBFactor) % Divisor;

                if (GenAVal % 4 == 0)
                {
                    var GenAString = GenAVal.ToBinaryString();
                    GenAVals.Add(GenAString.Substring(Math.Max(0, GenAString.Length - 16)).PadLeft(16, '0'));
                }

                if (GenBVal % 8 == 0)
                {
                    var GenBString = GenBVal.ToBinaryString();
                    GenBVals.Add(GenBString.Substring(Math.Max(0, GenBString.Length - 16)).PadLeft(16, '0'));
                }
            }
            
            for (int i = 0; i < 5*1000*1000; i++)
            {
                if (GenAVals[i] == GenBVals[i])
                    count++;
            }

            return count.ToString();
        }
    }
}