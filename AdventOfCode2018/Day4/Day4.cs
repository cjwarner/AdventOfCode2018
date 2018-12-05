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

        private int CountSleepingMinutes(char[] array)
        {
            int minutesSleeping = 0;
            foreach (var item in array)
            {
                if (item == Day4Logic.GuardSleep.SLEEP)
                    minutesSleeping++;
            }

            return minutesSleeping;
        }

        [TestMethod]
        public void Part1_Test1a()
        {
            var day4 = new Day4Logic();

            var tuple = day4.ReadFile(@"Day4\Day4.txt");
        }

        [TestMethod]
        public void Part1_Answer()
        {
            var day4 = new Day4Logic();

            day4.ReadFile(@"Day4\Day4.txt");
        }

        [TestMethod]
        public void Part2_Answer()
        {
        }
    }
}
