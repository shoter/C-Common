using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logging
{
    public interface ILogger
    {
        ILogger Log(string message, params object[] args);
        ILogger LogLine(string message, params object[] args);
    }
}
