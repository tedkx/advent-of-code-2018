using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using advent.lib;

namespace advent.day5
{
    public class Part2 : IPuzzle
    {
        public void Run(StreamReader stream)
        {
            var input = stream.ReadToEnd();
            var polymers = new Dictionary<char, Polymer>();
            var fullPolymer = new Polymer();

            for (var i = 0; i < input.Length; i++)
            {
                char key = input[i].ToString().ToLowerInvariant()[0];
                if (!polymers.ContainsKey(key))
                    polymers[key] = new Polymer(fullPolymer);

                foreach (var pair in polymers)
                    if (pair.Key != key)
                        pair.Value.Add(input[i]);

                fullPolymer.Add(input[i]);
            }

            var optimalPolymer = polymers.Keys
                .OrderBy(key => polymers[key].Length)
                .First();
            Console.WriteLine($"Optimal polymer length: {polymers[optimalPolymer].Length}");
        }
    }
}