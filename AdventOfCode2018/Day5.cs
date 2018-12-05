using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        public void Part1_Test1()
        {
            string text = "aA";

            var result = Function(text);

            Assert.AreEqual(result, "");
        }

        private string Function(string text)
        {
            
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
