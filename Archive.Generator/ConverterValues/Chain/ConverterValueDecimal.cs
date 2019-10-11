using System;
using System.Collections.Generic;
using System.Linq;
using Archive.Generator.PropertiesAttributes;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueDecimal : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            if (value is null) return Next(value, attributes);

            if (!IsThisType(value)) return Next(value, attributes);

            var decimalAttributes = attributes.FirstOrDefault(x => x is DecimalAttribute) as DecimalAttribute;

            var size = attributes.FirstOrDefault(x => x is SizeAttribute) as SizeAttribute;

            return "";
        }

        public override List<Type> GetTypes() => new List<Type>() { typeof(decimal), typeof(double) };
    }
}