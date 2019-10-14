using System;

namespace Archive.Generator.PropertiesAttributes
{
    public class IntAttribute : Attribute
    {
        public bool AlignToLeft { get; private set; }

        public char EmptySpaces { get; private set; }

        public IntAttribute(char emptySpaces, bool alignToLeft = false)
        {
            AlignToLeft = alignToLeft;
            EmptySpaces = emptySpaces;
        }
    }
}