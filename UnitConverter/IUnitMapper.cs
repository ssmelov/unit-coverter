using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IUnitMapper
    {
        void RegisterMapping(string source_unit_name, string target_unit_name, double factor);

        Dictionary<string, double> GetMappings(string source_unit_name);
    }
}
