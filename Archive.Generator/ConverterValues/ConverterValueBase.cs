using System;
using System.Collections.Generic;
using System.Linq;

namespace Archive.Generator.ConverterValues
{
    internal abstract class ConverterValueBase : IConverterValue
    {
        private ConverterValueBase _next;

        public abstract string GetString(object value, object[] attributes);

        public void SetNext(ConverterValueBase converterType) => _next = converterType;

        public string Next(object value, object[] attributes) => _next.GetString(value, attributes);

        public abstract List<Type> GetTypes();

        public bool IsThisType(object value) => GetTypes().Any(x => x == value.GetType());
    }
}