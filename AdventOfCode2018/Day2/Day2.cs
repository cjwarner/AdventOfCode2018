using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day2
    {
        [TestMethod]
        public void Part1_Test1()
        {
            var letters = "abcdef";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(false, logic.TwosCount);
            Assert.AreEqual(false, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test2()
        {
            var letters = "bababc";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(true, logic.TwosCount);
            Assert.AreEqual(true, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test3()
        {
            var letters = "abbcde";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(true, logic.TwosCount);
            Assert.AreEqual(false, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test4()
        {
            var letters = "abcccd";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(false, logic.TwosCount);
            Assert.AreEqual(true, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test5()
        {
            var letters = "aabcdd";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(true, logic.TwosCount);
            Assert.AreEqual(false, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test6()
        {
            var letters = "abcdee";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(true, logic.TwosCount);
            Assert.AreEqual(false, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Test7()
        {
            var letters = "ababab";

            var logic = new Day2Logic().Part1_Logic(letters);

            Assert.AreEqual(false, logic.TwosCount);
            Assert.AreEqual(true, logic.ThreesCount);
        }

        [TestMethod]
        public void Part1_Answer()
        {
            int twos = 0;
            int threes = 0;

            var lines = new Day2Logic().ReadFile(@"Day2\Day2.txt");

            foreach (var line in lines)
            {
                var logic = new Day2Logic().Part1_Logic(line);

                if (logic.TwosCount)
                    twos++;

                if (logic.ThreesCount)
                    threes++;
            }

            Assert.AreEqual(246, twos);
            Assert.AreEqual(28, threes);
            Assert.AreEqual(6888, twos * threes);
        }

        [TestMethod]
        public void Part2_Answer()
        {
            string string1 = "";
            string string2 = "";
            bool charDiffOneFound = false;

            var day2 = new Day2Logic();

            var lines = day2.ReadFile(@"Day2\Day2.txt");

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 1; j < lines.Count; j++)
                {
                    var characterDiff = day2.CharacterDiff(lines[i], lines[j]);

                    if (characterDiff == 1)
                    {
                        string1 = lines[i];
                        string2 = lines[j];
                        charDiffOneFound = true;
                        break;
                    }
                }

                if (charDiffOneFound)
                    break;
            }

            Assert.AreEqual("icxjvbrobtunlelzpdmfkuahgs", string1);
            Assert.AreEqual("icxjvbrobtunlelzpdmfksahgs", string2);

            Assert.AreEqual("icxjvbrobtunlelzpdmfkahgs", day2.GetResultingCharaters(string1, string2));                             
        }
    }
}
