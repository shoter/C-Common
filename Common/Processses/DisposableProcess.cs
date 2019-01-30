using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Processses
{
    public class DisposableProcess : IDisposable
    {
        public Process Process { get; private set; }
        private Action onDisposeAction;

        public DisposableProcess(Process process)
        {
            Process = process;
        }

        ~DisposableProcess()
        {
            Dispose(false);
        }


        public DisposableProcess(Process process, Action onDisposeAction) : this(process)
        {
            this.onDisposeAction = onDisposeAction;
        }

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {

                if (disposing)
                {
                    onDisposeAction?.Invoke();
                }
                Process.Kill();
                Process.WaitForExit();

            }
            disposed = true;
        }

    }
}
