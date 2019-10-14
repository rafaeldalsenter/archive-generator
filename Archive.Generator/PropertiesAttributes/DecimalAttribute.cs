using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DecimalAttribute : Attribute
    {
        public int Places { get; private set; }

        public bool AlignToLeft { get; private set; }

        public char EmptySpaces { get; private set; }

        public DecimalAttribute(int places, char emptySpaces, bool alignToLeft = false)
        {
            Places = places;
            AlignToLeft = alignToLeft;
            EmptySpaces = emptySpaces;
        }
    }
}