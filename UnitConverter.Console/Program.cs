using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var converter = new UnitConverter(new UnitMapper(), new UnitParser(new MetricPrefixParser()));

                string result = converter.Convert("3 kiloinches", "meters");

                System.Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message); 
            }
        }
    }
}
