using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day4
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var shift = Day4Logic.ShiftInfo.Parse("[1518-11-01 00:00] Guard #10 begins shift");
        }

        [TestMethod]
        public void Part1_Test1a()
        {
            var day4 = new Day4Logic();

            var shifts = day4.ReadFile(@"Day4\Day4a.txt");

            var guardInfo = day4.DetermineGuardInfo(shifts);
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
