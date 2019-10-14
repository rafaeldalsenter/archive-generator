using System;
using Archive.Generator.ConverterValues;
using System.Linq;
using System.Reflection;
using Archive.Generator.PropertiesAttributes;

namespace Archive.Generator
{
    public abstract class BaseArchiveGenerator : IBaseArchiveGenerator
    {
        public string GenerateString() =>
            String.Concat(GetType()
                .GetProperties()
                .OrderBy(x => ((OrderAttribute)x.GetCustomAttribute(typeof(OrderAttribute))).Order)
                .Select(x => new ConverterValueChain().Get(x.GetValue(this, null), x.GetCustomAttributes(false)))
                .ToList());
    }
}