using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalPlacesAttribute : Attribute
    {
        public int Value { get; private set; }

        public DecimalPlacesAttribute(int value) => Value = value;
    }
}