using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Time
{
    public class TimeProviders
    {
        public static ITimeProvider Current = new StandardTimeProvider();
    }
}
