using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserActivity
{
    public interface ITimeProvider
    {
        DateTime GetNow();
    }

    internal class TimeProvider : ITimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
    }
}
