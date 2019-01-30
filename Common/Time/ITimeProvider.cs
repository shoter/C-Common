﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Time
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
