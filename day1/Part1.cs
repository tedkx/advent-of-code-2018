using advent.lib;
using System;
using System.IO;

namespace advent.day1
{
    public class Part1 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            int seq = 0;
            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                var change = int.Parse(line.Substring(1));
                seq += (line[0] == '+' ? 1 : -1) * change;
            }

            Console.WriteLine($"Resulting Sequence: {seq}");
        }
    }
}