using System;

namespace Archive.Generator.PropertiesAttributes
{
    public class StringAttribute : Attribute
    {
        public bool AlignToLeft { get; private set; }

        public StringAttribute(bool alignToLeft = false)
        {
            AlignToLeft = alignToLeft;
        }
    }
}