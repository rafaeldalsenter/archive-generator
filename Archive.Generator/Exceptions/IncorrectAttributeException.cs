using System;

namespace Archive.Generator.Exceptions
{
    public class IncorrectAttributeException : Exception
    {
        public IncorrectAttributeException(string message) : base(message)
        {
        }
    }
}