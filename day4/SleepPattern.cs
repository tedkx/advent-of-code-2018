using System;
using System.Collections.Generic;
using System.Linq;

namespace advent.day4
{
    public class SleepPattern
    {
        public int TotalMinutes { get; private set; } = 0;
        public int MostSleptMinute
        {
            get
            {
                if (_mostSleptMinute == -1)
                    _mostSleptMinute = _sleepPerMinute.Keys
                        .OrderByDescending(key => _sleepPerMinute[key])
                        .First();
                return _mostSleptMinute;
            }
        }

        private Dictionary<int, int> _sleepPerMinute = new Dictionary<int, int>();
        private int _mostSleptMinute = -1;

        public void Register(DateTime start, DateTime end)
        {
            _mostSleptMinute = -1;
            var mins = (int)(end - start).TotalMinutes;
            TotalMinutes += mins;

            for (var i = 0; i < mins; i++)
            {
                var currentDate = start.AddMinutes(i);
                if (currentDate.Hour != 0)
                    continue;
                if (!_sleepPerMinute.ContainsKey(currentDate.Minute))
                    _sleepPerMinute[currentDate.Minute] = 1;
                else
                    _sleepPerMinute[currentDate.Minute]++;
            }
        }
    }
}