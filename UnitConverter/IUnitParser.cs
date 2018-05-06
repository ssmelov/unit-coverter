using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IUnitParser
    {
        Tuple<double, Unit> ParseValueWithUnit(string value_with_units);

        Unit ParseUnit(string unit);
    }
}
