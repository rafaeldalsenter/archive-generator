using Archive.Generator.ConverterValues.Chain;
using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using Archive.Generator.Tests.ConverterValues.Helper;
using System;
using Xunit;

namespace Archive.Generator.Tests.ConverterValues
{
    public class ConverterValueIntTests
    {
        private readonly ConverterValueInt _converterValueInt;
        private readonly ConverterValueNextChain _converterValueNextChain;

        public ConverterValueIntTests()
        {
            _converterValueInt = new ConverterValueInt();
            _converterValueNextChain = new ConverterValueNextChain();
            _converterValueInt.SetNext(_converterValueNextChain);
        }

        [Fact]
        public void IntNulo()
        {
            var value = null as object;

            var result = _converterValueInt.GetString(value, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void OutroTipoDecimal()
        {
            var valueChangedType = 0.0;

            var result = _converterValueInt.GetString(valueChangedType, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void OutroTipoDateTime()
        {
            var valueChangedType = new DateTime(2018, 02, 03);

            var result = _converterValueInt.GetString(valueChangedType, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void IntSemAttributeSize()
        {
            var value = 0;

            var arrayAttributes = new object[] { new IntAttribute(' '), };

            Action result = () => _converterValueInt.GetString(value, arrayAttributes);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Fact]
        public void IntSemAttributeInt()
        {
            var value = 0;

            var arrayAttributes = new object[] { new SizeAttribute(2), };

            Action result = () => _converterValueInt.GetString(value, arrayAttributes);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Theory]
        [InlineData(10, 2, "10", false)]
        [InlineData(10, 5, "00010", false)]
        [InlineData(5, 10, "0000000005", false)]
        [InlineData(78985855, 10, "0078985855", false)]
        [InlineData(12, 10, "1200000000", true)]
        [InlineData(7, 5, "70000", true)]
        public void ValoresComEspacosPreenchidosComZeros(int value, int size, string resultadoEsperado,
            bool alignToLeft)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new IntAttribute('0', alignToLeft), };

            var result = _converterValueInt.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }

        [Theory]
        [InlineData(10, 2, "10", false)]
        [InlineData(10, 5, "   10", false)]
        [InlineData(5, 7, "      5", false)]
        [InlineData(78985855, 10, "  78985855", false)]
        [InlineData(12, 10, "12        ", true)]
        [InlineData(7, 5, "7    ", true)]
        public void ValoresComEspacosPreenchidosEmBranco(int value, int size, string resultadoEsperado,
            bool alignToLeft)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new IntAttribute(' ', alignToLeft), };

            var result = _converterValueInt.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }
    }
}