using Common.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Operations
{
    public class MethodResult<T> : MethodResult
    {
        public static new MethodResult<T> Success { get { return new MethodResult<T>(); } }
        public static new MethodResult<T> Failure { get { var result = new MethodResult<T>(); result.Status = MethodResultType.Error; return result; } }

        public T ReturnValue { get; set; }
        public MethodResult()
        {
        }

        public MethodResult(string error) : base(error)
        {
        }

        public MethodResult(T result) : this()
        {
            ReturnValue = result;
        }


        public static implicit operator T(MethodResult<T> obj)
        {
            return obj.ReturnValue;
        }

        public static implicit operator MethodResult<T>(T result)
        {
            return new MethodResult<T>(result);
        }

        public new MethodResult<T> Merge(MethodResult other)
        {
            base.Merge(other);
            return this;
        }
    }
}
