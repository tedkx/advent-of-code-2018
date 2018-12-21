using System.IO;

namespace advent.lib
{
    public interface IPuzzle
    {
        void Run(StreamReader input);
    }
}