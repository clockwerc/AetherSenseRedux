﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AetherSenseRedux
{

    internal interface IPattern
    {
        DateTime Expires { get; set; }
        double GetIntensityAtTime(DateTime currTime);

    }
}