using advent.lib;
using System;
using System.Collections.Generic;

namespace advent.day1
{
    public class Part2 : IPuzzle
    {
        public void Run(string input)
        {
            int seq = 0;
            int idx = 0;
            var all = new HashSet<int>();
            var inputs = input.Split('\n');
            bool unique = true;
            while (unique)
            {
                string s = inputs[idx];
                int change = int.Parse(s.Substring(1));
                seq += (s[0] == '+' ? 1 : -1) * change;
                unique = all.Add(seq);
                idx++;
                if (idx >= inputs.Length)
                    idx = 0;
            }
            Console.WriteLine($"Duplicate Sequence: {seq}");
        }
    }
}