using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day2Logic
    {
        public class TwosAndThrees
        {
            public bool TwosCount { get; set; }
            public bool ThreesCount { get; set; }
        }

        public TwosAndThrees Part1_Logic(string letters)
        {
            var result = letters.GroupBy(c => c)
                .Select(c => new { Char = c.Key, Count = c.Count() });

            var twosCount = result.FirstOrDefault(x => x.Count == 2) != null;
            var threesCount = result.FirstOrDefault(x => x.Count == 3) != null;

            return new TwosAndThrees()
            {
                TwosCount = twosCount,
                ThreesCount = threesCount
            };
        }

        private static void AddOrUpdateDictionary(Dictionary<char, int> dict, char letter)
        {
            if (dict.ContainsKey(letter))
                dict[letter]++;
            else
                dict.Add(letter, 1);
        }

        public List<string> ReadFile(string filename)
        {
            return System.IO.File.ReadAllLines(filename).ToList();
        }

        public int CharacterDiff(string string1, string string2)
        {
            int charDiff = 0;
            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i] != string2[i])
                    charDiff++;
            }

            return charDiff;
        }

        public string GetResultingCharaters(string string1, string string2)
        {
            string newChars = "";
            for (int i = 0; i < string1.Length; i++)
            {
                if (string1[i] == string2[i])
                    newChars = newChars + string1[i];
            }

            return newChars;
        }
    }
}
