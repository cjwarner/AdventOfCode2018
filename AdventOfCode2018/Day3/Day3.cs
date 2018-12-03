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
        public void Part1_Answer()
        {
            List<Day3Logic.Claim> claims = new Day3Logic().ReadFile(@"Day3\Day3.txt");


        }
    }
}
