using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Processses
{
    public static class ProcessExtensions
    {
        public static DisposableProcess MakeDisposable(this Process process)
        {
            return new DisposableProcess(process);
        }

        public static DisposableProcess MakeDisposable(this Process process, Action onDisposeAction)
        {
            return new DisposableProcess(process, onDisposeAction);
        }
    }
}
