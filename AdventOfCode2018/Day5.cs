using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day5
    {
        [TestMethod]
        public void Part1_Tests()
        {
            var result1 = CreatePolymer("aA");
            Assert.AreEqual(result1, "");

            var result2 = CreatePolymer("abBA");
            Assert.AreEqual(result2, "");

            var result3 = CreatePolymer("abAB");
            Assert.AreEqual(result3, "abAB");

            var result4 = CreatePolymer("aabAAB");
            Assert.AreEqual(result4, "aabAAB");

            var result5 = CreatePolymer("dabAcCaCBAcCcaDA");
            Assert.AreEqual(result5, "dabCBAcaDA");
        }

        [TestMethod]
        public void Part1_Answer()
        {
            var result = CreatePolymer(System.IO.File.ReadAllText(@"Day5.txt"));
            Assert.AreEqual(10762, result.Length);
        }

        [TestMethod]
        public void Part2_Answer()
        {
            var shortest = 9999999;
            var originalText = CreatePolymer(System.IO.File.ReadAllText(@"Day5.txt"));
            //var originalText = "dabAcCaCBAcCcaDA";

            var alphabet = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            for (int i = 0; i < alphabet.Length; i++)
            {
                var text = originalText;
                var letter = alphabet[i];

                if (text.Contains(letter.ToString())
                    || text.Contains(Char.ToUpper(letter).ToString()))
                {
                    text = text.Replace(letter.ToString(), "");
                    text = text.Replace(Char.ToUpper(letter).ToString(), "");

                    var result = CreatePolymer(text);
                    if (result.Length < shortest)
                        shortest = result.Length;
                }
            }

            //Assert.AreEqual(4, shortest);
            Assert.AreEqual(6946, shortest);
        }

        private string CreatePolymer(string text)
        {
            bool complete = false;

            while (!complete)
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if (((text[i] == Char.ToLower(text[i + 1])
                        || Char.ToLower(text[i]) == text[i + 1]))
                        && text[i] != text[i + 1])
                    {
                        text = text.Remove(i, 2);
                        break;
                    }

                    if ((i == text.Length - 2) || (text.Length == 0))
                        complete = true;
                }

                if ((text.Length == 0))
                    complete = true;
            }

            return text;
        }
    }
}
