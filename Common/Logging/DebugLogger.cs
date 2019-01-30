using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public class DebugLogger : BaseLogger
    {
        public override ILogger Log(string message, params object[] args)
        {
            message = string.Format(message, args);
            Debug.Write(message);
            return this;
        }
    }
}
