using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SequenceAttribute : Attribute
    {
        public int Sequence { get; private set; }

        public SequenceAttribute(int sequence) => Sequence = sequence;
    }
}