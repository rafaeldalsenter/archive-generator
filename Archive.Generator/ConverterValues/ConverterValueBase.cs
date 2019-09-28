namespace Archive.Generator.ConverterValues
{
    internal abstract class ConverterValueBase : IConverterValue
    {
        private ConverterValueBase _next;

        public abstract string GetString(object value, object[] attributes);

        public void SetNext(ConverterValueBase converterType) => _next = converterType;
    }
}