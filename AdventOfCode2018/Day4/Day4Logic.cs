using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day4Logic
    {
        public class GuardInfo
        {
            public int Id { get; set; }
            public int MinutesAsleep { get; set; }
        }

        public class ShiftInfo
        {
            public DateTime Time { get; set; }
            public string Info { get; set; }

            public static ShiftInfo Parse(string text)
            {
                //[1518-11-01 00:00] Guard #10 begins shift
                var time = DateTime.ParseExact(text.Substring(1, text.IndexOf(']') - 1), "yyyy-MM-dd HH:mm", null);
                var info = text.Split(new[] { ']' })[1].Trim();

                return new ShiftInfo()
                {
                    Time = time,
                    Info = info
                };
            }
        }

        public List<Day4Logic.ShiftInfo> ReadFile(string filename)
        {
            var shiftInfo = new List<ShiftInfo>();

            foreach (var line in System.IO.File.ReadAllLines(filename))
            {
                shiftInfo.Add(ShiftInfo.Parse(line));
            }

            return shiftInfo;
        }


        //012345678901234567890
        //Guard #10 begins shift

        //[1518-11-01 00:00] Guard #10 begins shift
        //[1518-11-01 00:05] falls asleep
        //[1518-11-01 00:25] wakes up
        //[1518-11-01 00:30] falls asleep
        //[1518-11-01 00:55] wakes up

        public Dictionary<int, int> DetermineGuardInfo(List<Day4Logic.ShiftInfo> shiftInfo)
        {
            var guardInfo = new Dictionary<int, int>();
            var guardId = 0;
            DateTime startSleep = new DateTime();
            DateTime endSleep = new DateTime();
            int sleepTime = 0;


            foreach (var shift in shiftInfo)
            {
                if (shift.Info.Contains("begins shift"))
                {
                    if (guardId != 0)
                    {
                        if (guardInfo.ContainsKey(guardId))
                            guardInfo[guardId] += sleepTime;
                        else
                            guardInfo.Add(guardId, sleepTime);

                        sleepTime = 0;
                    }

                    guardId = System.Convert.ToInt32(shift.Info.Substring(7, shift.Info.IndexOf('b') - 7 - 1));
                }

                if (shift.Info.Contains("falls asleep"))
                {
                    startSleep = shift.Time;
                }

                if (shift.Info.Contains("wakes up"))
                {
                    endSleep = shift.Time;
                    sleepTime += (endSleep - startSleep).Minutes;
                }

            }

            return guardInfo;
        }

    }
}
