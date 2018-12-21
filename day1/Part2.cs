using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace advent.day1
{
    public class Part2 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            int seq = 0;
            int idx = -1;
            var all = new HashSet<int>();
            var lines = new List<string>();
            bool unique = true;
            while (unique)
            {
                string line = idx >= 0 ? lines[idx] : input.ReadLine();
                int change = int.Parse(line.Substring(1));
                seq += (line[0] == '+' ? 1 : -1) * change;
                unique = all.Add(seq);

                if (idx < 0)
                {
                    lines.Add(line);
                    if (input.EndOfStream)
                        idx = 0;
                }
                else
                {
                    idx++;
                    if (idx >= lines.Count)
                        idx = 0;
                }
            }
            Console.WriteLine($"Duplicate Sequence: {seq}");
        }
    }
}