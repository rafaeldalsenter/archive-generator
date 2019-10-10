using Archive.Generator.ConverterValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archive.Generator.Tests.ConverterValues.Helper
{
    internal class ConverterValueNextChain : ConverterValueBase
    {
        public static string RetornoFixo = "NEXT";

        public override string GetString(object value, object[] attributes)
        {
            return RetornoFixo;
        }

        public override List<Type> GetTypes()
        {
            throw new NotImplementedException();
        }
    }
}