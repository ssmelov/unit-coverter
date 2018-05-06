using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitParser : IUnitParser
    {
        private readonly HashSet<string> units = new HashSet<string>();

        private readonly IMetricPrefixParser metric_prefix_parser;

        public UnitParser(IMetricPrefixParser metric_prefix_parser)
        {
            if (metric_prefix_parser == null)
                throw new ArgumentNullException(nameof(metric_prefix_parser));

            this.metric_prefix_parser = metric_prefix_parser;

            foreach (var field in typeof(Units).GetFields())
            {
                object field_value = field.GetValue(field.Name);

                if (field_value is string)
                    units.Add(field_value as string);
            }
        }

        public Tuple<double, Unit> ParseValueWithUnit(string value_with_unit)
        {
            string[] items = value_with_unit.Split(' ');
            double value = Double.Parse(items[0]);
            Unit unit = ParseUnit(items[1]);

            return new Tuple<double, Unit>(value, unit);
        }

        public Unit ParseUnit(string unit_with_prefix)
        {
            foreach (string unit in units)
            {
                if (unit_with_prefix.Contains(unit))
                {
                    string metric_prefix = unit_with_prefix.Replace(unit, string.Empty);
                    var prefix = metric_prefix_parser.Parse(metric_prefix);

                    return new Unit(prefix, unit); 
                }
            }

            throw new Exception($"Cannot parse {unit_with_prefix} unit");
        }
    }
}