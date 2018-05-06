using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class Unit
    {
        public MetricPrefix MetricPrefix { get; }

        public string Name { get; }

        public Unit(MetricPrefix prefix, string name)
        {
            MetricPrefix = prefix;
            Name = name;
        }
    }
}
