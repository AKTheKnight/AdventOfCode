using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace uk.co.aktheknight.AdventOfCode
{
    public static class Utils
    {
        public static List<String> GetInput(int year, int day)
        {
            try
            {
                String[] lines = File.ReadAllLines("../../inputs/_" + year + "/Day" + day + ".txt");
                return lines.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Unable to read input for year {0} and day {1}", day, year);
                return null;
            }
        }

        public struct CoOrd
        {

            public CoOrd(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            
            public int x;
            public int y;
        }
        
        //https://stackoverflow.com/a/24031467/5411549
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static int NumberOfUniqueVowels(string line)
        {
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

            return vowels.Count(line.Contains);
        }
    }
}