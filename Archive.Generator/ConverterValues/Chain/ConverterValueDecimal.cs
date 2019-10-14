using System;
using System.Collections.Generic;
using System.Linq;
using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueDecimal : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            if (value is null) return Next(value, attributes);

            if (!IsThisType(value)) return Next(value, attributes);

            var decimalAttribute = attributes.FirstOrDefault(x => x is DecimalAttribute) as DecimalAttribute;

            var size = attributes.FirstOrDefault(x => x is SizeAttribute) as SizeAttribute;

            if (size is null) throw new IncorrectAttributeException($"Propriedade do tipo Decimal sem Atributo SizeAttribute informado.");

            if (decimalAttribute is null) throw new IncorrectAttributeException($"Propriedade do tipo Decimal sem Atributo DecimalAttribute informado.");

            var valueToString = Convert.ToDecimal(value).ToString($"F{decimalAttribute.Places}");

            valueToString = valueToString.Replace(".", "").Replace(",", "");

            if (decimalAttribute.AlignToLeft)
                valueToString = valueToString.PadRight(size.Size, decimalAttribute.EmptySpaces);
            else
                valueToString = valueToString.PadLeft(size.Size, decimalAttribute.EmptySpaces);

            return valueToString;
        }

        public override List<Type> GetTypes() => new List<Type>() { typeof(decimal), typeof(double) };
    }
}