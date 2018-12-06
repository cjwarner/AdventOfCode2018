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
    public class Day6
    {
        public class Coodinates
        {
            public char Letter { get; set; }
            public Point Point { get; set; }
        }

        public double Distance(Point p1, Point p2)
        {
            return Math.Abs(p2.X - p1.X) + Math.Abs(p2.Y - p1.Y);
        }

        [TestMethod]
        public void Part1_Tests()
        {
            var list = new List<Coodinates>();
            var lines = System.IO.File.ReadAllLines(@"Day6.txt");
            var letters = new char[] {
                //'A','B','C','D','E','F'
                'A','B','C','D','E','F','G','H','I','J',
                'K','L','M','N','O','P','Q','R','S','T',
                'U','V','W','X','Y','Z','1','2','3','4',
                '5','6','7','8','9','0','!','@','#','$',
                '%','^','&','*','(',')','¡','¢','£','®'
            };

            int count = 0;

            foreach (var line in lines)
            {
                var splitline = line.Split(new char[] { ',' });
                var coords = new Coodinates()
                {
                    Letter = letters[count],
                    Point = new Point(System.Convert.ToInt32(splitline[0]), System.Convert.ToInt32(splitline[1]))
                };
                count++;

                list.Add(coords);
            }

            string output = "";
            for (int y = 0; y < list.Max(a => a.Point.Y) + 1; y++)
            {
                for (int x = 0; x < list.Max(a => a.Point.X) + 2; x++)
                {
                    var find = list.FirstOrDefault(a => a.Point.X == x && a.Point.Y == y);
                    if (find != null)
                        output += find.Letter;
                    else
                        output += ".";
                }
                Debug.WriteLine(output);
                output = "";
            }

            var map = new char[list.Max(a => a.Point.Y) + 1, list.Max(a => a.Point.X) + 2];
            for (int y = 0; y < list.Max(a => a.Point.Y) + 1; y++)
            {
                for (int x = 0; x < list.Max(a => a.Point.X) + 2; x++)
                {
                    double sum3 = 0;
                    //var lowest = Double.MaxValue;
                    foreach (var coord in list)
                    {
                        var dist = Distance(new Point(x, y), coord.Point);

                        sum3 += dist;

                        if (dist == 0)
                        {
                            //    lowest = dist;
                            map[y, x] = coord.Letter;
                        }
                        //else if (dist < lowest)
                        //{
                        //    lowest = dist;
                        //    map[y, x] = Char.ToLower(coord.Letter);
                        //}
                        //else if (dist == lowest)
                        //{
                        //    map[y, x] = '.';
                        //}
                    }

                    if (sum3 < 10000)
                        map[y, x] = '#';
                    else
                        map[y, x] = '.';
                }
            }

            var count3 = 0;
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == '#')
                        count3++;
                }
            }

            Dictionary<char, int> area = new Dictionary<char, int>();
            int sum = 0;
            foreach (var coord in list)
            {
                sum = 0;
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        if (map[y, x] == coord.Letter || map[y, x] == Char.ToLower(coord.Letter))
                        {
                            if (!(y == 0 || y == map.GetLength(0) - 1 || x == 0 || x == map.GetLength(1) - 1))
                                sum += 1;
                        }
                    }
                }
                area.Add(coord.Letter, sum);
            }

            foreach (var coord in list)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        if (map[y, x] == coord.Letter || map[y, x] == Char.ToLower(coord.Letter))
                        {
                            if ((y == 0 || y == map.GetLength(0) - 1 || x == 0 || x == map.GetLength(1) - 1))
                                area.Remove(coord.Letter);
                        }
                    }
                }
            }

            var letter = area.Max(x => x.Key);
            var area2 = area.Max(x => x.Value);
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
