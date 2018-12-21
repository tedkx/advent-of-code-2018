using advent.lib;
using System;

namespace advent.day1
{
    public class Part1 : IPuzzle
    {
        public void Run(string input)
        {
            int seq = 0;
            Array.ForEach(input.Split('\n'), s =>
            {
                var change = int.Parse(s.Substring(1));
                seq += (s[0] == '+' ? 1 : -1) * change;
            });

            Console.WriteLine($"Resulting Sequence: {seq}");
        }
    }
}