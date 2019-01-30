using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Time
{
    public class FixedTimeProvider : ITimeProvider
    {
        private readonly DateTime time;

        public DateTime Now => time;

        public DateTime UtcNow => time.ToUniversalTime();

        public FixedTimeProvider(DateTime time)
        {
            this.time = time;
        }
    }
}
