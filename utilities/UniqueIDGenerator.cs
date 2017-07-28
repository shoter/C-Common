using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utilities
{
    public class UniqueIDGenerator
    {
        private int _uniqueID = 0;
        
        public int UniqueID { get { return _uniqueID++; } }

        public static implicit operator int(UniqueIDGenerator generator)
        {
            return generator.UniqueID;
        }
    }
}
