using System;

namespace Archive.Generator.PropertiesAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OrderAttribute : Attribute
    {
        public int Order { get; private set; }

        public OrderAttribute(int order) => Order = order;
    }
}