using System.Collections.Generic;
using System.IO;

namespace advent.day4
{
    public static class InstructionsParser
    {
        public static List<Instruction> Parse(StreamReader input)
        {
            var instructions = new List<Instruction>();

            while (!input.EndOfStream)
                instructions.Add(new Instruction(input.ReadLine()));

            instructions.Sort();
            return instructions;
        }
    }
}