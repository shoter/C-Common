using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Operations
{
    public class MethodResult
    {
        public static MethodResult Success => new MethodResult() { Status = MethodResultType.Success }; 
        public static MethodResult Failure => new MethodResult() { Status = MethodResultType.Error }; 

        public MethodResultType Status { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public MethodResult() { Status = MethodResultType.Success; }
        public MethodResult(string error)
        {
            AddError(error);
        }
        public MethodResult(object error)
        {
            Type type = error.GetType();

            var attribute = type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            AddError(attribute?.ToString());
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
            return result.isSuccess;
        }

        public override string ToString()
        {
            return ToString(Environment.NewLine);
        }

        public string ToString(string separator)
        {
            return string.Join(separator, Errors);
        }

        public void ThrowUserReadableExceptionIfError(string separator = ",")
        {
            if (IsError)
                throw new UserReadableException(ToString(separator));
        }

    }
}
