using System;
using System.Collections.Generic;
using System.Text;

namespace Archive.Generator.Exceptions
{
    public class IncorrectAttributeException : Exception
    {
        public IncorrectAttributeException(string message) : base(message)
        {
        }
    }
}