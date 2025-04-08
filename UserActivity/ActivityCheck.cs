using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserActivity
{
    internal class ActivityCheck
    {
        private readonly int _inactiveSeconds;
        private readonly ITimeProvider _timeProvider;
        private DateTime _lastActivity;

        public ActivityCheck(int inactiveSeconds, ITimeProvider timeProvider)
        {
            _inactiveSeconds = inactiveSeconds;
            _timeProvider = timeProvider;
            _lastActivity = _timeProvider.GetNow();
        }

        public bool IsInactive()
        {
            if (_lastActivity.AddSeconds(_inactiveSeconds) < _timeProvider.GetNow())
                return true;

            return false;
        }

        public void ActivityHappened()
        {
            _lastActivity = _timeProvider.GetNow();
        }
    }
}
