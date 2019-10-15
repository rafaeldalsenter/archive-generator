using System;
using System.Collections.Generic;
using System.Text;
using Archive.Generator.Tests.FakeObjects;
using Xunit;

namespace Archive.Generator.Tests
{
    public class BaseArchiveGeneratorTests
    {
        [Fact]
        public void FakeObject1()
        {
            var stringFakeObject1 = "         1valor da prop 2     201706240000012500valor para s";

            var fakeObject1 = new FakeObject1
            {
                Property1 = 1,
                Property2 = "valor da prop 2",
                Property3 = new DateTime(2017, 06, 24),
                Property4 = (decimal)12.5,
                Property5 = "valor para ser cortado"
            };

            Assert.Equal(stringFakeObject1, fakeObject1.GenerateString());
        }
    }
}