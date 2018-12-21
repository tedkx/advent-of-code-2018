using advent.lib;
using System;
using System.Linq;
using System.Reflection;

namespace advent
{
    class Program
    {
        static int Main(string[] args)
        {
            var interfaceType = typeof(advent.lib.IPuzzle);

            var cmdParams = new CmdParams(args);

            var puzzleType = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t =>
                    interfaceType.IsAssignableFrom(t) &&
                    t.FullName == cmdParams.FullName
                );

            if (puzzleType == null)
            {
                Console.WriteLine($"Could not find puzzleType {cmdParams.FullName}");
                return 1;
            }

            Console.WriteLine($"-- Running {cmdParams} --");

            var puzzle = (IPuzzle)Activator.CreateInstance(puzzleType);
            puzzle.Run();

            Console.Read();
            return 0;
        }
    }
}
