using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2015
{
    public class DayThree2015 : Challenge
    {
        private static string Input { get; set; }
        
        public DayThree2015() : base(3)
        {
            if (Input == null)
                Input = Utils.GetInput(2015, 3)[0];
        }

        public override string SolutionOne()
        {
            var houses = new Dictionary<Utils.CoOrd, int> {{new Utils.CoOrd(0, 0), 1}};
            
            var x = 0;
            var y = 0;
            
            foreach (var direction in Input)
            {
                MoveCoOrd(ref x, ref y, direction);

                var visits = 1;

                if (houses.ContainsKey(new Utils.CoOrd(x, y)))
                    visits = houses[new Utils.CoOrd(x, y)] + 1;

                houses[new Utils.CoOrd(x, y)] = visits;
            }

            var count = houses.Count(house => house.Value > 0);

            return count.ToString();
        }

        public override string SolutionTwo()
        {
            var houses = new Dictionary<Utils.CoOrd, int> {{new Utils.CoOrd(0, 0), 1}};

            var xSanta = 0;
            var ySanta = 0;

            var xRobo = 0;
            var yRobo = 0;
            
            var x = 0;
            var y = 0;

            var robo = false;
            
            foreach (var direction in Input)
            {
                var visits = 0;
                
                if (robo)
                {
                    MoveCoOrd(ref xRobo, ref yRobo, direction);
                    
                    visits = 1;

                    if (houses.ContainsKey(new Utils.CoOrd(xRobo, yRobo)))
                        visits = houses[new Utils.CoOrd(xRobo, yRobo)] + 1;

                    houses[new Utils.CoOrd(xRobo, yRobo)] = visits;
                    
                    robo = false;
                }
                else
                {
                    MoveCoOrd(ref xSanta, ref ySanta, direction);
                    
                    visits = 1;

                    if (houses.ContainsKey(new Utils.CoOrd(xSanta, ySanta)))
                        visits = houses[new Utils.CoOrd(xSanta, ySanta)] + 1;

                    houses[new Utils.CoOrd(xSanta, ySanta)] = visits;
                    
                    robo = true;
                }
            }

            var count = houses.Count(house => house.Value > 0);

            return count.ToString();
        }

        private static void MoveCoOrd(ref int x, ref int y, char direction)
        {
            switch (direction)
            {
                //Up, down, left, right
                case '^':
                    y += 1;
                    break;
                case 'v':
                    y -= 1;
                    break;
                case '<':
                    x -= 1;
                    break;
                default:
                    x += 1;
                    break;
            }
        }
    }
}