using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Operations
{
    public class MethodResultError : MethodResult
    {
        public MethodResultError(string message)
        {
            AddError(message);
        }

        public static explicit operator MethodResultError(string msg)
        {
            return new MethodResultError(msg);
        }
    }
}
