using advent.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent.day3
{
    public class Part2 : IPuzzle
    {

        public void Run(StreamReader input)
        {
            var intact = new HashSet<string>();
            var grid = new Dictionary<int, List<List<string>>>();
            while (!input.EndOfStream)
            {
                var rect = new Rectangle(input.ReadLine());
                intact.Add(rect.ID);
                for (var y = rect.Y; y < rect.Vertical; y++)
                {
                    var lst = grid.ContainsKey(y)
                        ? grid[y]
                        : new List<List<string>>();
                    for (var i = 0; i < rect.Horizontal; i++)
                    {
                        bool inFabric = i >= rect.X;
                        if (lst.Count <= i)
                        {
                            lst.Add(inFabric
                                ? new List<string> { rect.ID }
                                : new List<string>()
                            );
                        }
                        else if (inFabric)
                        {
                            lst[i].Add(rect.ID);
                            if (lst[i].Count > 1)
                            {
                                foreach (string id in lst[i])
                                    intact.Remove(id);

                            }

                        }
                    }

                    grid[y] = lst;
                }
            }

            //PrintGrid(grid);

            Console.WriteLine("Intact rectangle: {0}", intact.First());
        }

        void PrintGrid(Dictionary<int, List<List<string>>> grid)
        {
            var maxWidth = grid.Values.Max(l => l.Count);
            for (int i = 0; i <= grid.Keys.Max(); i++)
            {
                if (grid.ContainsKey(i))
                    Console.WriteLine(String.Join(' ', grid[i].Select(l => l.Count == 0 ? "." : l.Count == 1 ? l[0] : "X")));
                else
                    Console.WriteLine(String.Join(' ', Enumerable.Range(0, maxWidth).Select(x => ".")));
            }
        }
    }
}