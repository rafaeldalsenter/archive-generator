using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalAttribute : Attribute
    {
        public int Places { get; private set; }

        public bool AlignToLeft { get; private set; }

        public string EmptySpaces { get; private set; }

        public DecimalAttribute(int places, string emptySpaces, bool alignToLeft = false)
        {
            Places = places;
            AlignToLeft = alignToLeft;
            EmptySpaces = emptySpaces;
        }
    }
}