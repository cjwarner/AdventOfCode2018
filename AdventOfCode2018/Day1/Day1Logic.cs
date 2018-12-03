using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day1Logic
    {
        public int Part1_Logic(List<int> list)
        {
            return list.Sum();
        }

        public int Part2_Logic(List<int> list)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            bool duplicateFound = false;
            int frequency = 0;

            AddOrUpdateDictionary(dict, frequency);

            while (!duplicateFound)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    frequency = frequency + list[i];
                    AddOrUpdateDictionary(dict, frequency);

                    if (dict[frequency] == 2)
                    {
                        duplicateFound = true;
                        break;
                    }
                }
            }

            return frequency;
        }

        private static void AddOrUpdateDictionary(Dictionary<int, int> dict, int frequency)
        {
            if (dict.ContainsKey(frequency))
                dict[frequency]++;
            else
                dict.Add(frequency, 1);
        }

        public List<int> ReadFile(string filename)
        {
            return System.IO.File.ReadAllLines(filename).Select(Int32.Parse).ToList();
        }
    }
}
