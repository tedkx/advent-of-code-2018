using System.Text.RegularExpressions;

namespace advent.day3
{
    public class Rectangle
    {
        static Regex Pattern = new Regex(@"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)");
        public int Height { get; private set; }
        public string ID { get; private set; }
        public int Width { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Horizontal { get; private set; }
        public int Vertical { get; private set; }

        public Rectangle(string input)
        {
            var match = Pattern.Match(input);
            if (match.Success)
            {
                ID = match.Groups[1].Value;
                X = int.Parse(match.Groups[2].Value);
                Y = int.Parse(match.Groups[3].Value);
                Width = int.Parse(match.Groups[4].Value);
                Height = int.Parse(match.Groups[5].Value);

                Horizontal = X + Width;
                Vertical = Y + Height;
            }
        }

        public override string ToString()
        {
            return $"#{ID} @ {X},{Y}: {Width}x{Height} ({Horizontal} x {Vertical})";
        }
    }
}