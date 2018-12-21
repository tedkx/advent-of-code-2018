using advent.lib;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace advent
{
    class Program
    {
        static int Main(string[] args)
        {
            var interfaceType = typeof(advent.lib.IPuzzle);

            var puzzleProps = new PuzzleProps(args);
            if (puzzleProps.InputResourceName == null)
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
            try
            {
                using (var stream = typeof(PuzzleProps).Assembly.GetManifestResourceStream(puzzleProps.InputResourceName))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    puzzle.Run(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Puzzle error: {ex.Message}");
            }

            return 0;
        }
    }
}
