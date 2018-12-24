using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent.day4
{
    public class Part2 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            var instructions = InstructionsParser.Parse(input);
            var minutesData = new Dictionary<int, MinuteData>();
            for (var i = 0; i < 60; i++)
                minutesData.Add(i, new MinuteData());

            int currentGuardId = 0;
            DateTime shiftStart = default(DateTime);
            foreach (var ins in instructions)
            {
                if (ins.Action == InstructionAction.FallAsleep)
                {
                    shiftStart = ins.Timestamp;
                }
                else if (ins.Action == InstructionAction.WakeUp)
                {
                    var mins = (int)(ins.Timestamp - shiftStart).TotalMinutes;
                    for (var i = 0; i < mins; i++)
                    {
                        var current = shiftStart.AddMinutes(i);
                        if (current.Hour != 0)
                            continue;
                        minutesData[current.Minute].Register(currentGuardId);
                    }
                }
                else
                {
                    currentGuardId = ins.GuardID;
                }
            }

            var mostFrequentMinute = minutesData.Keys
                .OrderByDescending(key => minutesData[key].MostTimesSlept)
                .First();
            var minuteData = minutesData[mostFrequentMinute];

            Console.WriteLine($"Most frequent minute is {mostFrequentMinute}, with guard #{minuteData.GuardMostSlept} sleeping for {minuteData.MostTimesSlept} times");
            Console.WriteLine($"Puzzle answer: {mostFrequentMinute * minuteData.GuardMostSlept}");
        }
    }
}