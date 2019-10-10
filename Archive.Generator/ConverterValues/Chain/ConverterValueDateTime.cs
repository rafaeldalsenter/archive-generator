using Archive.Generator.PropertiesAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Archive.Generator.Exceptions;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueDateTime : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            if (value is null) return Next(value, attributes);

            if (!IsThisType(value)) return Next(value, attributes);

            var format = attributes?.FirstOrDefault(x => x is DateTimeFormatterAttribute) as DateTimeFormatterAttribute;

            if (format is null) throw new IncorrectAttributeException($"Propriedade do tipo Datetime sem Atributo DateTimeFormatterAttribute informado.");

            return DateTime.Parse(value.ToString()).ToString(format?.Format);
        }

        public override List<Type> GetTypes() => new List<Type>() { typeof(DateTime) };
    }
}