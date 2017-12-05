using System.Collections.Generic;

namespace uk.co.aktheknight.AdventOfCode.Challenges._2017
{
    public class DayFour2017 : Challenge
    {
        
        private static List<string> Input { get; set; }

        public DayFour2017() : base(4)
        {
            if (Input == null)
                Input = Utils.getInput(2017, 4);
        }

        public override string SolutionOne()
        {
            var num = 0;
            
            foreach (var line in Input)
            {

                var valid = true;
                
                var words = line.Split(' ');

                for (var i = 0; i < words.Length; i++)
                {
                    for (var j = 0; j < words.Length; j++)
                    {
                        if (i == j)
                            continue;

                        if (words[i] == words[j])
                            valid = false;
                    }
                }

                if (valid)
                    num++;
            }

            return num.ToString();
            
            throw new System.NotImplementedException();
        }

        public override string SolutionTwo()
        {
            var num = 0;
            
            foreach (var line in Input)
            {

                var valid = true;
                
                var words = line.Split(' ');

                for (var i = 0; i < words.Length; i++)
                {
                    for (var j = 0; j < words.Length; j++)
                    {
                        if (i == j)
                            continue;

                        if (IsAnagram(words[i], words[j]))
                            valid = false;
                    }
                }

                if (valid)
                    num++;
            }

            return num.ToString();
        }
        
        //https://stackoverflow.com/a/16141922/5411549
        private static bool IsAnagram(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s1.Length != s2.Length)
                return false;

            foreach (char c in s2)
            {
                int ix = s1.IndexOf(c);
                if (ix >= 0)
                    s1 = s1.Remove(ix, 1);
                else
                    return false;
            }

            return string.IsNullOrEmpty(s1);
        }
    }
}