using Archive.Generator.ConverterValues.Chain;
using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using System;
using Xunit;

namespace Archive.Generator.Tests.ConverterValues
{
    public class ConverterValueStringTests
    {
        private readonly ConverterValueString _converterValueString;

        public ConverterValueStringTests()
        {
            _converterValueString = new ConverterValueString();
        }

        [Fact]
        public void ObjetoNulo()
        {
            var value = null as object;

            var arrayAttributes = new object[] { new StringAttribute(true), new SizeAttribute(10), };

            var result = _converterValueString.GetString(value, arrayAttributes);

            Assert.Equal("          ", result);
        }

        [Fact]
        public void StringSemAtributoSize()
        {
            var value = string.Empty;

            var arrayAttributes = new object[] { new StringAttribute(true) };

            Action result = () => _converterValueString.GetString(value, arrayAttributes);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Fact]
        public void StringSemAtributoString()
        {
            var value = "VALOR DE TESTE";

            var arrayAttributes = new object[] { new SizeAttribute(20), };

            var result = _converterValueString.GetString(value, arrayAttributes);

            Assert.Equal("VALOR DE TESTE      ", result);
        }

        [Fact]
        public void StringComMaisCaracteresQueOAtributoSize()
        {
            var value = "VALOR DE TESTE";

            var arrayAttributes = new object[] { new SizeAttribute(10), };

            var result = _converterValueString.GetString(value, arrayAttributes);

            Assert.Equal("VALOR DE T", result);
        }

        [Theory]
        [InlineData("MAIS UM TESTE", 20, true, "MAIS UM TESTE       ")]
        [InlineData("MAIS UM TESTE", 20, false, "       MAIS UM TESTE")]
        [InlineData("XPTO", 2, false, "XP")]
        public void StringComAtributoString(string value, int size, bool alignToLeft, string resultadoEsperado)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new StringAttribute(alignToLeft), };

            var result = _converterValueString.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }
    }
}