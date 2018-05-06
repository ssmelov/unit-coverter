using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class MetricPrefixParser : IMetricPrefixParser
    {
        private readonly Dictionary<string, double> metric_prefixes;

        public MetricPrefixParser()
        {
            metric_prefixes = new Dictionary<string, double>()
            {
                { "", 1.0 },
                { "yotta", 1.0e24 },
                { "zetta", 1.0e21 },
                { "exa", 1.0e18 },
                { "peta", 1.0e15 },
                { "tera", 1.0e12 },
                { "giga", 1.0e9 },
                { "mega", 1.0e6 },
                { "kilo", 1.0e3 },
                { "hecto", 1.0e2 },
                { "deka", 1.0e1 },
                { "deci", 1.0e-1 },
                { "centi", 1.0e-2 },
                { "milli", 1.0e-3 },
                { "micro", 1.0e-6 },
                { "nano", 1.0e-9 },
                { "pico", 1.0e-12 },
                { "femto", 1.0e-15 },
                { "atto", 1.0e-18 },
                { "zepto", 1.0e-21 },
                { "yocto", 1.0e-24 }
            }; 
        }

        public MetricPrefix Parse(string prefix_name)
        {
            if (metric_prefixes.ContainsKey(prefix_name))
                return new MetricPrefix(prefix_name, metric_prefixes[prefix_name]);

            throw new Exception($"Unknown metric prefix: {prefix_name}");
        }
    }
}
