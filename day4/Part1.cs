using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent.day4
{
    public class Part1 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            var instructions = InstructionsParser.Parse(input);
            var sleepPatterns = new Dictionary<int, SleepPattern>();

            int currentGuardId = 0;
            DateTime shiftStart = default(DateTime);
            foreach (var i in instructions)
            {
                if (i.Action == InstructionAction.FallAsleep)
                {
                    shiftStart = i.Timestamp;
                }
                else if (i.Action == InstructionAction.WakeUp)
                {
                    if (!sleepPatterns.ContainsKey(currentGuardId))
                        sleepPatterns[currentGuardId] = new SleepPattern();
                    sleepPatterns[currentGuardId].Register(shiftStart, i.Timestamp);
                }
                else
                {
                    currentGuardId = i.GuardID;
                }
            }

            var mostSleepyGuardId = sleepPatterns.Keys
                .OrderByDescending(key => sleepPatterns[key].TotalMinutes)
                .First();
            var pattern = sleepPatterns[mostSleepyGuardId];

            Console.WriteLine($"Most sleep guard is #{mostSleepyGuardId} slept for {pattern.TotalMinutes}, most slept minute is {pattern.MostSleptMinute}");
            Console.WriteLine($"Puzzle answer is {mostSleepyGuardId * pattern.MostSleptMinute}");

        }
    }
}