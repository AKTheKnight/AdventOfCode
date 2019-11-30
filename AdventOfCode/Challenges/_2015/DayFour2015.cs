namespace AdventOfCode.Challenges._2015
{
    public class DayFour2015 : Challenge
    {
        private static string Input { get; set; }
        
        public DayFour2015() : base(4)
        {
            if (Input == null)
                Input = Utils.GetInput(2015, 4)[0];
        }

        public override string SolutionOne()
        {
            var key = Input;
            var i = 0;
            do
            {
                i++;
            } while (!Utils.CreateMD5(key + i).StartsWith("00000"));

            return i.ToString();
        }

        public override string SolutionTwo()
        {
            var key = Input;
            var i = 0;
            do
            {
                i++;
            } while (!Utils.CreateMD5(key + i).StartsWith("000000"));

            return i.ToString();
        }
    }
}