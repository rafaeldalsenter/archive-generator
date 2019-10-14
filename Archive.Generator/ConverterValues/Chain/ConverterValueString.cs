using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueString : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            if (value is null) value = "";

            var stringAttribute = attributes?.FirstOrDefault(x => x is StringAttribute) as StringAttribute;

            var size = attributes?.FirstOrDefault(x => x is SizeAttribute) as SizeAttribute;

            if (size is null) throw new IncorrectAttributeException($"Propriedade do tipo String sem Atributo SizeAttribute informado.");

            var valueToString = value.ToString();

            if (valueToString.Length > size.Size)
                valueToString = valueToString.Substring(0, size.Size);

            if (stringAttribute is null || stringAttribute.AlignToLeft)
                valueToString = valueToString.PadRight(size.Size, ' ');
            else
                valueToString = valueToString.PadLeft(size.Size, ' ');

            return valueToString;
        }

        public override List<Type> GetTypes() => new List<Type> { typeof(string) };
    }
}