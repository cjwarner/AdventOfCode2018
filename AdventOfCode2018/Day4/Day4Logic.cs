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
        public class SleepInfo
        {
            public const char SLEEP = '#';
            public const char AWAKE = '.';

            public int Id { get; set; }
            public char[] Activity { get; set; }

            public SleepInfo()
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

        public List<Day4Logic.ShiftInfo> ReadFile(string filename)
        {
            var shiftInfo = new List<ShiftInfo>();

            foreach (var line in System.IO.File.ReadAllLines(filename))
            {
                shiftInfo.Add(ShiftInfo.Parse(line));
            }

            shiftInfo = shiftInfo.OrderBy(x => x.Time).ToList();

            return shiftInfo;
        }

        public void Display(List<ShiftInfo> shifts)
        {
            foreach (var line in shifts)
            {
            }
        }

        /*
        Date   ID   Minute
                    000000000011111111112222222222333333333344444444445555555555
                    012345678901234567890123456789012345678901234567890123456789
        11-01  #10  .....####################.....#########################.....
        11-02  #99  ........................................##########..........
        11-03  #10  ........................#####...............................
        11-04  #99  ....................................##########..............
        11-05  #99  .............................................##########.....
        */

        public Dictionary<DateTime, SleepInfo> DetermineGuardInfo(List<Day4Logic.ShiftInfo> shiftInfo)
        {
            var sleepInfos = new Dictionary<DateTime, SleepInfo>();

            //var sleepInfo = new SleepInfo();
            var guardId = 0;
            int startSleep = 0;
            int endSleep = 0;

            foreach (var shift in shiftInfo)
            {
                if (shift.Info.Contains("begins shift"))
                {
                    guardId = System.Convert.ToInt32(shift.Info.Substring(7, shift.Info.IndexOf('b') - 7 - 1));
                }

                if (shift.Info.Contains("falls asleep"))
                {
                    if (!sleepInfos.ContainsKey(shift.Time.Date))
                        sleepInfos.Add(shift.Time.Date, new SleepInfo() { Id = guardId });

                    startSleep = shift.Time.Minute;
                }

                if (shift.Info.Contains("wakes up"))
                {
                    endSleep = shift.Time.Minute;
                    FillActivity(sleepInfo, startSleep, endSleep);
                }
            }

            return sleepInfos;
        }

        public void FillActivity(SleepInfo info, int startSleep, int endSleep)
        {
            for (int i = startSleep - 1; i < endSleep; i++)
            {
                info.Activity[i] = SleepInfo.SLEEP;
            }
        }

        //public List<, SleepInfo> DetermineGuardInfo(List<Day4Logic.ShiftInfo> shiftInfo)
        //{
        //    var guardInfo = new Dictionary<int, int>();
        //    var guardId = 0;
        //    DateTime startSleep = new DateTime();
        //    DateTime endSleep = new DateTime();
        //    int sleepTime = 0;


        //    foreach (var shift in shiftInfo)
        //    {
        //        if (shift.Info.Contains("begins shift"))
        //        {
        //            if (guardId != 0)
        //            {
        //                if (guardInfo.ContainsKey(guardId))
        //                    guardInfo[guardId] += sleepTime;
        //                else
        //                    guardInfo.Add(guardId, sleepTime);

        //                sleepTime = 0;
        //            }

        //            guardId = System.Convert.ToInt32(shift.Info.Substring(7, shift.Info.IndexOf('b') - 7 - 1));
        //        }

        //        if (shift.Info.Contains("falls asleep"))
        //        {
        //            startSleep = shift.Time;
        //        }

        //        if (shift.Info.Contains("wakes up"))
        //        {
        //            endSleep = shift.Time;
        //            sleepTime += (endSleep - startSleep).Minutes;
        //        }

        //    }

        //    return guardInfo;
        //}

    }
}
