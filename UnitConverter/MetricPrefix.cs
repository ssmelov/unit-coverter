using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class MetricPrefix
    {
        public string Prefix { get; }

        public double Factor { get; }

        public MetricPrefix(string prefix, double factor)
        {
            this.Prefix = prefix;
            this.Factor = factor;   
        }
    }
}
