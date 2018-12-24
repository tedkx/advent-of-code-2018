using System.Collections.Generic;

namespace advent.day4
{
    public class MinuteData
    {
        private Dictionary<int, int> _guardMinutes = new Dictionary<int, int>();
        public int MostTimesSlept { get; private set; } = 0;
        public int GuardMostSlept { get; private set; } = 0;

        public void Register(int guardId)
        {
            int value = 0;
            if (!_guardMinutes.ContainsKey(guardId))
                value = 1;
            else
                value = _guardMinutes[guardId] + 1;
            _guardMinutes[guardId] = value;

            if (value > MostTimesSlept)
            {
                MostTimesSlept = value;
                GuardMostSlept = guardId;
            }
        }
    }
}