using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent.day3
{
    public class Part1 : IPuzzle
    {

        public void Run(StreamReader input)
        {
            int intersections = 0;
            var grid = new Dictionary<int, List<string>>();
            while (!input.EndOfStream)
            {
                var rect = new Rectangle(input.ReadLine());
                for (var y = rect.Y; y < rect.Vertical; y++)
                {
                    var lst = grid.ContainsKey(y)
                        ? grid[y]
                        : new List<string>();
                    for (var i = 0; i < rect.Horizontal; i++)
                    {
                        bool inFabric = i >= rect.X;
                        if (lst.Count <= i)
                            lst.Add(inFabric ? rect.ID : ".");
                        else if (inFabric && lst[i] == ".")
                            lst[i] = rect.ID;
                        else if (inFabric && lst[i] != "X")
                        {
                            intersections++;
                            lst[i] = "X";
                        }
                    }

                    grid[y] = lst;
                }
            }

            // PrintGrid(grid);

            Console.WriteLine("Common square inches: {0}", intersections);
        }

        void PrintGrid(Dictionary<int, List<string>> grid)
        {
            var maxWidth = grid.Values.Max(l => l.Count);
            for (int i = 0; i <= grid.Keys.Max(); i++)
            {
                if (grid.ContainsKey(i))
                    Console.WriteLine(String.Join(' ', grid[i]));
                else
                    Console.WriteLine(String.Join(' ', Enumerable.Range(0, maxWidth).Select(x => ".")));
            }
        }
    }
}