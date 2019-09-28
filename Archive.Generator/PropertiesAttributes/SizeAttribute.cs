using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SizeAttribute : Attribute
    {
        public int Size { get; private set; }

        public SizeAttribute(int size) => Size = size;
    }
}