using System.Linq;

namespace AdventOfCode.Challenges._2015
{
    public class DayOne2015 : Challenge
    {

        private static string Input { get; set; }

        public DayOne2015() : base(1)
        {
            if (Input == null)
                Input = Utils.GetInput(2015, 1)[0];
        }

        public override string SolutionOne()
        {
            //What floor does santa end on
            var up = Input.Count(c => c == '(');
            var down = Input.Length - up;

            var floor = up - down;

            return floor.ToString();
        }

        public override string SolutionTwo()
        {
            //What character does he go to the basement
            var floor = 0;
            var position = 0;

            foreach (var t in Input)
            {
                position++;
                //Up
                if (t == '(')
                    floor++;
                //Down
                else
                    floor--;

                //Basement?
                if (floor < 0)
                {
                    return position.ToString();
                }
            }

            return "Not completed";
        }
    }
}