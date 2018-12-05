using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2016
{
    public class DayTwo2016 : Challenge
    {
        
        private static List<string> Input { get; set; }
        
        public DayTwo2016() : base(2)
        {
            if (Input == null)
                Input = Utils.GetInput(2016, 2);
        }

        public override string SolutionOne()
        {
            var keypad = new int[3,3] 
            {{1,2,3},
             {4,5,6},
             {7,8,9}};
            
            var coOrd = new Utils.CoOrd(1, 1);

            var code = "";
            foreach (var line in Input)
            {
                foreach (var instruction in line)
                {
                    switch (instruction)
                    {
                        //Up, Down, Left, Right
                        case 'U':
                            if (coOrd.y > 0)
                                coOrd.y--;
                            break;
                        case 'D':
                            if (coOrd.y < 2)
                                coOrd.y++;
                            break;
                        case 'L':
                            if (coOrd.x > 0)
                                coOrd.x--;
                            break;
                        default:
                            if (coOrd.x < 2)
                                coOrd.x++;
                            break;
                    }

                }
                
                code += keypad[coOrd.y, coOrd.x];
                
            }


            return code;
        }

        public override string SolutionTwo()
        {
            var keypad = new char[5, 5]
            {
                {'-', '-', '1', '-', '-'},
                {'-', '2', '3', '4', '-'},
                {'5', '6', '7', '8', '9'},
                {'-', 'A', 'B', 'B', '-'},
                {'-', '-', 'D', '-', '-'}
            };
            
            var coOrd = new Utils.CoOrd(0,2);
            var code = "";
            
            foreach (var line in Input)
            {
                foreach (var instruction in line)
                {
                    switch (instruction)
                    {
                        //Up, Down, Left, Right
                        case 'U':
                            if (coOrd.y > 0)
                                if (keypad[coOrd.y - 1, coOrd.x] != '-')
                                    coOrd.y--;
                            break;
                        case 'D':
                            if (coOrd.y < 4)
                                if (keypad[coOrd.y + 1, coOrd.x] != '-')
                                    coOrd.y++;
                            break;
                        case 'L':
                            if (coOrd.x > 0)
                                if (keypad[coOrd.y, coOrd.x - 1] != '-')
                                    coOrd.x--;
                            break;
                        default:
                            if (coOrd.x < 4)
                                if (keypad[coOrd.y, coOrd.x + 1] != '-')
                                    coOrd.x++;
                            break;
                    }

                }
                
                code += keypad[coOrd.y, coOrd.x];
                
            }

            return code;
          
            
            throw new NotImplementedException();
        }
        
    }
}