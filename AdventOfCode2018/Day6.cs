using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day6
    {
        public class Coodinates
        {
            public char Letter { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

        [TestMethod]
        public void Part1_Tests()
        {
            var list = new List<Coodinates>();
            var lines = System.IO.File.ReadAllLines(@"Day6a.txt");
            var letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int count = 0;

            foreach (var line in lines)
            {
                var splitline = line.Split(new char[] { ',' });
                var coords = new Coodinates()
                {
                    Letter = letters[count],
                    X = System.Convert.ToInt32(splitline[0]),
                    Y = System.Convert.ToInt32(splitline[1])
                };
                count++;

                list.Add(coords);
            }

            string output = "";
            for (int y = 0; y < list.Max(a => a.Y) + 1; y++)
            {
                for (int x = 0; x < list.Max(a => a.X) + 2; x++)
                {
                    var find = list.FirstOrDefault(a => a.X == x && a.Y == y);
                    if (find != null)
                        output += find.Letter;
                    else
                        output += ".";
                }
                Debug.WriteLine(output);
                output = "";
            }
        }

        [TestMethod]
        public void Part1_Answer()
        {
        }

        [TestMethod]
        public void Part2_Answer()
        {
        }
    }
}
