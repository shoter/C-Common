using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public abstract class BaseLogger : ILogger
    {
        public abstract ILogger Log(string message, params object[] args);
        public ILogger LogLine(string message, params object[] args)
        {
            return Log(message + "\n", args);
        }
    }
}
