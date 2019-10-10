using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Archive.Generator.ConverterValues.Chain;
using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using Archive.Generator.Tests.ConverterValues.Helper;
using Xunit;

namespace Archive.Generator.Tests.ConverterValues
{
    public class ConverterValueDateTimeTests
    {
        private readonly ConverterValueDateTime _converterValueDateTime;
        private readonly ConverterValueNextChain _converterValueNextChain;

        public ConverterValueDateTimeTests()
        {
            _converterValueDateTime = new ConverterValueDateTime();
            _converterValueNextChain = new ConverterValueNextChain();
            _converterValueDateTime.SetNext(_converterValueNextChain);
        }

        [Fact]
        public void DateTimeNulo()
        {
            var value = null as object;

            var result = _converterValueDateTime.GetString(value, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Theory]
        [InlineData(typeof(decimal))]
        [InlineData(typeof(int))]
        [InlineData(typeof(string))]
        [InlineData(typeof(double))]
        public void OutroTipoQualquer(Type type)
        {
            var valueChangedType = Convert.ChangeType(0, type);

            var result = _converterValueDateTime.GetString(valueChangedType, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void DateTimeSemAttribute()
        {
            var value = new DateTime(2018, 01, 01);

            Action result = () => _converterValueDateTime.GetString(value, null);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Theory]
        [InlineData(2018, 01, 01, "yyyyMMdd", "20180101")]
        [InlineData(2018, 02, 01, "yyyyMMdd", "20180201")]
        [InlineData(2018, 12, 22, "yyMMdd", "181222")]
        [InlineData(2030, 12, 22, "ddMMyy", "221230")]
        public void DateTimeComAttribute(int year, int month, int day, string format, string resultExpected)
        {
            var value = new DateTime(year, month, day);

            var arrayAttributes = new object[] { new DateTimeFormatterAttribute(format) };

            var result = _converterValueDateTime.GetString(value, arrayAttributes);

            Assert.Equal(resultExpected, result);
        }
    }
}