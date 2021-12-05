﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AetherSenseRedux.Pattern
{
    internal class RampPattern : IPattern
    {
        public DateTime Expires { get; set; }
        private readonly double startLevel;
        private readonly double endLevel;
        private readonly long duration;


        public RampPattern(Dictionary<string, object> config)
        {
            startLevel = (double)config["start"];
            endLevel = (double)config["end"];
            this.duration = (long)config["duration"];
            Expires = DateTime.UtcNow + TimeSpan.FromMilliseconds(duration);
        }

        public double GetIntensityAtTime(DateTime time)
        {
            if (Expires < time)
            {
                throw new PatternExpiredException();
            }
            double progress = (Expires.Ticks - time.Ticks) / TimeSpan.FromMilliseconds(duration).Ticks;
            return (endLevel - startLevel) * progress + startLevel;
        }
    }
}