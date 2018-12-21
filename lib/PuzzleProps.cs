using System;
using System.IO;
using System.Text;

namespace advent.lib
{
    public class PuzzleProps
    {
        public int Day { get; set; } = 1;
        public string FullName { get; set; } = string.Empty;
        public string Input { get; set; } = null;
        public int Part { get; set; } = 1;
        public PuzzleProps(string[] args)
        {
            int buff;
            string inputModifier = string.Empty;
            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--day":
                    case "-d":
                        if (int.TryParse(args[i + 1], out buff))
                            Day = buff;
                        i++;
                        break;
                    case "--part":
                    case "-p":
                        if (int.TryParse(args[i + 1], out buff))
                            Part = buff;
                        i++;
                        break;
                    case "--test":
                    case "-t":
                        inputModifier = "test";
                        break;
                    default:
                        break;
                }
            }

            FullName = $"advent.day{Day}.Part{Part}";

            var resourceName = $"advent.day{Day}.{inputModifier}input.txt";

            try
            {
                using (var stream = typeof(PuzzleProps).Assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    Input = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting input from {resourceName}: {ex.Message}");
            }
        }

        public override string ToString()
        {
            return $"Day {Day}, Part {Part}";
        }
    }
}