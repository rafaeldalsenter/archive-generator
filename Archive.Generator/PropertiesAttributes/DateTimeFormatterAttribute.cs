using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateTimeFormatterAttribute : Attribute
    {
        public string Format { get; private set; }

        public DateTimeFormatterAttribute(string format) => Format = format;
    }
}