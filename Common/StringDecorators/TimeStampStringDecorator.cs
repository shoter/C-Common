using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StringDecorators
{
    public class TimeStampStringDecorator : IStringDecorator
    {
        public string Process(string input)
        {
            return string.Format("[{0}] - {1}", DateTime.Now.ToShortTimeString(), input);
        }
    }
}
