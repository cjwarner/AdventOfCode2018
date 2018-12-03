using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day1
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var list = new List<int>() { 1, 1, 1 };

            Assert.AreEqual(3, new Day1Logic().Part1_Logic(list));
        }

        [TestMethod]
        public void Part1_Test2()
        {
            var list = new List<int>() { 1, 1, -2 };

            Assert.AreEqual(0, new Day1Logic().Part1_Logic(list));
        }

        [TestMethod]
        public void Part1_Test3()
        {
            var list = new List<int>() { -1, -2, -3 };

            Assert.AreEqual(-6, new Day1Logic().Part1_Logic(list));
        }

        [TestMethod]
        public void Part1_Answer()
        {
            var list = new Day1Logic().ReadFile(@"Day1\Day1.txt");

            Assert.AreEqual(592, new Day1Logic().Part1_Logic(list));
        }

        [TestMethod]
        public void Part2_Test1()
        {
            var list = new List<int>() { 1, -1 };

            Assert.AreEqual(0, new Day1Logic().Part2_Logic(list));
        }

        [TestMethod]
        public void Part2_Test2()
        {
            var list = new List<int>() { 3, 3, 4, -2, -4 };

            Assert.AreEqual(10, new Day1Logic().Part2_Logic(list));
        }

        [TestMethod]
        public void Part2_Test3()
        {
            var list = new List<int>() { -6, 3, 8, 5, -6 };

            Assert.AreEqual(5, new Day1Logic().Part2_Logic(list));
        }

        [TestMethod]
        public void Part2_Test4()
        {
            var list = new List<int>() { 7, 7, -2, -7, -4 };

            Assert.AreEqual(14, new Day1Logic().Part2_Logic(list));
        }

        [TestMethod]
        public void Part2_Answer()
        {
            var list = new Day1Logic().ReadFile(@"Day1\Day1.txt");

            Assert.AreEqual(241, new Day1Logic().Part2_Logic(list));
        }
    }
}
