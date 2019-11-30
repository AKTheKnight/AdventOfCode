namespace AdventOfCode.Challenges
{
    public abstract class Challenge
    {

        public int Day { get; }

        public Challenge(int day)
        {
            this.Day = day;
        }

        public abstract string SolutionOne();
        public abstract string SolutionTwo();

    }
}