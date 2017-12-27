using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Temporary
{
    public class WindowsTempFile : TempFile
    {
        public WindowsTempFile() : base(System.IO.Path.GetTempFileName())
        {
        }
    }
}
