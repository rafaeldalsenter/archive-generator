using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueInt : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            if (value is null) return Next(value, attributes);

            if (!IsThisType(value)) return Next(value, attributes);

            var intAttribute = attributes?.FirstOrDefault(x => x is IntAttribute) as IntAttribute;

            var size = attributes?.FirstOrDefault(x => x is SizeAttribute) as SizeAttribute;

            if (size is null) throw new IncorrectAttributeException($"Propriedade do tipo Int sem Atributo SizeAttribute informado.");

            if (intAttribute is null) throw new IncorrectAttributeException($"Propriedade do tipo Int sem Atributo IntAttribute informado.");

            var valueToString = Convert.ToInt64(value).ToString();

            if (intAttribute.AlignToLeft)
                valueToString = valueToString.PadRight(size.Size, intAttribute.EmptySpaces);
            else
                valueToString = valueToString.PadLeft(size.Size, intAttribute.EmptySpaces);

            return valueToString;
        }

        public override List<Type> GetTypes() => new List<Type>() { typeof(short), typeof(int), typeof(long) };
    }
}