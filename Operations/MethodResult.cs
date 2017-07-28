using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Operations
{
    public class MethodResult
    {
        public static MethodResult Success { get { return new MethodResult() { Status = MethodResultType.Success }; } }
        public static MethodResult Failure { get { return new MethodResult() { Status = MethodResultType.Error }; } }

        public MethodResultType Status { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public MethodResult() { }
        public MethodResult(string error)
        {
            AddError(error);
        }

        public bool IsError { get { return Status == MethodResultType.Error; } }
        public bool isSuccess { get { return Status == MethodResultType.Success; } }

        public void AddError(string error)
        {
            Errors.Add(error);
            Status = MethodResultType.Error;
        }

        public void AddError(string error, params object[] args)
        {
            AddError(string.Format(error, args));
        }

        public MethodResult Merge(MethodResult other)
        {
            if (other.Status == MethodResultType.Error)
                Status = MethodResultType.Error;

            Errors.AddRange(other.Errors);

            return this;
        }

        public static explicit operator bool(MethodResult result)
        {
            return result.IsError == false;
        }
    }
}
