using System;
using System.Text;

namespace advent.day5
{
    public class Polymer
    {
        const char Empty = '\0';
        private char _lastAdded;
        private StringBuilder _sb;
        public int Length
        {
            get { return _sb.Length; }
        }

        public Polymer()
        {
            _sb = new StringBuilder();
            _lastAdded = Empty;
        }

        public Polymer(Polymer fromPolymer)
        {
            _sb = new StringBuilder(fromPolymer.ToString());
            _lastAdded = _sb.Length == 0
                ? Empty
                : _sb[_sb.Length - 1];
        }

        public void Add(char c)
        {
            if (_lastAdded == Empty || !IsOpposite(c))
            {
                _lastAdded = c;
                _sb.Append(_lastAdded);
            }
            else
            {
                _sb.Length--;
                _lastAdded = _sb.Length == 0
                    ? Empty
                    : _sb[_sb.Length - 1];
            }
        }

        bool IsOpposite(char c)
        {
            return Math.Abs((int)c - (int)_lastAdded) == 32;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}