using System;
using System.Text.RegularExpressions;

namespace advent.day4
{
    public class Instruction : IComparable
    {
        public static readonly Regex TimestampPattern = new Regex(@"\[(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2})\] (.+)");
        public static readonly Regex GuardRegex = new Regex(@"Guard #(\d+) begins shift");
        public const string FallAsleep = "falls asleep";
        public const string WakeUp = "wakes up";

        private string _guardArg;
        public DateTime Timestamp { get; private set; }
        public int GuardID { get; private set; }
        public InstructionAction Action { get; private set; }


        public Instruction(string input)
        {
            var match = TimestampPattern.Match(input);
            if (match.Success)
            {
                string year = match.Groups[1].Value,
                    month = match.Groups[2].Value,
                    day = match.Groups[3].Value,
                    hour = match.Groups[4].Value,
                    minute = match.Groups[5].Value;
                _guardArg = match.Groups[6].Value;

                Timestamp = DateTime.Parse($"{year}-{month}-{day} {hour}:{minute}:00");
                Action = _guardArg == FallAsleep ? InstructionAction.FallAsleep
                    : _guardArg == WakeUp ? InstructionAction.WakeUp
                    : InstructionAction.ShiftStart;

                GuardID = Action == InstructionAction.ShiftStart
                    ? int.Parse(GuardRegex.Match(_guardArg).Groups[1].Value)
                    : 0;
            }
        }

        public int CompareTo(object obj)
        {
            var other = (Instruction)obj;
            return Timestamp < other.Timestamp ? -1
                : Timestamp > other.Timestamp ? 1
                : 0;
        }
    }
}