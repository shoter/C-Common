using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    /// <summary>
    /// Exception of this type should be displayed to the user. It does not contain any vulnerable information.
    /// </summary>
    public class UserReadableException : Exception
    {
        public UserReadableException(string message) : base(message)
        {
        }

        public UserReadableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
