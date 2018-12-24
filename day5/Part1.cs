
using System;
using System.IO;
using advent.lib;

namespace advent.day5
{
    public class Part1 : IPuzzle
    {
        const char Empty = '\0';

        public void Run(StreamReader stream)
        {
            var input = stream.ReadToEnd();
            var polymer = new Polymer();

            for (var i = 0; i < input.Length; i++)
                polymer.Add(input[i]);

            Console.WriteLine($"Polymer contains: {polymer.Length} units");
        }

    }
}
