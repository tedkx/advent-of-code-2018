namespace advent.lib
{
    public class CmdParams
    {
        public int Day { get; set; } = 1;
        public int Part { get; set; } = 1;
        public string FullName { get; set; } = string.Empty;
        public CmdParams(string[] args)
        {
            int buff;
            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--day":
                    case "-d":
                        if (int.TryParse(args[i + 1], out buff))
                            Day = buff;
                        break;
                    case "--part":
                    case "-p":
                        if (int.TryParse(args[i + 1], out buff))
                            Part = buff;
                        break;
                    default:
                        break;
                }
            }

            FullName = $"advent.day{Day}.Part{Part}";
        }

        public override string ToString()
        {
            return $"Day {Day}, Part {Part}";
        }
    }
}