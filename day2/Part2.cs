using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace advent.day2
{
    public class Part2 : IPuzzle
    {
        public void Run(StreamReader input)
        {
            var lines = input.ReadToEnd().Split('\n');
            string refLine = null, compareLine = null;
            int diffIdx = -1;

            for (var li = 0; li < lines.Length; li++)
            {
                refLine = lines[li];
                for (var lj = 0; lj < lines.Length; lj++)
                {
                    compareLine = lines[lj];
                    diffIdx = -1;
                    for (var ci = 0; ci < compareLine.Length; ci++)
                    {
                        if (refLine[ci] != compareLine[ci])
                        {
                            if (diffIdx == -1)
                            {
                                diffIdx = ci;
                            }
                            else
                            {
                                diffIdx = -1;
                                break;
                            }
                        }
                    }

                    if (diffIdx >= 0)
                        break;
                }

                if (diffIdx >= 0)
                    break;
            }

            string letters = diffIdx == 0
                ? refLine.Substring(1)
                : diffIdx == (refLine.Length - 1)
                ? refLine.Substring(0, refLine.Length - 1)
                : refLine.Substring(0, diffIdx) + refLine.Substring(diffIdx + 1);
            Console.WriteLine($"Common letters: {letters}");
        }
    }
}