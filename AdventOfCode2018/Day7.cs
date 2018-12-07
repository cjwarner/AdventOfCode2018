using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using System.Drawing;

namespace AdventOfCode2018
{
    [TestClass]
    public class Day7
    {
        [TestMethod]
        public void Part1_Tests()
        {
            var steps = new Dictionary<string, List<string>>();
            var lines = System.IO.File.ReadAllLines(@"Day7a.txt");
            List<string> availableSteps = new List<string>();

            foreach (var line in lines)
            {
                var bits = line.Split(new[] { ' ' });
                var step = bits[1];
                var dependantStep = bits[7];

                if (!availableSteps.Contains(step))
                {
                    availableSteps.Add(step);
                }
                if (!availableSteps.Contains(dependantStep))
                {
                    availableSteps.Add(dependantStep);
                }

                if (!steps.ContainsKey(dependantStep))
                {
                    steps.Add(dependantStep, new List<string>() { step });
                }
                else
                {
                    steps[dependantStep].Add(step);
                }
            }

            var root = availableSteps.Except(steps.Keys).First();
            var node = root;

            foreach (var step in steps)
            {
                
            }

        }
    }
}
