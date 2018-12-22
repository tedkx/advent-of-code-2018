using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace advent.day2
{
    public class Part1 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            Dictionary<char, int> dic = null;
            int twos = 0,
                threes = 0;

            while (!input.EndOfStream)
            {
                dic = new Dictionary<char, int>();
                var line = input.ReadLine();
                foreach (char c in line)
                {
                    if (dic.ContainsKey(c))
                        dic[c]++;
                    else
                        dic[c] = 1;
                }

                bool two = false,
                    three = false;
                foreach (var v in dic.Values)
                {
                    if (v == 2)
                        two = true;
                    if (v == 3)
                        three = true;
                    if (two && three)
                        break;
                }

                twos += two ? 1 : 0;
                threes += three ? 1 : 0;
            }

            var checksum = twos * threes;
            Console.WriteLine($"Checksum: {checksum}");
        }
    }
}