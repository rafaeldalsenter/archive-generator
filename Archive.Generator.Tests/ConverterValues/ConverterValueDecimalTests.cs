using System;
using System.Collections.Generic;
using System.Text;
using Archive.Generator.ConverterValues.Chain;
using Archive.Generator.Exceptions;
using Archive.Generator.PropertiesAttributes;
using Archive.Generator.Tests.ConverterValues.Helper;
using Xunit;

namespace Archive.Generator.Tests.ConverterValues
{
    public class ConverterValueDecimalTests
    {
        private readonly ConverterValueDecimal _converterValueDecimal;
        private readonly ConverterValueNextChain _converterValueNextChain;

        public ConverterValueDecimalTests()
        {
            _converterValueDecimal = new ConverterValueDecimal();
            _converterValueNextChain = new ConverterValueNextChain();
            _converterValueDecimal.SetNext(_converterValueNextChain);
        }

        [Fact]
        public void DecimalNulo()
        {
            var value = null as object;

            var result = _converterValueDecimal.GetString(value, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void OutroTipoInt()
        {
            var valueChangedType = 0;

            var result = _converterValueDecimal.GetString(valueChangedType, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void OutroTipoDateTime()
        {
            var valueChangedType = new DateTime(2018, 02, 03);

            var result = _converterValueDecimal.GetString(valueChangedType, null);

            Assert.Equal(ConverterValueNextChain.RetornoFixo, result);
        }

        [Fact]
        public void DecimalSemAttributeDeSize()
        {
            var value = decimal.Zero;

            var arrayAttributes = new object[] { new DecimalAttribute(2, ' ') };

            Action result = () => _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Fact]
        public void DecimalSemAttributeDecimal()
        {
            var value = decimal.Zero;

            var arrayAttributes = new object[] { new SizeAttribute(2) };

            Action result = () => _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Throws<IncorrectAttributeException>(result);
        }

        [Theory]
        [InlineData(2, 2, 10, "0000000200")]
        [InlineData(3.02, 3, 10, "0000003020")]
        [InlineData(14.00, 1, 10, "0000000140")]
        [InlineData(22.15, 4, 6, "221500")]
        public void ValoresAlinhadosADireitaPreenchidosComZeros(decimal value, int casasDecimais, int size, string resultadoEsperado)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new DecimalAttribute(casasDecimais, '0'), };

            var result = _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }

        [Theory]
        [InlineData(3, 2, 10, "       300")]
        [InlineData(4.02, 3, 10, "      4020")]
        [InlineData(15.00, 1, 10, "       150")]
        [InlineData(21.15, 4, 6, "211500")]
        public void ValoresAlinhadosADireitaPreenchidosComEspacosEmBranco(decimal value, int casasDecimais, int size, string resultadoEsperado)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new DecimalAttribute(casasDecimais, ' '), };

            var result = _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }

        [Theory]
        [InlineData(2, 2, 10, "2000000000")]
        [InlineData(3.02, 3, 10, "3020000000")]
        [InlineData(14.00, 1, 10, "1400000000")]
        [InlineData(22.15, 4, 6, "221500")]
        public void ValoresAlinhadosAEsquerdaPreenchidosComZeros(decimal value, int casasDecimais, int size, string resultadoEsperado)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new DecimalAttribute(casasDecimais, '0', true), };

            var result = _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }

        [Theory]
        [InlineData(2, 2, 10, "200       ")]
        [InlineData(3.02, 3, 10, "3020      ")]
        [InlineData(14.00, 1, 10, "140       ")]
        [InlineData(22.15, 4, 6, "221500")]
        public void ValoresAlinhadosAEsquerdaPreenchidosComEspacosEmBranco(decimal value, int casasDecimais, int size, string resultadoEsperado)
        {
            var arrayAttributes = new object[] { new SizeAttribute(size), new DecimalAttribute(casasDecimais, ' ', true), };

            var result = _converterValueDecimal.GetString(value, arrayAttributes);

            Assert.Equal(resultadoEsperado, result);
        }
    }
}