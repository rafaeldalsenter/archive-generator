using Archive.Generator.PropertiesAttributes;
using System;

namespace Archive.Generator.Tests.FakeObjects
{
    public class FakeObject1 : BaseArchiveGenerator
    {
        [Order(1)]
        [Size(10)]
        [Int(' ')]
        public int Property1 { get; set; }

        [Order(2)]
        [Size(20)]
        [String(true)]
        public string Property2 { get; set; }

        [Order(3)]
        [DateTimeFormatter("yyyyMMdd")]
        public DateTime Property3 { get; set; }

        [Order(4)]
        [Size(10)]
        [Decimal(3, '0')]
        public decimal Property4 { get; set; }

        [Order(5)]
        [Size(12)]
        [String(false)]
        public string Property5 { get; set; }
    }
}