using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day3Logic
    {
        public void DrawClaims(List<Claim> claims)
        {
            var canvas = new int[1000, 1000];
            for (int x = 0; x < canvas.GetLength(0); x += 1)
            {
                for (int y = 0; y < canvas.GetLength(1); y += 1)
                    canvas[x, y] = '.';
            }

            //foreach (var claim in claims)
            //{
            //    for (int i = 0; i < claim; i++)
            //    {
            //        canvas[claim.Left - 1, claim.Top - 1] = 'X';
            //    }
            //}
        }

        public class Claim
        {
            public int Number { get; set; }
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public static Claim Parse(string text)
            {
                var claimNo = Convert.ToInt32(text.Split(new[] { '@' })[0].TrimStart(new[] { '#' }).Trim());

                var dimensions = text.Split(new[] { '@' })[1];
                var position = dimensions.Split(new[] { ':' })[0];
                var posLeft = Convert.ToInt32(position.Split(new[] { ',' })[0].Trim());
                var posTop = Convert.ToInt32(position.Split(new[] { ',' })[1].Trim());

                var area = dimensions.Split(new[] { ':' })[1];
                var areaWidth = Convert.ToInt32(area.Split(new[] { 'x', 'X' })[0].Trim());
                var areaHeight = Convert.ToInt32(area.Split(new[] { 'x', 'X' })[1].Trim());

                return new Claim()
                {
                    Number = claimNo,
                    Left = posLeft,
                    Top = posTop,
                    Width = areaWidth,
                    Height = areaHeight
                };
            }
        }

        public List<Day3Logic.Claim> ReadFile(string filename)
        {
            var claims = new List<Claim>();

            foreach (var line in System.IO.File.ReadAllLines(filename))
            {
                claims.Add(Claim.Parse(line));
            }

            return claims;
        }
    }
}
