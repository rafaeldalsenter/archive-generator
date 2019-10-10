using System;
using System.Collections.Generic;

namespace Archive.Generator.ConverterValues.Chain
{
    internal class ConverterValueString : ConverterValueBase
    {
        public override string GetString(object value, object[] attributes)
        {
            return "";
        }

        public override List<Type> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}