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
        public class SummaryGuardSleep
        {
            public int Id { get; set; }
            public int[] TotalActivity { get; set; }

            public SummaryGuardSleep()
            {
                TotalActivity = new int[60] {
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                };
            }
        }

        public class GuardSleep
        {
            public const char SLEEP = '#';
            public const char AWAKE = '.';

            public int Id { get; set; }
            public char[] Activity { get; set; }

            public GuardSleep()
            {
                Activity = new char[60] {
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                    AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE, AWAKE,
                };
            }
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

        public DateTime ParseDate(string text)
        {
            return DateTime.ParseExact(text, "yyyy-MM-dd", null);
        }

        public int ParseMinutes(string text)
        {
            return DateTime.ParseExact(text, "HH:mm", null).Minute;
        }

        public Tuple<Dictionary<DateTime, GuardSleep>, List<SummaryGuardSleep>> ReadFile(string filename)
        {
            /*
             * [1518-11-01 
             * 00:00] 
             * Guard 
             * #10 
             * begins 
             * shift
             * 
             * 
            [1518-11-01 00:00] Guard #10 begins shift
            [1518-11-01 00:30] falls asleep
            [1518-11-01 00:55] wakes up
            [1518-11-01 23:58] Guard #99 begins shift
            [1518-11-02 00:40] falls asleep
            [1518-11-02 00:50] wakes up
            [1518-11-01 00:05] falls asleep
            [1518-11-01 00:25] wakes up 
            */

            Dictionary<DateTime, GuardSleep> GS = new Dictionary<DateTime, GuardSleep>();
            List<SummaryGuardSleep> TS = new List<SummaryGuardSleep>();

            int guardId = 0;
            DateTime dateTime;
            int time = 0;
            int asleep = 0;

            var lines = System.IO.File.ReadAllLines(filename).ToList();
            lines.Sort();

            foreach (var line in lines)
            {
                var bits = line.Split(new char[] { ' ' });
                dateTime = ParseDate(bits[0].Trim(new char[] { '[', ']' }));
                time = ParseMinutes(bits[1].Trim(new char[] { ']' }));

                if (line.Contains("begins shift"))
                    guardId = System.Convert.ToInt32(bits[3].Trim('#'));
                else if (line.Contains("falls asleep"))
                {
                    asleep = time;
                }
                else if (line.Contains("wakes up"))
                {
                    if (GS.ContainsKey(dateTime))
                    {
                        for (int i = asleep; i < time; i++)
                        {
                            GS[dateTime].Activity[i] = GuardSleep.SLEEP;

                            var found = TS.FirstOrDefault(x => x.Id == GS[dateTime].Id);
                            found.TotalActivity[i]++;
                        }
                    }
                    else
                    {
                        var found = TS.FirstOrDefault(x => x.Id == guardId);
                        if (found == null)
                        {
                            found = new SummaryGuardSleep() { Id = guardId };
                            TS.Add(found);
                        }

                        var gs = new GuardSleep();
                        gs.Id = guardId;
                        for (int i = asleep; i < time; i++)
                        {
                            gs.Activity[i] = GuardSleep.SLEEP;
                            found.TotalActivity[i]++;
                        }

                        GS.Add(dateTime, gs);
                    }
                }
            }

            var longest = 0;
            var longestId = 0;

            foreach (var item in TS)
            {
                if (item.TotalActivity.Sum() > longest)
                {
                    longest = item.TotalActivity.Sum();
                    longestId = item.Id;
                }

            }

            var largest = 0;
            var largestPos = 0;

            var guard = TS.FirstOrDefault(x => x.Id == longestId);

            for (int i = 0; i < guard.TotalActivity.Count(); i++)
            {
                if (guard.TotalActivity[i] > largest)
                {
                    largest = guard.TotalActivity[i];
                    largestPos = i;
                }
            }

            var answer = longestId * largestPos;

            var largest1 = 0;
            var largestPos1 = 0;
            var largestGuardId = 0;
            for (int i = 0; i < TS.Count(); i++)
            {
                for (int j = 1; j < TS.Count(); j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        if (TS[i].TotalActivity[k] > largest1)
                        {
                            largest1 = TS[i].TotalActivity[k];
                            largestPos1 = k;
                            largestGuardId = TS[i].Id;
                        }
                        if (TS[j].TotalActivity[k] > largest1)
                        {
                            largest1 = TS[j].TotalActivity[k];
                            largestPos1 = k;
                            largestGuardId = TS[j].Id;
                        }
                    }
                }
            }

            var answer2 = largestPos1 * largestGuardId;

            return new Tuple<Dictionary<DateTime, GuardSleep>, List<SummaryGuardSleep>>(GS, TS);
        }
    }
}
