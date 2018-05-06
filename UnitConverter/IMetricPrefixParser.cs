using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IMetricPrefixParser
    {
        MetricPrefix Parse(string prefix_name);
    }
}
