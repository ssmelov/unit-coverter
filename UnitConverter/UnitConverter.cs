﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public class UnitConverter
    {
        private readonly IUnitParser unit_parser;

        private readonly IUnitMapper unit_mapper;

        public UnitConverter(IUnitMapper unit_mapper, IUnitParser unit_parser)
        {
            if (unit_mapper == null)
                throw new ArgumentNullException(nameof(unit_mapper));

            if (unit_parser == null)
                throw new ArgumentNullException(nameof(unit_parser));

            this.unit_mapper = unit_mapper;
            this.unit_parser = unit_parser;

            unit_mapper.RegisterMapping(Units.Inches, Units.Meters, 0.0254);
            unit_mapper.RegisterMapping(Units.Feet, Units.Inches, 12);
            unit_mapper.RegisterMapping(Units.Bytes, Units.Bits, 8);
        }

        public string Convert(string value_with_source_units, string str_target_units)
        {
            Tuple<double, Unit> parsed_source = unit_parser.ParseValueWithUnit(value_with_source_units);
            double value = parsed_source.Item1;
            Unit source_units = parsed_source.Item2;

            Unit target_units = unit_parser.ParseUnit(str_target_units);

            double result = convert(source_units, target_units, value);

            return $"{result.ToString("0.00")} {str_target_units}";
        }

        private double convert(Unit source_units, Unit target_units, double value)
        {
            var queue = new Queue<ConversionStep>();
            queue.Enqueue(new ConversionStep { UnitName = source_units.Name, Value = value * source_units.MetricPrefix.Factor });

            while (queue.Count() > 0)
            {
                var conversion_step = queue.Dequeue();

                if (conversion_step.UnitName == target_units.Name)
                    return conversion_step.Value * (1.0 / target_units.MetricPrefix.Factor);

                var map = unit_mapper.GetMappings(conversion_step.UnitName);
                if (map != null)
                {
                    foreach (var item in map)
                    {
                        queue.Enqueue(new ConversionStep { UnitName = item.Key, Value = conversion_step.Value * item.Value });
                    }
                }
            }

            throw new ArgumentException("Cannot not convert from " + source_units.Name + " to " + target_units.Name);
        }
    }
}
