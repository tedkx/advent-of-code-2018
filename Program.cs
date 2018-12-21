using advent.lib;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace advent
{
    class Program
    {
        static int Main(string[] args)
        {
            var interfaceType = typeof(advent.lib.IPuzzle);

            var puzzleProps = new PuzzleProps(args);
            if (puzzleProps.Input == null)
                return 1;

            var puzzleType = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t =>
                    interfaceType.IsAssignableFrom(t) &&
                    t.FullName == puzzleProps.FullName
                );

            if (puzzleType == null)
            {
                Console.WriteLine($"Could not find puzzleType {puzzleProps.FullName}");
                return 2;
            }

            Console.WriteLine($"-- Running {puzzleProps} --");

            var puzzle = (IPuzzle)Activator.CreateInstance(puzzleType);
            puzzle.Run(puzzleProps.Input);

            Console.WriteLine("-- Press any key --");
            Console.Read();
            return 0;
        }
    }
}
