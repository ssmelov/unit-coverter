using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitMapper : IUnitMapper
    {
        private readonly Dictionary<string, Dictionary<string, double>> mappings = new Dictionary<string, Dictionary<string, double>>();

        public void RegisterMapping(string source_unit_name, string target_unit_name, double factor)
        {
            addMapping(source_unit_name, target_unit_name, factor);
            addMapping(target_unit_name, source_unit_name, 1.0 / factor);
        }

        public Dictionary<string, double> GetMappings(string source_unit_name)
        {
            if (mappings.ContainsKey(source_unit_name))
                return mappings[source_unit_name];

            return null;
        }

        private void addMapping(string source_unit_name, string target_unit_name, double factor)
        {
            Dictionary<string, double> map;

            if (!mappings.ContainsKey(source_unit_name))
            {
                map = new Dictionary<string, double>();
                mappings.Add(source_unit_name, map);
            }
            else
            {
                map = mappings[source_unit_name];
            }

            map.Add(target_unit_name, factor);
        }
    }
}
