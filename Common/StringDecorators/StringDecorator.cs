using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StringDecorators
{
    public class StringDecorators
    {
        public static IStringDecorator TimeStamp { get { return new TimeStampStringDecorator(); } }
    }
}
