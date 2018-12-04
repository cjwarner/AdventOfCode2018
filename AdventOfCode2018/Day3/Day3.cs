using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day3
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var claim = Day3Logic.Claim.Parse("#123 @ 3,2: 5x4");

            new Day3Logic().DrawClaims(new List<Day3Logic.Claim> { claim });

            Assert.AreEqual(123, claim.Number);
            Assert.AreEqual(3, claim.Left);
            Assert.AreEqual(2, claim.Top);
            Assert.AreEqual(5, claim.Width);
            Assert.AreEqual(4, claim.Height);
        }

        [TestMethod]
        public void Part1_Test2()
        {
            var day3 = new Day3Logic();

            var claims = day3.ReadFile(@"Day3\Day3a.txt");

            var canvas = day3.DrawClaims(claims, 8, 8);

            Assert.AreEqual(4, day3.CountOverlaps(canvas));
        }

        [TestMethod]
        public void Part1_Answer()
        {
            var day3 = new Day3Logic();

            List<Day3Logic.Claim> claims = day3.ReadFile(@"Day3\Day3.txt");

            var canvas = day3.DrawClaims(claims);

            Assert.AreEqual(97218, day3.CountOverlaps(canvas));
        }

        [TestMethod]
        public void Part2_Answer()
        {
            var day3 = new Day3Logic();

            List<Day3Logic.Claim> claims = day3.ReadFile(@"Day3\Day3.txt");

            var canvas = day3.DrawClaims(claims);

            Assert.AreEqual(717, day3.FindClaimWithoutOverlaps(claims, canvas));
        }
    }
}
